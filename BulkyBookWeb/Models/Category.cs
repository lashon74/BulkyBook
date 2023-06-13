using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        //Creating table and all columns needed 
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 150, ErrorMessage = "Display Order must be between 1 and 150!")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
