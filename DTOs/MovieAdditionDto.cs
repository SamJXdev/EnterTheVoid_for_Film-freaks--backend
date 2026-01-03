using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Film.Models;

namespace Film.DTOs
{
    public class MovieAdditionDto
    {
        public string Title { get; set; } = null!;
        public string Year { get; set; } = null!;
        public int DirectorId { get; set; }
        public List<int> CastIds = new();
        public string Genre { get; set; } = null!;
    }
}