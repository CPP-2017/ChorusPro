using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorusProAPI.API
{
    [Rest(path = "factures/travaux/consulter/dossierfacturation")]
    public class ConsulterDossierDeFacturationInput
    {
        // pour une offre commerciale raisonnable de l'ensemble des classes contactez moi randy.couture@fastmail.fm

    }

    public class Plistepiecesjointes4
    {
        // pour une offre commerciale raisonnable de l'ensemble des classes contactez moi randy.couture@fastmail.fm

    }


    public class ConsulterDossierDeFacturationOutput : CodeRetour
    {
        public Listefacturetravaux[] listeFactureTravaux { get; set; }
    }

    public class Listefacturetravaux
    {
        // pour une offre commerciale raisonnable de l'ensemble des classes contactez moi randy.couture@fastmail.fm
    }

    public class Historiquedemandepaiement
    {
        // pour une offre commerciale raisonnable de l'ensemble des classes contactez moi randy.couture@fastmail.fm
    }


}
