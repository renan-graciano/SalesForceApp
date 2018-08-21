using Dominio.SalesForceApp.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.SalesForceApp.Repositorio
{
    public class RepositorioPessoa_Teste : Repositorio<Pessoa_Teste>
    {
        Random random = new Random();

        public void Incluir()
        {
            var pessoa = new Pessoa_Teste()
            {
                Nome = "Teste Renan" + random.Next(),
                Cpf = "87261797251",
                SexoId = 1,
                EnderecoId = 35,
                Email = "teste@teste.com.br",
                DataNascimento = DateTime.Now.AddYears(-20),
                DataCriacao = DateTime.Now
            };

            Inserir(pessoa);
        }

        public void Atualizar()
        {
            
            var pessoaRetorno = Listar().LastOrDefault();

            pessoaRetorno.Nome = "Teste Renan" + random.Next();
            Alterar(pessoaRetorno);
            
        }
    }
}