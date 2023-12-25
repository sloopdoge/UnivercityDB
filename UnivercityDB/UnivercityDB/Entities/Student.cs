namespace UnivercityDB.Entities
{
    public class Student
    {
        public int StudentID { get; set; }
        public DateOnly CreateDate { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int? FacultyID{ get; set; }
        public int? GroupID { get; set; }
        public double? AverageMark { get; set; }

        public virtual Faculty Faculty { get; set; }
        public virtual Group Group { get; set; }
    }
}
