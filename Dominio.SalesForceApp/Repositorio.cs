using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.SalesForceApp.Entidade;
using NHibernate;
using NHibernate.Linq;
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
            using(ISession session = SessionConn.AbrirSession())
            {
                using(ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entidade);
                        transacao.Commit();
                    }
                    catch(Exception ex)
                    {
                        if(!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao alterar entidade: " + ex.Message);
                    }
                }
            }
        }

        public void Excluir(T entidade)
        {
            using(ISession session = SessionConn.AbrirSession())
            {
                using(ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(entidade);
                        transacao.Commit();
                    }
                    catch(Exception ex)
                    {
                        if(!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao excluir  entidade: " + ex.Message);
                    }
                }
            }
        }

        public void Inserir(T entidade)
        {
            using(ISession session = SessionConn.AbrirSession())
            {
                using(ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(entidade);
                        transacao.Commit();
                    }
                    catch(Exception ex)
                    {
                        if(!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao inserir entidade: " + ex.Message);
                    }
                }
            }
        }

        public IList<T> Listar()
        {
            using(ISession session = SessionConn.AbrirSession())
            {
                return (from x in session.Query<T>() select x).ToList();
            }
        }

        public T Obter(int id)
        {
            using(ISession session = SessionConn.AbrirSession())
            {
                return session.Get<T>(id);
            }
        }

    }
}
