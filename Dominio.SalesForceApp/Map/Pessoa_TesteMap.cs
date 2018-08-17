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
            Map(c => c.Nome).Not.Nullable();
            Map(c => c.Cpf).Not.Nullable();
            Map(c => c.SexoId).Not.Nullable();
            Map(c => c.EnderecoId).Not.Nullable();
            Map(c => c.Email).Not.Nullable();
            Map(c => c.Deletado);
            Map(c => c.DataNascimento).Not.Nullable();
            Map(c => c.UltimaAtualizacao).Nullable();
            Map(c => c.UsuarioUltimaAtualizacao).Nullable();
            Map(c => c.IdSalesForce).Nullable();
            Map(c => c.IdSalesForceContatoRelacionado).Nullable();

            Table("Pessoa_Teste");
        }
    }
}
