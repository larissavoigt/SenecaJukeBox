using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment7.Controllers
{

    public class ArtistBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Birth Name")]
        public string BirthName { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        [Display(Name = "Birth or Start Date")]
        public DateTime BirthOrStartDate { get; set; }

        [Required, StringLength(150)]
        public string Executive { get; set; }

        [Required]
        [Display(Name = "Primary Genre")]
        public string Genre { get; set; }

        [Required, StringLength(150)]
        [Display(Name = "Name or Stage Name")]
        public string Name { get; set; }

        [Required, StringLength(150)]
        [Display(Name = "Artist Photo")]
        public string UrlArtist { get; set; }
    }
    public class ArtistAddForm
    {
        [Display(Name = "Birth Name")]
        public string BirthName { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        [Display(Name = "Birth or Start Date")]
        public DateTime BirthOrStartDate { get; set; }

        [Required, StringLength(150)]
        public string Executive { get; set; }

        [Required]
        [Display(Name = "Primary Genre")]
        public string Genre { get; set; }

        [Required, StringLength(150)]
        [Display(Name = "Name or Stage Name")]
        public string Name { get; set; }

        [Required, StringLength(150)]
        [Display(Name = "Artist Photo")]
        public string UrlArtist { get; set; }
    }

    public class ArtistAdd
    {
        public int Id { get; set; }

        public string BirthName { get; set; }

        public DateTime BirthOrStartDate { get; set; }

        public string Executive { get; set; }

        public string Genre { get; set; }

        public string Name { get; set; }

        public string UrlArtist { get; set; }
    }

    public class ArtistWithAlbums : ArtistBase
    {
        public ArtistWithAlbums()
        {
            Albums = new List<AlbumBase>();
        }

        [Display(Name = "List of Albums")]
        public ICollection<AlbumBase> Albums { get; set; }
    }

    // ############################################################

    // Attention - Edit albums for an artist
    // Send TO the HTML Form
    public class ArtistEditAlbumsForm
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Artist name")]
        public string Name { get; set; }

        // Attention - Multiple select requires a MultiSelectList object
        [Display(Name = "Albums")]
        public MultiSelectList AlbumList { get; set; }
    }

    // Data submitted by the browser user
    public class ArtistEditAlbums
    {
        public ArtistEditAlbums()
        {
            AlbumIds = new List<int>();
        }

        public int Id { get; set; }

        // Incoming collection of selected albums identifiers
        public IEnumerable<int> AlbumIds { get; set; }
    }
}