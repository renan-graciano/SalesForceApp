using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Dominio.SalesForceApp.Entidade;
using FluentNHibernate.Conventions.Helpers;

namespace Dominio.SalesForceApp.Map
{
    public class ControleIntegracaoSalesForce_TesteMap: ClassMap<ControleIntegracaoSalesForce_Teste>
    {
        public ControleIntegracaoSalesForce_TesteMap()
        {
            Id(x => x.Id);
            Map(x => x.DataCriacao);
            Map(x => x.MensagemIntegracao).Length(4001).Nullable();
            Map(x => x.RetornoIntegracao).Length(4001).Nullable();
            Map(x => x.EntidadeId).Nullable();
            Map(x => x.DataEnvioSalesForce).Nullable();
            Map(x => x.StatusId).Not.Nullable();
            Map(x => x.TipoId).Not.Nullable();

            Table("ControleIntegracaoSalesForce_Teste");
        }
    }
}
