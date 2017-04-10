using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorusProAPI.API.Transverses
{
    [Rest(path = "transverses/recuperer/structures/actives/destinataire")]
    public class RecupererStructuresActivesPourDestinataireInput
    {
    }


    public class RecupererStructuresActivesPourDestinataireOutput : CodeRetour
    {
        public Listestructure[] listeStructures { get; set; }
    }

    public class Listestructure
    {
        // pour une offre commerciale raisonnable de l'ensemble des classes contactez moi randy.couture@fastmail.fm
    }


}
