using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Schedule
    {
        public int ID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string Time { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
