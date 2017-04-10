using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorusProAPI.API
{
    [Rest(path = "factures/rechercher/atraiter/fournisseur")]
    public class RechercherFactureATraiterParFournisseurInput
    {
        // identifiant technique de l’utilisateur courant dans le système CPP
        // Cet identifiant permet d'identifier de manière unique l'utilisateur au sein du système CPP 2017
        [CPP(obligatoire = true)]
        public int idUtilisateurCourant { get; set; }

        // identifiant technique de la structure au sein de CPP 2017
        // Cet identifiant permet d'identifier de manière unique la structure au sein du système CPP 2017. Le système récupère la liste des factures pour lesquelles : 
        // - le fournisseur correspond à la structure renseignée (Si IdStructure est renseigné) OU le fournisseur de chaque facture correspond à l'une des structures 
        // auxquelles l'utilisateur est rattaché (Si IdStructure n'est pas renseigné) 
        // - le statut est à : - BROUILLON - A_VALIDER_1 - A_VALIDER_2 - ERREUR_FOURNISSEUR_SUR_VALIDEUR - VALIDEE_1 - VALIDEE_2 - REFUSEE_1 - REFUSEE_2 - ERREUR_COTRAITANT_SUR_VALIDEUR - ABSENCE_VALIDATION_1_HORS_DELAI - ABSENCE_VALIDATION_2_HORS_DELAI - DEPOSEE - EN_COURS_ACHEMINEMENT - MISE_A_DISPOSITION - A_RECYCLER - SUSPENDUE
        // Valeur récupérable avec RecupererStructuresActivesPourFournisseur
        public int? idStructure { get; set; }

        public Recherchefactureatraiterparfournisseur rechercheFactureATraiterParFournisseur { get; set; }
    }

    public class Recherchefactureatraiterparfournisseur
    {
        // nombre de résultats maximum que l’on veut voir retournés par la recherche
        // Par défaut, le service retourne au maximum 200 résultats
        public int? nbResultatsMaximum { get; set; }

        // numéro de la page de résultat à afficher
        // Par défaut, le service retourne la première page
        public int? pageResultatDemandee { get; set; }

        // Nombre : nombre de résultats par page que l’on veut voir retournés par la recherche
        // Par défaut, le service retourne 10 résultats par page
        public int? nbResultatsParPage { get; set; }

        // sens du tri varchar(10)
        // Enumération avec deux valeurs possibles : - Ascendant - Descendant Par défaut, le tri est descendant.
        public string triSens { get; set; }

        // colonne sur laquelle le tri doit être effectué
        // Enumération avec 21 valeurs possibles : - typeDemandePaiement - codeFournisseur - typeIdentifiantFournisseur - fournisseur - codeServiceFournisseur - nomServiceFournisseur - codeDestinataire - designationDestinataire - codeServiceExecutant - nomServiceExecutant - typeFacture - numeroFacture - dateFacture - dateDepot - montantHT - montantTTC - montantAPayer - Devise - Statut - numeroMarche - numeroBonCommande
        // Par défaut, le tri est effectué sur le champ "dateDepot"
        public string triColonne { get; set; }
    }


    public class RechercherFactureATraiterParFournisseurOuput : CodeRetour
    {
        public Listefacture[] listeFactures { get; set; }
        public Parametresretour parametresRetour { get; set; }
    }

    public class Parametresretour
    {
        public int? nbResultatsParPage { get; set; }
        public int? pageCourante { get; set; }
        public int? pages { get; set; }
        public int? total { get; set; }
    }

    public class Listefacture
    {
        // identifiant technique de la facture au sein de CPP 2017
        // Cet identifiant permet d'identifier de manière unique la facture au sein du système CPP 2017
        [CPP(obligatoire = true)]
        public int identifiantFactureCPP { get; set; }

        // type de demande de paiement varchar(50)
        [CPP(obligatoire = true)]
        public string typeDemandePaiement { get; set; }

        // identifiant du fournisseur varchar(18)
        // Identifiant fonctionnel du fournisseur
        [CPP(obligatoire = true)]
        public long codeFournisseur { get; set; }

        // type d'identifiant du fournisseur varchar(14)
        // Enumération avec 7 valeurs possibles : - SIRET - RIDET - TAHITI - HORS_UE - UE_HORS_FRANCE - PARTICULIER - AUTRE
        [CPP(obligatoire = true)]
        public string typeIdentifiantFournisseur { get; set; }

        // designation de la structure fournisseur
        // Cette donnée est une chaîne de caractères qui correspond soit à la raison sociale du fournisseur, soit à la concaténation du nom et du prénom de son représentant.
        [CPP(obligatoire = true)]
        public string designationFournisseur { get; set; }

        // code du service fournisseur varchar(100)
        // Valeur alphanumérique. Si Service.estPremierService = true, alors on ne renseigne pas cet attribut
        public string codeServiceFournisseur { get; set; }

        // nom du service du fournisseur varchar(255)
        // Si Service.estPremierService = true, alors on ne renseigne pas cet attribut
        public string nomServiceFournisseur { get; set; }

        // identifiant technique de la structure destinataire au sein de CPP 2017
        // Cet identifiant permet d'identifier de manière unique la structure au sein du système CPP 2017
        [CPP(obligatoire = true)]
        public int idDestinataire { get; set; }

        // identifiant du destinataire de la facture varchar(14)
        // Valeur alphanumérique Il s'agit du SIRET du destinataire.
        [CPP(obligatoire = true)]
        public long codeDestinataire { get; set; }

        // désignation du destinataire varchar(201)
        // Cette donnée est une chaîne de caractères qui correspond soit à la raison sociale du destinataire, soit à la concaténation du nom et du prénom de son représentant.
        public string designationDestinataire { get; set; }

        // identifiant technique du service exécutant au sein de CPP 2017
        // Cet identifiant permet d'identifier de manière unique le service au sein du système CPP 2017 Si Service.estPremierService = true, alors on ne renseigne pas cet attribut
        public int? idServiceExecutant { get; set; }

        // code du service exécutant varchar(100)
        // Valeur alphanumérique Si Service.estPremierService = true, alors on ne renseigne pas cet attribut
        public string codeServiceExecutant { get; set; }

        // nom du service exécutant
        // Si Service.estPremierService = true, alors on ne renseigne pas cet attribut
        public string nomServiceExecutant { get; set; }

        // type de facture varchar(50)
        // Enumération avec 2 valeurs possibles : - AVOIR - FACTURE
        // Valeur par défaut(si non renseigné) : FACTURE
        [CPP(obligatoire = true)]
        public string typeFacture { get; set; }

        // numéro de la facture varchar(20)
        // Cet identifiant est unique par fournisseur. Valeur alphanumérique
        // Les caractères spéciaux entre crochets ci-dessous sont acceptés : [-] [_] [/] [+]
        [CPP(obligatoire = true)]
        public string numeroFacture { get; set; }

        // date de la facture
        // Format date : AAAA-MM-JJ
        public string dateFacture { get; set; }

        // date de la facture
        // Format date : AAAA-MM-JJ
        public string dateDepot { get; set; }

        // montant HT de la facture après remise decimal (19,6)
        [CPP(obligatoire = true)]
        public float montantHT { get; set; }

        // montant TTC de la facture après remise decimal (19,6)
        [CPP(obligatoire = true)]
        public float montantTTC { get; set; }

        // montant à  payer de la facture après remise decimal (19,6)
        [CPP(obligatoire = true)]
        public float montantAPayer { get; set; }

        [CPP(obligatoire = true)]
        public string devise { get; set; }

        [CPP(obligatoire = true)]
        public string statut { get; set; }

        public string numeroMarche { get; set; }
        public string numeroBonCommande { get; set; }
    }

}
