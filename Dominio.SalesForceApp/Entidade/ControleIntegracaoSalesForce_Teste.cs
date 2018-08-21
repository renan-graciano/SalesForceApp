using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.SalesForceApp.Entidade
{
    public class ControleIntegracaoSalesForce_Teste
    {
        public virtual int Id { get; set; }
        public virtual int TipoId { get; set; }
        public virtual int StatusId { get; set; }
        public virtual string MensagemIntegracao { get; set; }
        public virtual string RetornoIntegracao { get; set; }
        public virtual int EntidadeId { get; set; }
        public virtual DateTime? DataEnvioSalesForce { get; set; }
        public virtual DateTime DataCriacao { get; set; }
    }
}
