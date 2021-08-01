using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication20.Models
{
    public class UserProject
    {
        [Key]
        public int UserProject_Id { get; set; }

        public int Project_Id { get; set; }
        public Project Project { get; set; }

      
        public Ticket Ticket{ get; set; }
        List<Ticket> Tickets { get; set; }
    }
}
