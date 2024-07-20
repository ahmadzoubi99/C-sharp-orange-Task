using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExtraTask.Models
{
    public class Assessment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssessmentID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public Student Student { get; set; }

        public string Commitment { get; set; } // Excellent, Very Good, etc.

        public string AcademicPerformance { get; set; } // Excellent, Very Good, etc.

        public int AbsentDays { get; set; }

        public string Comments { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
    }
}
