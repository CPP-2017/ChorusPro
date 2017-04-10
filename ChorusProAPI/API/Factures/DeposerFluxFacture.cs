using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorusProAPI.API
{
    [Rest(path = "factures/deposer/flux")]
    public class DeposerFluxFactureInput
    {
        // identifiant technique de l’utilisateur courant dans le système CPP
        [CPPAttribute(obligatoire = true)]
        public int idUtilisateurCourant { get; set; }

        // fichier correspondant au flux de factures, encodé en base64
        [CPPAttribute(obligatoire = true)]
        public string fichierFlux { get; set; }

        // nom du fichier avec l'extension varchar(200)
        [CPPAttribute(obligatoire = true)]
        public string nomFichier { get; set; }

        // choix de la syntaxe du fichier à déposer
        // Enumération avec 7 valeurs possibles : - IN_DP_E1_UBL_INVOICE - IN_DP_E1_CII - IN_DP_E1_PES_FACTURE - IN_DP_E2_UBL_INVOICE_MIN - IN_DP_E2_CII_MIN - IN_DP_E2_PES_FACTURE_MIN - IN_DP_E2_CPP_FACTURE_MIN
        [CPPAttribute(obligatoire = true)]
        public string syntaxeFlux { get; set; }

        // indicateur précisant si le fichier est signé ou non
        public bool? avecSignature { get; set; }

    }

}
