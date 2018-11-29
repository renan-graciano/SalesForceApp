using System;

namespace Dominio.SalesForceApp.Entidade
{
    public class PesoValor
    {
        public virtual int Id { get; set; }
        public virtual DateTime DataCriacao { get; set; }
        public virtual decimal PesoMinimo { get; set; }
        public virtual decimal PesoMaximo { get; set; }
        public virtual decimal Valor { get; set; }
        public virtual DateTime UltimaAtualizacao { get; set; }
        public virtual string UsuarioUltimaAtualizacao { get; set; }
        public virtual int AreaCoberturaId { get; set; }
        public virtual decimal ValorCuritiba { get; set; }

        public PesoValor()
        {

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