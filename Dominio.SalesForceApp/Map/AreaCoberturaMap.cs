using Dominio.SalesForceApp.Entidade;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.SalesForceApp.Map
{
    public class AreaCoberturaMap: ClassMap<AreaCobertura>
    {
        public AreaCoberturaMap()
        {
            Id(x => x.Id);

            Map(x => x.DataCriacao).Not.Nullable();
            Map(x => x.CepInicio).Not.Nullable();
            Map(x => x.CepTermino).Not.Nullable();
            Map(x => x.UltimaAtualizacao).Nullable();
            Map(x => x.UsuarioUltimaAtualizacao).Nullable();
            Map(x => x.TransportadoraId).Not.Nullable();

            Table("AreaCobertura");

        }

    }
}