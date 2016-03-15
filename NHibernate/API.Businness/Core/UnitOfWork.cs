using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using UoW.Core.Mappings;

namespace UoW.Core
{
    public class UnitOfWork
    {
        private static ISessionFactory _sessionFactory;
        public UnitOfWork() { }

        private static void InitializeSessionFactory()
        {
            var maps = new AutoMappings();

            _sessionFactory = Fluently.Configure()
                .Database(
                    MySQLConfiguration.Standard.ConnectionString(
                        c => c.FromConnectionStringWithKey("connDbCBS")
                       )
                )
                .Mappings(maps.ConfigureMappings)
                .ExposeConfiguration(CreateOrUpdateSchema)
                .BuildSessionFactory();
        }

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();

                return _sessionFactory;
            }
        }

        private static void CreateOrUpdateSchema(Configuration cfg)
        {
            var s = new SchemaValidator(cfg);
            try
            {
                s.Validate();
            }
            catch (HibernateException e)
            {
                var error = e.Message;
            }
        }

        public static ISession OpenSession()
        {
            if (_sessionFactory == null)
                InitializeSessionFactory();

            return SessionFactory.OpenSession();
        }

        public void Dispose()
        {
            if (_sessionFactory != null)
                _sessionFactory.Dispose();

            _sessionFactory = null;
        }
    }
}
