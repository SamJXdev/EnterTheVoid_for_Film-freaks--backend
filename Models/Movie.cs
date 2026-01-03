using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Film.Models
{
    public class Movie
    {
        [Key] 
        public int Id { get; set; } 

        [Required] 
        public string Title { get; set; } = null!; 

        [Required] 
        public int DirectorId { get; set; } 

        [ForeignKey(nameof(DirectorId))] 
        public Director Director { get; set; } = null!; 
        public string? Description { get; set; } 
        public string Genre { get; set; } = null!;
        public DateOnly Released_Year { get; set; }
        public List<MovieCast> Cast { get; set; } = new();
    }
}