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
        public void Incluir()
        {
            var pessoa = new Pessoa_Teste()
            {
                Nome = "Teste Renan",
                Cpf = "87261797251",
                SexoId = 1,
                EnderecoId = 35,
                Email = "teste@teste.com.br",
                DataNascimento = DateTime.Now.AddYears(-20)
            };

            Inserir(pessoa);
        }

        public void Atualizar(int id)
        {
            var random = new Random();
            var pessoaRetorno = Obter(id);

            pessoaRetorno.Nome = "Teste Renan" + random.Next();
            Alterar(pessoaRetorno);
            
        }
    }
}