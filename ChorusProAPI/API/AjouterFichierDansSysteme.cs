using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorusProAPI.API
{
    class AjouterFichierDansSystemeInput
    {
        public int idUtilisateurCourant { get; set; }
        public string pieceJointeFichier { get; set; }
        public string pieceJointeNom { get; set; }
        public string pieceJointeTypeMime { get; set; }
        public string pieceJointeExtension { get; set; }
    }

    class AjouterFichierDansSystemeOutput : CodeRetour
    {
        public int pieceJointeId { get; set; }
    }
}
