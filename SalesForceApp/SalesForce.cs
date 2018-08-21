using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.SalesForceApp.Repositorio;
using System.IO;
namespace SalesForceApp
{
    class SalesForce
    {
        static void Main(string[] args)
        {
            var arquivoLog = @"C:\logControleSalesForce.txt";
            StreamWriter writer;
            if (!File.Exists(arquivoLog))
                writer = new StreamWriter(arquivoLog);
            else
                writer = File.AppendText(arquivoLog);
            
            try
            {


                var repo = new RepositorioPessoa_Teste();
                var repoControle = new RepositorioControleIntegracaoSalesForce_Teste();

                repo.Incluir();

                Console.WriteLine("Entidade Pessoa inserida no banco de dados.");
                writer.WriteLine(DateTime.Now.ToString() + " - Entidade Pessoa inserida no banco de dados.");
                System.Threading.Thread.Sleep(300);

                repoControle.Atualizar();

                Console.WriteLine("Entidade ControleIntegracaoSalesForce alterada no banco de dados.");
                writer.WriteLine(DateTime.Now.ToString() + " - Entidade ControleIntegracaoSalesForce alterada no banco de dados.");
                System.Threading.Thread.Sleep(300);

                repo.Atualizar();

                Console.WriteLine("Entidade Pessoa alterada no banco de dados.");
                writer.WriteLine(DateTime.Now.ToString() + " - Entidade Pessoa alterada no banco de dados.");
                System.Threading.Thread.Sleep(300);
            }
            catch (Exception ex)
            {
                writer.WriteLine(DateTime.Now.ToString() + " - Error: " + ex.Message);
            }
            finally
            {
                writer.Close();
            }
        }
    }
}
