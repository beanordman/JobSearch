using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobsearch.Model.Domain
{
    public class Application
    {
        public virtual int Id { get; set; }
        public virtual int JobId { get; set; }
        public virtual string Status { get; set; }
        public virtual string Notes { get; set; }
    }
}