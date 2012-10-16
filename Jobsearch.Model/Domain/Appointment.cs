using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobsearch.Model.Domain
{
    public class Appointment
    {
        public virtual int Id { get; set; }
        public virtual int ClientId { get; set; }
        public virtual string Details { get; set; }
        public virtual DateTime Date { get; set; }
    }
}
