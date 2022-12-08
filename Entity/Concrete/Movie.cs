using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Movie : IEntity
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieContent { get; set; }
        public string BlogThumbnailImage { get; set; }
        public string MovieImage { get; set; }
        public DateTime MovieCreateDate { get; set; }
        public bool MovieStatus { get; set; }
        public double MovieRate { get; set; }
        public int ReleaseYear { get; set; }
        public int RunnigTime { get; set; }
        public string MovieCountry { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public int WriterId { get; set; }

        public Writer Writer { get; set; }

        public List<Comment> Comments { get; set; }

    }

}
