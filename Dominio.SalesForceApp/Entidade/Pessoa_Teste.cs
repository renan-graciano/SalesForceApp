using System;

namespace Dominio.SalesForceApp.Entidade
{
    public class Pessoa_Teste
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Cpf { get; set; }
        public virtual int SexoId { get; set; }
        //public virtual IList<Empresa> Empresas { get; protected set; }
        public virtual int EnderecoId { get; set; }
        //public virtual IList<Contato> Contatos { get; protected set; }
        public virtual string Email { get; set; }
        public virtual DateTime? Deletado { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual DateTime DataCriacao { get; set; }
        public virtual DateTime? UltimaAtualizacao { get; set; }
        public virtual string UsuarioUltimaAtualizacao { get; set; }
        public virtual string IdSalesForce { get; set; }
        public virtual string IdSalesForceContatoRelacionado { get; set; }


        public Pessoa_Teste()
        {

        }



    }

}
