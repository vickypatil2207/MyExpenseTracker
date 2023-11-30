using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenseTracker.Models
{
    public class Bank
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(5)]
        public string? Acrynonym { get; set; }

        [StringLength(20)]
        public string? Type { get; set; }
    }
}
