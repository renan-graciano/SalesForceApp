using Dominio.SalesForceApp.Entidade;
using System.Collections.Generic;

namespace Dominio.SalesForceApp.Contratos
{
    interface IRepositorioAreaCobertura: IRepositorio<AreaCobertura>
    {
        void Incluir();
        void Atualizar();
        List<AreaCobertura> ListarAreas();

    }
}
