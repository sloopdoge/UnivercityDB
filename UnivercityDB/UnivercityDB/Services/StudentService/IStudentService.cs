using UnivercityDB.Entities;

namespace UnivercityDB.Services.StudentService
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudents();
        Task<Student?> GetStudent(int studentId);
        Task<Student?> CreateStudent(Student student);
        Task<Student?> UpdateStudent(int studentId, Student student);
        Task<bool> DeleteStudent(int studentId);
    }
}
