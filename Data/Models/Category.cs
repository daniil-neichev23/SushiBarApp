using System;
using System.ComponentModel.DataAnnotations;

namespace SushiBarApp.Data.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
