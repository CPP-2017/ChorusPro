using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorusProAPI.API
{
    public class CPPAttribute : Attribute
    {
        public bool obligatoire { get; set; }
    }

    public class CodeRetour
    {
        public int codeRetour { get; set; }
        public string libelle { get; set; }
    }

    public class CodeErreur
    {
        public int codeErreur { get; set; }
        public string description { get; set; }
        public string messageErreur { get; set; }
    }

    public class CodeErreurs : List<CodeErreur>
    {
        public CodeErreurs()
        {
            Add(new CodeErreur() { codeErreur = 20000, description = "La demande de paiement n'existe pas.", messageErreur = "GDP_MSG_11.008" });
            Add(new CodeErreur() { codeErreur = 20001, description = "L’utilisateur n’a pas les habilitations nécessaires pour soumettre la demande.", messageErreur = "GDP_MSG_11.005" });
            Add(new CodeErreur() { codeErreur = 20002, description = "Le statut de la demande de paiement n'est pas défini à \"Suspendue\".", messageErreur = "GDP_MSG_11.033" });
        }
    }
}
