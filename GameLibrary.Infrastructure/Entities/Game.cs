using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Core.Entities
{
    public class Game
    {
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
    }
}
