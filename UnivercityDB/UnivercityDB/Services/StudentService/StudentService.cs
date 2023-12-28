using Microsoft.EntityFrameworkCore;
using UnivercityDB.Components.Pages;
using UnivercityDB.Data;
using UnivercityDB.Entities;

namespace UnivercityDB.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _context;

        public StudentService(DataContext context)
        {
            _context = context;
        }

        public async Task<Student?> CreateStudent(Student student)
        {
            try
            {
                _context.Add(student);
                await _context.SaveChangesAsync();

                return student;
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

        public async Task<bool> DeleteStudent(int studentId)
        {
            try
            {
                var dbStudent = await _context.Students.FindAsync(studentId);

                if (dbStudent == null)
                {
                    throw new Exception($"There is no student with this ID: {studentId}");
                }

                _context.Remove(dbStudent);
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

        public async Task<Student?> GetStudent(int studentId)
        {
            try
            {
                var dbStudent = await _context.Students.FindAsync(studentId);

                if (dbStudent == null)
                {
                    throw new Exception($"There is no student with this ID: {studentId}");
                }

                return dbStudent;
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

        public Task<List<Student>> GetStudents()
        {
            try
            {
                return _context.Students.ToListAsync();
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

        public async Task<Student?> UpdateStudent(int studentId, Student student)
        {
            try
            {
                var dbStudent = await _context.Students.FindAsync(studentId);

                if (dbStudent == null)
                {
                    throw new Exception($"There is no student with this ID: {studentId}");
                }

                dbStudent.LastName = student.LastName;
                dbStudent.FirstName = student.FirstName;
                dbStudent.FacultyID = student.FacultyID;
                dbStudent.GroupID = student.GroupID;
                dbStudent.AverageMark = student.AverageMark;

                await _context.SaveChangesAsync();

                return dbStudent;
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
