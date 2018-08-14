using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.SalesForceApp.Entidade;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;

namespace Dominio.SalesForceApp
{
    public class Repositorio<T> : IRepositorio<T>
    {
        private Configuration _configuration;
        private ISessionFactory _sessionFactory;
        private ISession _session;
        

        public Repositorio()
        {
            _configuration = new Configuration();
            _configuration.Configure();
            var mapper = new ModelMapper();
            mapper.AddMapping(typeof(Pessoa_Teste));
            _configuration.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());
        }

        public void Alterar(T entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(T entidade)
        {
            throw new NotImplementedException();
        }

        public void Inserir(T entidade)
        {
            throw new NotImplementedException();
        }

        public IList<T> Listar()
        {
            throw new NotImplementedException();
        }

        public T Obter(int id)
        {
            throw new NotImplementedException();
        }

    }
}
