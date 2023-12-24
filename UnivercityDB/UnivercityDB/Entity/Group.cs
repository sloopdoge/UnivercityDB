namespace UnivercityDB.Entity
{
    public class Group
    {
        public int GroupID { get; set; }
        public string GroupTitle { get; set; }
        public int FacultyID { get; set; }
        public int StudentsNumber { get; set; }
        public double AverageStudentsMark { get; set; }

        public virtual Faculty Faculty { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}
