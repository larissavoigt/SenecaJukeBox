﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment7.Models
{
    // Attention - 11 - Add your design model classes below

    // Follow these rules or conventions:

    // To ease other coding tasks, the name of the 
    //   integer identifier property should be "Id"
    // Collection properties (including navigation properties) 
    //   must be of type ICollection<T>
    // Valid data annotations are pretty much limited to [Required] and [StringLength(n)]
    // Required to-one navigation properties must include the [Required] attribute
    // Do NOT configure scalar properties (e.g. int, double) with the [Required] attribute
    // Initialize DateTime and collection properties in a default constructor

    public class Artist
    {

        public Artist()
        {
            BirthOrStartDate = DateTime.Now;
            Albums = new List<Album>();
        }

        public int Id { get; set; }

        public string BirthName { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime BirthOrStartDate { get; set; }

        public string Executive { get; set; }

        public string Genre { get; set; }

        public string Name { get; set; }

        public string UrlArtist { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }

    public class Album
    {

        public Album()
        {
            ReleaseDate = DateTime.Now;
            Artists = new List<Artist>();
            Tracks = new List<Track>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Coordinator { get; set; }

        public string Genre { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime ReleaseDate { get; set; }

        public string UrlAlbum { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }

    public class Track
    {

        public Track()
        {
            Albums = new List<Album>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Clerk { get; set; }

        public string Composers { get; set; }

        public string Genre { get; set; }

        public string YoutubeId { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

    }

    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
