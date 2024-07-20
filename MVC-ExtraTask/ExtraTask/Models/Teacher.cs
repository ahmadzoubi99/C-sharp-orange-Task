using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtraTask.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherID { get; set; }
        [MaxLength(100)]
        public string Username { get; set; }
        [MaxLength(20)]

        public string Password { get; set; } // Store hashed passwords
        [MaxLength(255)]
        public string FullName { get; set; }

    }
}
