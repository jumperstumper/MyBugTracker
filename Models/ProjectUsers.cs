using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication20.Models
{
    public class ProjectUsers
    {
        
        public string UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public int Project_Id { get; set; }

        public Project Project { get; set; }

       
    }
}
