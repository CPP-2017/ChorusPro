using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorusProAPI.API
{
    [Rest(path = "factures/consulter/historique")]
    public class ConsulterHistoriqueFactureInput
    {
        // identifiant technique de l’utilisateur courant dans le système CPP
        public int? idUtilisateurCourant { get; set; }

        // identifiant technique de la facture au sein de CPP 2017
        [CPPAttribute(obligatoire = true)]
        public int idFacture { get; set; }

        // identifiant technique de l'espace dans le système CPP2017
        // Cet identifiant permet d'identifier de manière unique un espace au sein du système CPP 2017
        // Valeur par défaut(correspondant à l'espace des factures reçues) : 7
        public int? idEspace { get; set; }

        public Paramrecherchehistostatuts paramRechercheHistoStatuts { get; set; }
        public Paramrecherchehistoactionsutilisateurs paramRechercheHistoActionsUtilisateurs { get; set; }
    }

    public class Paramrecherchehistostatuts
    {
        public int pageResultatDemandeeListeHistoStatut { get; set; }
        public string triSensListeHistoStatut { get; set; }
        public string triColonneListeHistoStatut { get; set; }
    }

    public class Paramrecherchehistoactionsutilisateurs
    {
        public int pageResultatDemandeeListeHistoAction { get; set; }
        public string triSensListeHistoAction { get; set; }
        public string triColonneListeHistoAction { get; set; }
    }

    public class ConsulterHistoriqueFactureOutput : CodeRetour
    {
        public Derniereaction derniereAction { get; set; }
        public Historiquesdesactionsutilisateurs historiquesDesActionsUtilisateurs { get; set; }
        public Historiquesdesevenementscomplementaires historiquesDesEvenementsComplementaires { get; set; }
        public Historiquesdesstatuts historiquesDesStatuts { get; set; }
        public int idFacture { get; set; }
        public string modeDepot { get; set; }
        public string numeroFacture { get; set; }
        public string statutCourantCode { get; set; }
    }

    public class Derniereaction
    {
        public string derniereActionCode { get; set; }
        public int derniereActionId { get; set; }
    }

    public class Historiquesdesactionsutilisateurs
    {
        public Histoaction[] histoAction { get; set; }
        public int nbResultatsParPageHistoAction { get; set; }
        public int pageCouranteHistoAction { get; set; }
        public int pagesHistoAction { get; set; }
        public int totalHistoAction { get; set; }
    }

    public class Histoaction
    {
        public string histoActionCode { get; set; }
        public string histoActionDateHeure { get; set; }
        public int histoActionId { get; set; }
        public string histoActionUtilisateurEmail { get; set; }
        public string histoActionUtilisateurNom { get; set; }
        public string histoActionUtilisateurPrenom { get; set; }
        public string histoActionUtilisateurTelephone { get; set; }
    }

    public class Historiquesdesevenementscomplementaires
    {
        public int nbResultatsParPageEvenement { get; set; }
        public int pageCouranteEvenement { get; set; }
        public int pagesEvenement { get; set; }
        public int totalEvenement { get; set; }
    }

    public class Historiquesdesstatuts
    {
        public Histostatut[] histoStatut { get; set; }
        public int nbResultatsParPageHistoStatut { get; set; }
        public int pageCouranteHistoStatut { get; set; }
        public int pagesHistoStatut { get; set; }
        public int totalHistoStatut { get; set; }
    }

    public class Histostatut
    {
        public string histoStatutCode { get; set; }
        public string histoStatutCommentaire { get; set; }
        public string histoStatutDatePassage { get; set; }
        public int histoStatutId { get; set; }
        public string histoStatutUtilisateurEmail { get; set; }
        public string histoStatutUtilisateurNom { get; set; }
        public string histoStatutUtilisateurPrenom { get; set; }
        public string histoStatutUtilisateurTelephone { get; set; }
    }

}
