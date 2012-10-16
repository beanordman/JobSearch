using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobsearch.Model.Domain
{
    public class Job
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Details { get; set; }
        public virtual string Link { get; set; }
    }
}
