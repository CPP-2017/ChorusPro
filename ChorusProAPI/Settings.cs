using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorusProAPI
{
    public class Element
    {
        public string Entite { get; set; }
        public string Libelle { get; set; }
        public string Valeur { get; set; }
    }

    public class Matelas
    {
        List<Element> m_elements;

        public string m_DP = "Destinataire Partenaire";

        static public Matelas ReadFromFile(string file)
        {
            Matelas result = new Matelas() { m_elements = new List<Element>() };
            using (System.IO.StreamReader sr = new System.IO.StreamReader(file))
            {
                sr.ReadLine(); // Passer l'entête
                string line = null;
                while ((line = sr.ReadLine())!=null)
                {
                    string[] items = line.Split(';');
                    if (items.Length==3)
                        result.m_elements.Add(new Element() { Entite = items[0], Libelle = items[1], Valeur = items[2] });
                }
            }
            return result;
        }

        public string GetString(string Entite,  string Libelle)
        {
            return m_elements.Find(a => a.Entite == Entite && a.Libelle == Libelle).Valeur;
        }

        public int GetInt(string Entite, string Libelle)
        {
            return Convert.ToInt32(m_elements.Find(a => a.Entite == Entite && a.Libelle == Libelle).Valeur);
        }
    }

    public class Settings
    {
        static public Settings m_instance;
        static public Settings GetInstance()
        {
            if (m_instance == null)
                m_instance = new Settings();
            return m_instance;
        }

        public global::System.Configuration.ApplicationSettingsBase m_settings;

        public Matelas m_matelas;

        public void Init(global::System.Configuration.ApplicationSettingsBase settings)
        {
            m_settings = settings;
            m_matelas = ChorusProAPI.Matelas.ReadFromFile(System.Environment.ExpandEnvironmentVariables(m_settings["Matelas"].ToString()));
        }

        public ChorusProAPI.HttpClient m_client;
        public ChorusProAPI.HttpClient GetClient()
        {
            if (m_client == null)
            {
                m_client = new ChorusProAPI.HttpClient() { m_prefix = m_settings["UrlPrefix"].ToString(), m_url = m_settings["URI"].ToString() };
                m_client.SetBasicAuthenticator(m_matelas.GetString(m_matelas.m_DP, "Login Compte DEV"), m_matelas.GetString(m_matelas.m_DP, "Mot de passe Compte DEV"));
                m_client.SetPrivateKey(System.Environment.ExpandEnvironmentVariables(m_settings["Certificat"].ToString()), System.Environment.ExpandEnvironmentVariables(m_settings["CertificatPassword"].ToString()));
            }
            return m_client;
        }

    }
}
