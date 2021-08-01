using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication20.Models;

namespace WebApplication20.ViewModel
{
    public class ProjectTicketViewModel
    {

        public Project Project { get; set; }
        public int Project_id { get; set; }

        
        public Ticket Ticket { get; set;
        }
        public string TicketName { get; set; }
        
        public string TicketDescription { get; set; }

        public DateTime TicketCreated { get; set; }

        public string TicketPriority { get; set; }

        public string TicketType { get; set; }

    }
}
