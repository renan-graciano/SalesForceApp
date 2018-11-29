using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.SalesForceApp.Entidade
{
    public class Transportadora
    {
        public virtual string NomeTransportadora { get; set; }

        public virtual int CepDe { get; set; }

        public virtual int CepAte { get; set; }

        public virtual int ValorMin { get; set; }

        public virtual int ValorMax { get; set; }

        public virtual decimal ValorCusto { get; set; }
    }
}
