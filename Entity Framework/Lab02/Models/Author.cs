using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTi_day_15_lab.Models
{
    public class Author
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DateTime? JoinedAt { get; set; } = DateTime.Now;

        public virtual List<NewsPiece>? NewsPieces { get; set; }
    }
}
