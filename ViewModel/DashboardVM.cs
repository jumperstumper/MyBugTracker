using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication20.Models;

namespace WebApplication20.ViewModel
{
    public class DashboardVM
    {
        public Project Project { get; set; }
        public int Project_Id { get; set; }

        public Ticket Ticket { get; set; }
        public string TicketPriority { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
        public IList<string> RolesforthisUser { get; set; }
    }
}
