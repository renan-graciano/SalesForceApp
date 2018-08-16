using Iterative.Infra.Extensions;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;

namespace Dominio.SalesForceApp
{
    public class SessionConn
    {
        private static string ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString_Incubadora").Decrypt();
  
        private static ISessionFactory session;

        public static ISessionFactory CriarSession()
        {
            if (session != null)
                return session;

            IPersistenceConfigurer configDb = MsSqlConfiguration.MsSql2008.ConnectionString(ConnectionString);
            var configMap = Fluently.Configure().Database(configDb).Mappings(c => c.FluentMappings.AddFromAssemblyOf<Map.Pessoa_TesteMap>());
            session = configMap.BuildSessionFactory();
            return session;
        }

        public static ISession AbrirSession()
        {
            return session.OpenSession();
        }
    }
}
