using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExtraTask.Models
{
    public class Classes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassID { get; set; }
        public string ClassName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
