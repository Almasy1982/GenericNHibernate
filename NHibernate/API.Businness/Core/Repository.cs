using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace UoW.Core.Core
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public void Save(T entidade)
        {
            ISession session = UnitOfWork.OpenSession();

            using (ITransaction transacao = session.BeginTransaction())
            {
                try
                {
                    session.Save(entidade);
                    transacao.Commit();
                }
                catch (Exception ex)
                {
                    if (!transacao.WasCommitted)
                        transacao.Rollback();

                    throw new Exception("Erro ao Inserir : " + ex.Message);
                }
            }
        }

        public void Update(T entidade)
        {
            ISession session = UnitOfWork.OpenSession();

            using (ITransaction transacao = session.BeginTransaction())
            {
                try
                {
                    session.Update(entidade);
                    transacao.Commit();
                }
                catch (Exception ex)
                {
                    if (!transacao.WasCommitted)
                        transacao.Rollback();

                    throw new Exception("Erro ao Alterar : " + ex.Message);
                }
            }
        }

        public void Delete(T entidade)
        {
            ISession session = UnitOfWork.OpenSession();

            using (ITransaction transacao = session.BeginTransaction())
            {
                try
                {
                    session.Delete(entidade);
                    transacao.Commit();
                }
                catch (Exception ex)
                {
                    if (!transacao.WasCommitted)
                        transacao.Rollback();

                    throw new Exception("Erro ao Excluir : " + ex.Message);
                }
            }
        }

        public T GetById(int Id)
        {
            ISession session = UnitOfWork.OpenSession();
            return session.Get<T>(Id);
        }

        public IQueryable<T> Getall(Expression<Func<T, object>> expression)
        {
            ISession session = UnitOfWork.OpenSession();
            return (from c in session.Query<T>() select c).OrderBy(expression).ToList().AsQueryable();
        }
    }
}
