using Microsoft.EntityFrameworkCore;
using UnivercityDB.Data;
using UnivercityDB.Entities;

namespace UnivercityDB.Services.FacultyService
{
    public class FacultyService : IFacultyService
    {
        private readonly DataContext _context;

        public FacultyService(DataContext context)
        {
            _context = context;
        }   

        public async Task<Faculty?> CreateFaculty(Faculty faculty)
        {
            try
            {
                _context.Add(faculty);
                await _context.SaveChangesAsync();

                return faculty;

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"An error occurred while updating the database: {ex.Message}");
                return null;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteFaculty(int facultyId)
        {
            try
            {
                var dbFaculty = await _context.Faculties.FindAsync(facultyId);

                if(dbFaculty == null) 
                {
                    throw new Exception($"There is no faculty with this ID: {facultyId}");
                }

                _context.Remove(dbFaculty);
                await _context.SaveChangesAsync();

                return true;

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"An error occurred while updating the database: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public async Task<List<Faculty>> GetFaculties()
        {
            try
            {
                return await _context.Faculties.ToListAsync();

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"An error occurred while updating the database: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<Faculty?> GetFaculty(int facultyId)
        {
            try
            {
                var dbFaculty = await _context.Faculties.FindAsync(facultyId);

                if(dbFaculty == null)
                {
                    throw new Exception($"There is no faculty with this ID: {facultyId}");
                }

                return dbFaculty;

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"An error occurred while updating the database: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<Faculty?> UpdateFaculty(int facultyId, Faculty faculty)
        {
            try
            {
                var dbFaculty = await _context.Faculties.FindAsync(facultyId);

                if( dbFaculty == null )
                {
                    throw new Exception($"There is no faculty with this ID: {facultyId}");
                }

                dbFaculty.Title = faculty.Title;
                dbFaculty.Note = faculty.Note;

                await _context.SaveChangesAsync();
                return dbFaculty;

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"An error occurred while updating the database: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
    }
}
