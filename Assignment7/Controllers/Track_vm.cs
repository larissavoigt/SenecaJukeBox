using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment7.Controllers
{

    public class TrackAdd
    {
        [Required, StringLength(150)]
        public string Name { get; set; }

        [Required, StringLength(150)]
        public string Clerk { get; set; }

        [StringLength(150)]
        public string Composers { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Videoclip")]
        public string YoutubeId { get; set; }
    }

    public class TrackBase : TrackAdd
    {
        [Key]
        public int Id { get; set; }
    }


    public class TrackAddForm : TrackAdd
    {
        public SelectList GenreList { get; set; }
    }

    public class TrackEdit : TrackAdd
    {
        [Key]
        public int Id { get }
    }

    public class TrackEditForm : TrackEdit
    {
        public SelectList GenreList { get; set; }
    }

    public class TrackWithDetail : TrackBase
    {
        public TrackWithDetail()
        {
            Albums = new List<AlbumBase>();
        }

        [Display(Name = "Albums with this Track")]
        public ICollection<AlbumBase> Albums { get; set; }
    }
}