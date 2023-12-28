using System.ComponentModel.DataAnnotations;

namespace UnivercityDB.Entities
{
    public class Student
    {
        public int StudentID { get; set; }
        public DateOnly CreateDate { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Firstname is required")]
        public string FirstName { get; set; }
        public int? FacultyID{ get; set; }
        public int? GroupID { get; set; }
        public double? AverageMark { get; set; }

        public virtual Faculty Faculty { get; set; }
        public virtual Group Group { get; set; }
    }
}
