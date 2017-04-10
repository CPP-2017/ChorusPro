using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorusProAPI.API
{
    [RestAttribute(path = "factures/rechercher/atraiter/recipiendaire")]
    public class RechercherFactureATraiterParRecipiendaireInput
    {
        // identifiant technique de l’utilisateur courant dans le système CPP
        // Cet identifiant permet d'identifier de manière unique l'utilisateur au sein du système CPP 2017
        [CPP(obligatoire = true)]
        public int idUtilisateurCourant { get; set; }

        // identifiant technique de la structure au sein de CxPP 2017
        // Cet identifiant permet d'identifier de manière unique la structure au sein du système CPP 2017
        // Si IdStructure est renseigné, le système récupère la liste des factures et des factures de travaux pour lesquelles :
        // - le destinataire correspond à la structure renseignée OU le destinataire correspond à l'une des structures auxquelles l'utilisateur est rattaché
        // - le statut est à : MISE_A_DISPOSITION - COMPLETEE
        public int? idStructure { get; set; }

        public Parametrerecherchefactureatraiterparrecipiendaire parametreRechercheFactureATraiterParRecipiendaire { get; set; }
    }

    public class Parametrerecherchefactureatraiterparrecipiendaire
    {
        public int nbResultatsMaximum { get; set; }
        public int pageResultatDemandee { get; set; }
        public int nbResultatsParPage { get; set; }
        public string triSens { get; set; }
        public string triColonne { get; set; }
    }


    public class RechercherFactureATraiterParRecipiendaireOutput : CodeRetour
    {
        public int? pageCourante { get; set; }
        public int? pages { get; set; }
        public int? nbResultatsParPage { get; set; }
        public int? total { get; set; }
        public Listefacture2[] listeFactures { get; set; }
    }

    public class Listefacture2
    {
        public string codeDestinataire { get; set; }
        public string codeFournisseur { get; set; }
        public string codeServiceExecutant { get; set; }
        public string codeServiceFournisseur { get; set; }
        public string dateDepot { get; set; }
        public string dateFacture { get; set; }
        public string designationDestinataire { get; set; }
        public string designationFournisseur { get; set; }
        public string devise { get; set; }
        public bool factureTelechargeeParDestinataire { get; set; }
        public int idDestinataire { get; set; }
        public int idFacture { get; set; }
        public int idServiceExecutant { get; set; }
        public float montantAPayer { get; set; }
        public int montantHT { get; set; }
        public float montantTTC { get; set; }
        public string nomServiceExecutant { get; set; }
        public string nomServiceFournisseur { get; set; }
        public string numeroBonCommande { get; set; }
        public string numeroFacture { get; set; }
        public string numeroMarche { get; set; }
        public string statut { get; set; }
        public string typeDemandePaiement { get; set; }
        public string typeFacture { get; set; }
        public string typeFactureTravaux { get; set; }
        public string typeIdentifiantFournisseur { get; set; }
    }

}
