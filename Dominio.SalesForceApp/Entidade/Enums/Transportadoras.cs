using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.SalesForceApp.Entidade.Enums
{
    public enum Transportadoras
    {
        [Description("FLASH COURIER")]
        FlashCourier = 41,

        [Description("INTERLOG DISTR.")]
        InterlogDristr = 2,

        [Description("TREX LOGISTICA")]
        TrexLogistica = 42
    }
}
