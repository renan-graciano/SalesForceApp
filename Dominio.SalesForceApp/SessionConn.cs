using Iterative.Infra.Extensions;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.SalesForceApp
{
    public class SessionConn
    {
        private static string ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString_Incubadora").Decrypt();
  
        private ISessionFactory session;
    }
}
