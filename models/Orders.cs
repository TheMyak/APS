using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool ShoppingCart { get; set; }
        public string? Address { get; set; }
        public string? Status { get; set; }
        public string? PaymentMethod { get; set; }
        
        public User? User { get; set; }
    }
}