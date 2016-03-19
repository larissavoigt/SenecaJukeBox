using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment7.Controllers
{
    public class GenreAddForm
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; }
    }

    public class GenreAdd
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}