using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment7.Controllers
{

    public class TrackBase
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; }

        [Required, StringLength(150)]
        public string Clerk { get; set; }

        [StringLength(150)]
        public string Composers { get; set; }

        [Required]
        public string Genre { get; set; }
    }

    public class TrackAdd : TrackBase
    {
      
    }

    public class TrackAddForm : TrackBase
    {
        public SelectList GenreList { get; set; }
    }

    public class TrackDetails : TrackBase
    {
        public TrackDetails()
        {
            Albums = new List<AlbumBase>();
        }

        [Display(Name = "List of Albums")]
        public ICollection<AlbumBase> Albums { get; set; }
    }
}