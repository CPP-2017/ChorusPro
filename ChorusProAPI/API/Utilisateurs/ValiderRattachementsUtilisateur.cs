using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorusProAPI.API
{
    [RestAttribute(path = "utilisateurs/structures/valider/rattachements")]
    public class ValiderRattachementsUtilisateurInput
    {
    }

    public class ValiderRattachementsUtilisateurOuput : CodeRetour
    {
    }

}
