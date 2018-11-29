using Dominio.SalesForceApp.Entidade;

namespace Dominio.SalesForceApp.Contratos
{
    public interface IRepositorioPesoValor: IRepositorio<PesoValor>
    {
        void Incluir();
        void Atualizar();
    }
}
