using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        [Required]
        public string Title { get; set; }
        public string Edition { get; set; }
    }
}