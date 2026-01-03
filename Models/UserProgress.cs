using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Film.Models
{
    public class UserProgress
    {
        [Key]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;
        public int Exp { get; set; }
        public int Level { get; set; }

        [Required]
        public int CharacterId { get; set; }
        public Character Character { get; set; } = null!;
    }
}