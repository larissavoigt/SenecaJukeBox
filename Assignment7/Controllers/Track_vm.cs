using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment7.Controllers
{
    public class TrackAddForm
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; }

        public string Clerk { get; set; }

        [StringLength(150)]
        public string Composers { get; set; }

        [Required]
        public string Genre { get; set; }
    }

    public class TrackAdd
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Clerk { get; set; }

        public string Composers { get; set; }

        public string Genre { get; set; }
    }
}