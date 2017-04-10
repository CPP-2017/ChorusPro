using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorusProAPI.API
{
    [Rest(path = "factures/deposer/pdf")]
    public class DeposerPdfFactureInput
    {
        // identifiant technique de l’utilisateur courant dans le système CPP
        public int? idUtilisateurCourant { get; set; }

        // fichier PDF correspondant à la facture encodé en base64
        public string fichierFacture { get; set; }

        // choix du format de fichier à déposer varchar(15)
        // Enumération avec 3 valeurs possibles : - PDF_NON_SIGNE - PDF_SIGNE_PADES - PDF_SIGNE_XADES
        public string formatDepot { get; set; }

        // Nom du fichier avec extension (sans le path) varchar(200)
        public string nomFichier { get; set; }
    }

    public class DeposerPdfFactureOuput : CodeRetour
    {
        // numéro de la facture varchar(20)
        // Cet identifiant est unique par fournisseur. Valeur alphanumérique
        // Les caractères spéciaux entre crochets ci-dessous sont acceptés : [-] [_] [/] [+]
        public string numeroFacture { get; set; }

        // date de la facture indiquée sur le PDF
        // Format date : AAAA-MM-JJ
        public string dateFacture { get; set; }

        // String : identifiant du destinataire de la facture varchar(14)
        // Valeur alphanumérique Il s'agit du SIRET du destinataire
        public string codeDestinataire { get; set; }

        // code du service destinataire de la facture varchar(100)
        // Valeur alphanumérique
        public string codeServiceExecutant { get; set; }

        // identifiant du fournisseur varchar(18)
        // Valeur alphanumérique
        public string codeFournisseur { get; set; }

        // code de la devise de la facture varchar(3)
        public string codeDeviseFacture { get; set; }

        // type de la facture varchar(50)
        // Enumération avec 2 valeurs possibles: AVOIR FACTURE
        public string typeFacture { get; set; }

        // type de TVA varchar(50)
        // Enumération avec 4 valeurs possibles : - TVA_SUR_DEBIT - TVA_SUR_ENCAISSEMENT - EXONERATION - SANS_TVA
        public string typeTva { get; set; }

        // numéro du bon de commande varchar(50)
        public string numeroBonCommande { get; set; }

        // montant total TTC de la facture avant remise decimal (19,6)
        public float? montantTtcAvantRemiseGlobalTTC { get; set; }

        // montant de la facture à payer decimal (19,6)
        public float? montantAPayer { get; set; }

        // montant total HT de la facture après remise decimal (19,6)
        public float? montantHtTotal { get; set; } 

       // montant total de la TVA sur la facture après remise decimal (19,6)
        public float? montantTVA { get; set; }

        // identifiant technique de la pièce jointe dans le système
        // Cet identifiant permet d'identifier de manière unique la pièce jointe au sein du système CPP 2017
        public int pieceJointeId { get; set; }
    }

}
