using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.SalesForceApp.Repositorio;
namespace SalesForceApp
{
    class SalesForce
    {
        static void Main(string[] args)
        {
            var repo = new RepositorioPessoa_Teste();

            repo.Incluir();

            Console.ReadKey();
        }
    }
}
