using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task2_MVC.Models
{
    public class Categories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }


        [NotMapped]
        public IFormFile? ImageFile { get; set; }


        [Required]
        [StringLength(25)]
        public string CategoryName { get; set; }

        public string CategoryImage { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
