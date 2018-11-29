using Dominio.SalesForceApp.Entidade;
using FluentNHibernate.Mapping;

namespace Dominio.SalesForceApp.Map
{
    public class PesoValorMap: ClassMap<PesoValor>
    {
        public PesoValorMap()
        {
            Id(x => x.Id);
            Map(x => x.DataCriacao).Not.Nullable();
            Map(x => x.PesoMinimo).Not.Nullable();
            Map(x => x.PesoMaximo).Not.Nullable();
            Map(x => x.Valor).Not.Nullable();
            Map(x => x.UltimaAtualizacao).Nullable();
            Map(x => x.UsuarioUltimaAtualizacao).Nullable();
            Map(x => x.AreaCoberturaId).Not.Nullable();
            Map(x => x.ValorCuritiba).Nullable();

            Table("PesoValor");

        }
    }
}
//Id
//DataCriacao
//PesoMinimo
//PesoMaximo
//Valor
//UltimaAtualizacao
//UsuarioUltimaAtualizacao
//AreaCoberturaId
//ValorCuritiba