﻿using System;
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
        [Display(Name = "Coordinator")]
        public string Coordinator { get; set; }

        [Required]
        public string Genre { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required, StringLength(150)]
        [Display(Name = "Album Cover")]
        public string UrlAlbum { get; set; }
    }


    public class AlbumWithDetail : AlbumBase
    {
        public AlbumWithDetail()
        {
            Artists = new List<ArtistBase>();
            Tracks = new List<TrackBase>();
        }

        [Display(Name = "Artists")]
        public IEnumerable<ArtistBase> Artists { get; set; }

        [Display(Name = "Tracks")]
        public IEnumerable<TrackBase> Tracks { get; set; }
    }

   
    public class AlbumAdd : AlbumBase
    {
        public AlbumAdd()
        {
            ArtistIds = new List<int>();
            TrackIds = new List<int>();
        }

        public IEnumerable<int> ArtistIds { get; set; }

        public IEnumerable<int> TrackIds { get; set; }
    }

    public class AlbumAddForm : AlbumBase
    {

        [Display(Name = "Artist List")]
        public MultiSelectList ArtistList { get; set; }

        [Display(Name = "Track List")]
        public MultiSelectList TrackList { get; set; }

        public SelectList GenreList { get; set; }
    }

}