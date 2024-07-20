using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ExtraTask.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; }
        [MaxLength(255)]
        public string FirstName { get; set; }
        [MaxLength(255)]
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Nationality { get; set; }
        [MaxLength(1000)]
        public string Photo { get; set; } // Path to the photo file

        [ForeignKey("Class")]
        public int ClassID { get; set; }
        public Classes Class { get; set; }


    }
}
