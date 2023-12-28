using System.ComponentModel.DataAnnotations;

namespace UnivercityDB.Entities
{
    public class Group
    {
        public int GroupID { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Faculty is required")]
        public int FacultyID { get; set; }
        public int? StudentsNumber { get; set; }
        public double? AverageStudentsMark { get; set; }

        public virtual Faculty Faculty { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}
