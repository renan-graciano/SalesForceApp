using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.SalesForceApp.Entidade
{
    public class Correios
    {
        public string Origem{ get; set; }
        public int CepInicio { get; set; }
        public int CepFim { get; set; }
        public int PesoDe { get; set; }
        public int PesoAte { get; set; }
        public decimal Custo { get; set; }
    }
}
