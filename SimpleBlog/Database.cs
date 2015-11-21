using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using SimpleBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBlog
{
    public static class Database
    {
        private const string SESSIONKEY = "SimpleBlog.Database.SessionKey";
        private static ISessionFactory _sessionFactory;
        public static ISession Session
        {
            get { return (ISession)HttpContext.Current.Items[SESSIONKEY]; } //using (ISession) cast will throw an exception
        }

        public static void Configure()
        {
            var config = new Configuration();

            //configure connection string
            config.Configure();

            // add mappings
            var mapper = new ModelMapper();
            mapper.AddMapping<UserMap>();

            config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

            //create session factory
            _sessionFactory = config.BuildSessionFactory();


        }
        public static void OpenSession()
        {
            HttpContext.Current.Items[SESSIONKEY] = _sessionFactory.OpenSession();

        }

        public static void CloseSession()
        {
            var session = HttpContext.Current.Items[SESSIONKEY] as ISession; //using as ISession cast will NOT throw an exception
            if (session != null)
                session.Close();

            HttpContext.Current.Items.Remove(SESSIONKEY);
        }

    }
}