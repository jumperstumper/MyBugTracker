using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication20.Models
{
    public class TicketVM
    {

        public Project Project { get; set; }

        public Ticket Ticket { get; set; }

        public Ticket Ticket_Id { get; set; }

        public IEnumerable<SelectListItem> ProjectList { get; set; }
        public IEnumerable<SelectListItem> StatusList { get; set; }
        public IEnumerable<SelectListItem> TicketTypeList { get; set; }
        public IEnumerable<SelectListItem> TicketPrioList { get; set; }


        public string TicketStatus { get; set; }


    }
}
