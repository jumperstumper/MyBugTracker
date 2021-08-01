using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication20.Models
{
    public class ApplicationUser : IdentityUser
    {

  
        [Required]
        public string Name { get; set; }
        [NotMapped]
        public string RoleId { get; set; }
        [NotMapped]
        public string Role { get; set; }


        public ICollection<ProjectUsers> ProjectUsers { get; set; }

        public List<Ticket> Tickets { get; set; }

        public ICollection<UserTicket> UserTicket { get; set; }



    }
}
