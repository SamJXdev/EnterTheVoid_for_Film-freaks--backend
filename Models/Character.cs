using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Film.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int MinLevel { get; set; }
        public int MaxLevel { get; set; }
    }
}