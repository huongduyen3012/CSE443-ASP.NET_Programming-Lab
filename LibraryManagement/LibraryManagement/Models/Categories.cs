using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        [Required, StringLength(200)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public string? Avatar { get; set; }
    }
}
