using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication20.Models;

namespace WebApplication20.ViewModel
{
    public class AddDevVM
    {
        public UserTicket UserTicket { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Ticket Ticket { get; set; }

        public IEnumerable<UserTicket> UserTicketList { get; set; }
        public IEnumerable<SelectListItem> DevList { get; set; }



    }
}
