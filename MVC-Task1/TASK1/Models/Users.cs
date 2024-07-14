using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TASK1.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }  // 'Manager' or 'Employee'

        public int? EmployeeID { get; set; }

        [ForeignKey("EmployeeID")]
        public Employees Employee { get; set; }

    }
}
