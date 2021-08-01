using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication20.Models
{
    public class UserTicket
    {
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int Ticket_Id { get; set; }
        public Ticket Ticket { get; set; }

        //public int Project_id { get; set; }


    }
}
