using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment7.Controllers
{
    public class AlbumAddForm
    {
        [Key]
        public int Id { get; set; }

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

        public string Coordinator { get; set; }

        public string Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string UrlAlbum { get; set; }
    }
}