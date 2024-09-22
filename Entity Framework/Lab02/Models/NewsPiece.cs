using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTi_day_15_lab.Models
{
    public class NewsPiece
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Brief { get; set; }
        public string? Description { get; set; }

        public TimeSpan? Time { get; set; } = TimeSpan.Zero;
        public DateOnly? Date { get; set; } = new DateOnly();

        public int CategoryId { get; set; }
        public int AuthorId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Author? Author { get; set; }
    }
}
