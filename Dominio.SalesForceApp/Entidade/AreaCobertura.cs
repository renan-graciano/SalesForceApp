using System;

namespace Dominio.SalesForceApp.Entidade
{
    public class AreaCobertura
    {
        public virtual int Id { get; set; }
        public virtual DateTime DataCriacao { get; set; }
        public virtual int CepInicio { get; set; }
        public virtual int CepTermino { get; set; }
        public virtual DateTime UltimaAtualizacao { get; set; }
        public virtual string UsuarioUltimaAtualizacao { get; set; }
        public virtual int TransportadoraId { get; set; }

        public AreaCobertura()
        {

        }
    }
}
