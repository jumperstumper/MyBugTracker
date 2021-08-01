using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication20.Models
{
    public class Comments
    {
        [Key]
        public int Comment_Id { get; set; }
        [Required]
        public string Message { get; set; }
        public DateTime Created { get; set; }

        [ForeignKey("Ticket")]
        public int Ticket_Id { get; set; }
        public Ticket Ticket { get; set; }
    }
}
