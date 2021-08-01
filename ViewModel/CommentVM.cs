using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication20.Models;

namespace WebApplication20.ViewModel
{
    public class CommentVM
    {

        public Ticket Ticket { get; set; }
        public int Ticket_Id { get; set; }
        public IEnumerable<Comments> Comments { get; set; }
        public Comments Comment { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }

     





        //AddDeveloperVM
        public string UserId { get; set; }
        public UserTicket UserTicket { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
      


        public IEnumerable<UserTicket> UserTicketList { get; set; }
        public IEnumerable<SelectListItem> DevList { get; set; }

        //

    }
}
