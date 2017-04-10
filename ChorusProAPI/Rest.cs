using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace ChorusProAPI
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RestAttribute : Attribute
    {
        public string path { get; set; }
    }

    public class RestResponse<T> where T : API.CodeRetour, new()
    {
        public System.Net.Http.HttpResponseMessage m_response;
        public T m_data;
    }

    public class HttpClient
    {
        public System.Net.Http.HttpClient m_client = null;// ("https://chorus-pro.gouv.fr:5443");
        public System.Net.Http.WebRequestHandler m_handler = null;
        public byte[] m_basicAuthorization = null;

        public string m_url;
        public string m_prefix;

        public void SetBasicAuthenticator(string userName, string password)
        {
            m_basicAuthorization = Encoding.ASCII.GetBytes(userName + ":" + password);
        }

        public void SetPrivateKey(string fileName, string password)
        {
            System.Net.Http.WebRequestHandler handler = new System.Net.Http.WebRequestHandler();
            X509Certificate2 cert = new X509Certificate2(fileName, password);
            handler.ClientCertificates.Add(cert);
        }

        public System.Net.Http.HttpClient GetClient()
        {
            if (m_client == null)
            {
                if (m_handler == null)
                    m_client = new System.Net.Http.HttpClient();
                else
                    m_client = new System.Net.Http.HttpClient(m_handler);
                if (m_basicAuthorization != null)
                    m_client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(m_basicAuthorization));
            }
            return m_client;
        }

        public async Task<RestResponse<T>> PostAsync<T>(object body) where T : API.CodeRetour, new()
        {
            RestResponse<T> result = new RestResponse<T>();
            RestAttribute attribute = body.GetType().GetCustomAttributes(typeof(RestAttribute), false).FirstOrDefault() as RestAttribute;
            if (attribute != null)
            {
                string temp = SimpleJson.SimpleJson.SerializeObject(body);
                System.Net.Http.HttpContent content = new System.Net.Http.StringContent(temp);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                result.m_response = GetClient().PostAsync(m_url + "/" + m_prefix + "/" + attribute.path, content).Result;
                if (result.m_response.IsSuccessStatusCode)
                {
                    string responseString = null;
                    if (result.m_response.Content.Headers.ContentType.CharSet.ToLower().Contains("utf-8"))
                    {
                        var buffer = await result.m_response.Content.ReadAsByteArrayAsync();
                        var byteArray = buffer.ToArray();
                        responseString = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
                    }
                    else
                        responseString = await result.m_response.Content.ReadAsStringAsync();

                    result.m_data = SimpleJson.SimpleJson.DeserializeObject<T>(responseString);
                }
            }
            else
                throw new Exception("RestAttribute obligatoire pour le body");
            return result;
        }
    }
}
