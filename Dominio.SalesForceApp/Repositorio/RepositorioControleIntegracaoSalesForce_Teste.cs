using Dominio.SalesForceApp.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.SalesForceApp.Repositorio
{
    public class RepositorioControleIntegracaoSalesForce_Teste:Repositorio<ControleIntegracaoSalesForce_Teste>
    {

        public void Atualizar()
        {
            var retornoControle = Listar().LastOrDefault();

            retornoControle.StatusId = 3;

            Alterar(retornoControle);
        }

    }
}
