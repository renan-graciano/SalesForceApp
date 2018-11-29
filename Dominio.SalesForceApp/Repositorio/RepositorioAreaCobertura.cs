using Dominio.SalesForceApp.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.SalesForceApp.Repositorio
{
    public class RepositorioAreaCobertura:Repositorio<AreaCobertura>
    {
        public void Incluir()
        {

        }

        public void Atualizar()
        {

        }

        public List<AreaCobertura> ListarAreas()
        {
            var listaAreaCobertura = Listar().ToList();
            return listaAreaCobertura;
        }
    }
}
