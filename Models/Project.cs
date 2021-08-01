using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication20.Models
{
    public class Project
    {
        [Key]
        public int Project_Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime Created { get; set; }

        List<Ticket> Tickets { get; set; }

        public ICollection<ProjectUsers> ProjectUsers { get; set; }
    }
}
