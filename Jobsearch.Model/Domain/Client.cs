using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobsearch.Model.Domain
{
    public class Client
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Contact { get; set; }
        public virtual string Address { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }
        public virtual string Details { get; set; }
        public virtual string Link { get; set; }
    }
}
