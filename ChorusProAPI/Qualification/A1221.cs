using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorusProAPI.Qualification
{
    public class A1221
    {
        static public bool DoTest()
        {
            var settings = Settings.GetInstance();

            int IdentifiantCompteGP = settings.m_matelas.GetInt(settings.m_matelas.m_DP, "Identifiant Compte GP");
            int IdentifiantCompteDEV = settings.m_matelas.GetInt(settings.m_matelas.m_DP, "Identifiant Compte DEV");
            int IdentifiantStructure = settings.m_matelas.GetInt(settings.m_matelas.m_DP, "Identifiant Structure");
            int IdentifiantCompteUtilisateur1 = settings.m_matelas.GetInt(settings.m_matelas.m_DP, "Identifiant Compte Utilisateur 1");
            int IdentifiantCompteUtilisateur2 = settings.m_matelas.GetInt(settings.m_matelas.m_DP, "Identifiant Compte Utilisateur 2");

            var response = settings.GetClient().PostAsync<ChorusProAPI.API.RechercherFactureATraiterParRecipiendaireOutput>(new ChorusProAPI.API.RechercherFactureATraiterParRecipiendaireInput() { idUtilisateurCourant = IdentifiantCompteGP, idStructure = IdentifiantStructure });
            response.Wait();
            return response.Result.m_response.IsSuccessStatusCode;
        }
    }
}
