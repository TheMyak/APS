using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string? Title { get; set; }

        public DateTime PublicationDate { get; set; }

        [MaxLength(50)]
        public string? ISBN { get; set; }

        public int NumberPages { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public string? Summary { get; set; }

        public string? Lang { get; set; }

        public int GenreId { get; set; }

        public int PublisherId { get; set; }
    }
}