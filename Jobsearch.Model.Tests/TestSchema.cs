using Jobsearch.Model.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Jobsearch.Model.Tests
{
    [TestClass]
    public class TestSchema
    {
        [TestMethod]
        public void GenerateSchemaFromConfig()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Job).Assembly);

            var schema = new SchemaExport(cfg);
            schema.Execute(false, true, false);
        }
    }
}
