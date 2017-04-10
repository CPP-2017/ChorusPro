using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorusProAPI.API
{
    [Rest(path = "factures/consulter/recipiendaire")]
    public class ConsulterFactureParRecipiendaireInput : ConsulterFacture
    {
    }

    public class ConsulterFactureParRecipiendaireOuput : CodeRetour
    {
        public Facture facture { get; set; }
    }
}
