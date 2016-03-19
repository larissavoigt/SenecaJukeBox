using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment7.Controllers
{
    public class AlbumBase
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(150)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required, StringLength(150)]
        [Display(Name = "Executive")]
        public string Coordinator { get; set; }

        [Required]
        public string Genre { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required, StringLength(150)]
        [Display(Name = "Album Cover")]
        public string UrlAlbum { get; set; }
    }

    public class AlbumAddForm
    {
        [Required, StringLength(150)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required, StringLength(150)]
        [Display(Name = "Executive")]
        public string Coordinator { get; set; }

        [Required]
        public string Genre { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required, StringLength(150)]
        [Display(Name = "Album Cover")]
        public string UrlAlbum { get; set; }
    }

    public class AlbumAdd
    {
        public int Id { get; set; }

        [Required, StringLength(150)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public string Coordinator { get; set; }

        public string Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string UrlAlbum { get; set; }
    }

    public class AlbumWithArtists : AlbumBase
    {
        public AlbumWithArtists()
        {
            Artists = new List<ArtistBase>();
        }

        [Display(Name = "Artists with this album")]
        public IEnumerable<ArtistBase> Artists { get; set; }
    }

    // Send TO the HTML Form
    public class AlbumEditArtistsForm
    {
        public int Id { get; set; }

        [Required, StringLength(150)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required, StringLength(150)]
        [Display(Name = "Executive")]
        public string Coordinator { get; set; }

        [Required]
        public string Genre { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required, StringLength(150)]
        [Display(Name = "Album Cover")]
        public string UrlAlbum { get; set; }

        // Attention - Multiple select requires a MultiSelectList object
        [Display(Name = "Artist List")]
        public MultiSelectList ArtistList { get; set; }
    }

    // Data submitted by the browser user
    public class AlbumEditArtists
    {
        public AlbumEditArtists()
        {
            ArtistIds = new List<int>();
        }

        public int Id { get; set; }

        // Incoming collection of selected Artist identifiers
        public IEnumerable<int> ArtistIds { get; set; }
    }
}