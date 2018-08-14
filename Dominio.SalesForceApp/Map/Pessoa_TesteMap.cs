using Dominio.SalesForceApp.Entidade;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.SalesForceApp.Map
{
    public class Pessoa_TesteMap: ClassMap<Pessoa_Teste>
    {
        public Pessoa_TesteMap()
        {
            Id(c => c.Id);
            Map(c => c.Cpf);
            Map(c => c.SexoId);
            Map(c => c.EnderecoId);
            Map(c => c.Email);
            Map(c => c.Deletado);
            Map(c => c.DataNascimento);
            Map(c => c.UltimaAtualizacao);
            Map(c => c.UsuarioUltimaAtualizacao);
            Map(c => c.IdSalesForce);
            Map(c => c.IdSalesForceContatoRelacionado);

            Table("Pessoa_Teste");
        }
    }
}
