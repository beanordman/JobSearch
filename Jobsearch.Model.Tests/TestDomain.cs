using System.IO;
using System.Reflection;
using System.Xml;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using Jobsearch.Model.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Linq.Expressions;
using System.Linq;
using System.Linq.Expressions;

namespace Jobsearch.Model.Tests
{
    [TestClass]
    public class TestDomain
    {
        private static ISession Session { get; set; }

        [ClassInitialize]
        static public void ClassInitialize(TestContext context)
        {
            var cfg = new NHibernate.Cfg.Configuration();

            Assembly assembly = Assembly.GetAssembly(typeof (TestDomain));
            var stream = assembly.GetManifestResourceStream("Jobsearch.Model.Tests.hibernate.cfg.xml");
            var reader = new XmlTextReader(stream);

            cfg.Configure(reader);
            NHibernateProfiler.Initialize();
            Session = cfg.BuildSessionFactory().OpenSession();     
        }

        [ClassCleanup]
        static public void ClassCleanup()
        {
            Session.Connection.Dispose();
            Session.Dispose();
            Session = null;
        }

        [TestMethod]
        public void TestVerifySessionState()
        {
            Assert.IsTrue(Session.IsConnected);    
            Assert.IsTrue(Session.IsOpen);
        }

        [TestMethod]
        public void TestInsertToClient()
        {
            using(var transaction = Session.BeginTransaction())
            {
                var client = new Client()
                                 {
                                     Id = 1,
                                     Address = "Home",
                                     Contact = "Iain",
                                     Details = "The Dude",
                                     Email = "ieb@home.com",
                                     Name = "Iain"
                                 };

                Session.Save(new Client { Id = 2, Address = "20 Fashion Street", Contact = "Sue", Name = "Workshare" });

                transaction.Commit();
            }
        }

        [TestMethod]
        public void TestSelectNameFromClient()
        {
            //using(var trans = Session.BeginTransaction())
            //{
                var q = from client in Session.Query<Client>() where client.Name == "Iain" select client.Name;

                var s = q.Single();
                Assert.AreEqual("Iain", s);
            //    trans.Commit();
            //}
        }

        [TestMethod]
        public void TestSelectAllFromClient()
        {
            using (var transaction = Session.BeginTransaction())
            {
                var x = Session.Query<Client>().OrderBy(client => client.Name);
                //var x = Session.Query<Client>().Distinct();
                //Assert.IsNotNull(x);
                //Assert.AreEqual(3, x.Count());
                Client c = x.First();
                Assert.AreEqual("Iain", c.Name);

                transaction.Commit();
            }
        }

        [TestMethod]
        public void TestClientSelect()
        {
            var client = Session.Query<Client>().Where(x => x.Name == "Workshare");
                //First(x => x.Name == "Workshare");
            //Assert.AreEqual("Sue", client.Contact);
            Assert.IsNotNull(client);
        }
    }
}
