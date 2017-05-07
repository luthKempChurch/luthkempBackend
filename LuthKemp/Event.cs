using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuthKemp
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public bool Show { get; set; }
    }
}
