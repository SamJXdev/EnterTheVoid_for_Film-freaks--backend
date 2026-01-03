using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Film.Models
{
    public class MovieCast
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;

        [Required]
        public int CastId { get; set; }
        public Person Cast { get; set; } = null!;

        [Required, MaxLength(50)]
        public string RoleName { get; set; } = null!;
    }
}