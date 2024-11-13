using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}