using UnivercityDB.Entities;

namespace UnivercityDB.Services.FacultyService
{
    public interface IFacultyService
    {
        Task<List<Faculty>> GetFaculties();
        Task<Faculty?> GetFaculty(int facultyId);
        Task<Faculty?> CreateFaculty(Faculty faculty);
        Task<Faculty?> UpdateFaculty(int facultyId, Faculty faculty);
        Task<bool> DeleteFaculty(int facultyId); 
    }
}
