using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TASK1.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackID { get; set; }

        public string Email { get; set; }

        public string FeedbackText { get; set; }

        public DateTime ReceivedDate { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employees Employees { get; set; }

    }
}
