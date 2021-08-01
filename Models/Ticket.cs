using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication20.Models
{
    public class Ticket
    {
        [Key]
        public int Ticket_Id { get; set; }
        [Required]
        [Display(Name = " ")]
        public string TicketName { get; set; }
     
        [Display(Name = " ")]
        public string TicketDescription { get; set; }
    
        [Display(Name = " ")]
        public DateTime TicketCreated { get; set; }
    
        [Display(Name = "")]
        public string TicketPriority { get; set; }
     
        [Display(Name = "")]
        public string TicketType { get; set; }
 
        [Display(Name = "")]
        public string TicketStatus { get; set; }
       
        List<Comments> Comments { get; set; }


        [ForeignKey("Project")]
        public int Project_Id { get; set; }
        public Project Project { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<UserTicket> UserTicket { get; set; }





    }




}

