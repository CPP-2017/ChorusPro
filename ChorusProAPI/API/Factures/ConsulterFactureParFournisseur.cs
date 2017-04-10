using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorusProAPI.API
{
    [Rest(path = "factures/consulter/fournisseur")]
    public class ConsulterFactureParFournisseurInput : ConsulterFacture
    {
    }

    public class ConsulterFactureParFournisseurOutput : CodeRetour
    {
        public Facture facture { get; set; }
    }
}
