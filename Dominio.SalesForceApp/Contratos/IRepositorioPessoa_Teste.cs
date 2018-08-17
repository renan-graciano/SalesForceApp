using Dominio.SalesForceApp.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.SalesForceApp.Contratos
{
    public interface IRepositorioPessoa_Teste: IRepositorio<Pessoa_Teste>
    {
        void Incluir();
        void Atualizar();
        

    }
}
