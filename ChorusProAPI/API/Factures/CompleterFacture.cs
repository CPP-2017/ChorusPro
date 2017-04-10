using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorusProAPI.API
{
    [RestAttribute(path = "factures/completer")]
    public class CompleterFactureInput
    {
        // identifiant technique de l’utilisateur courant dans le système CPP
        public int? idUtilisateurCourant { get; set; }

        // identifiant technique de la facture au sein de CPP 2017
        [CPPAttribute(obligatoire = true)]
        public int identifiantFactureCPP { get; set; }

        public List<PieceJointeComplementaire> pieceJointeComplementaire { get; set; }
        
        // champ libre de commentaire text(2000)
        public string commentaire { get; set; }
    }

    public class CompleterFactureOuput : CodeRetour
    {
        // identifiant technique de la facture au sein de CPP 2017
        // Cet identifiant permet d'identifier de manière unique la facture au sein du système CPP 2017
        public int identifiantFactureCPP { get; set; }
        
        // date de traitement de la facture
        // Format date : AAAA-MM-JJ HH:MI
        public string dateTraitement { get; set; }

        // numéro de la facture varchar(20)
        // Cet identifiant est unique par fournisseur. Valeur alphanumérique
        public string numeroFacture { get; set; }
    }

}
