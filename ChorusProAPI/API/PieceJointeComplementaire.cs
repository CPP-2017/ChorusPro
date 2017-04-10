using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorusProAPI.API
{
    public class PieceJointeComplementaire
    {
        // champ libre désignant la pièce jointe complémentaire à ajouter à la facture varchar(100)
        [CPPAttribute(obligatoire = true)]
        public string pieceJointeComplementaireDesignation { get; set; }

        // type de la pièce jointe complémentaire à ajouter à la facture varchar(30)
        [CPPAttribute(obligatoire = true)]
        public string pieceJointeComplementaireType { get; set; }

        // numéro de la ligne de la facture à laquelle la pièce jointe complémentaire fait éventuellement référence
        public int? pieceJointeComplementaireNumeroLigneFacture { get; set; }

        // identifiant technique de la pièce jointe dans le système
        // RechercherPieceJointeSurStructure OU RechercherPieceJointeSurMonCompte OU AjouterFichierDansSysteme
        [CPPAttribute(obligatoire = true)]
        public int pieceJointeComplementaireId { get; set; }
    }
}
