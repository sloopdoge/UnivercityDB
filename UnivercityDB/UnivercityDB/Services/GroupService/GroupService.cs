using Microsoft.EntityFrameworkCore;
using UnivercityDB.Data;
using UnivercityDB.Entities;

namespace UnivercityDB.Services.GroupService
{
    public class GroupService : IGroupService
    {
        private readonly DataContext _context;

        public GroupService(DataContext context)
        {
            _context = context;
        }

        public async Task<Group?> CreateGroup(Group group)
        {
            try
            {
                _context.Add(group);
                await _context.SaveChangesAsync();

                return group;
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

        public async Task<bool> DeleteGroup(int groupId)
        {
            try
            {
                var dbGroup = await _context.Groups.FindAsync(groupId);

                if (dbGroup == null)
                {
                    throw new Exception($"There is no group with this ID: {groupId}");
                }

                _context.Remove(dbGroup);
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

        public async Task<Group?> GetGroup(int groupId)
        {
            try
            {
                var dbGroup = await _context.Groups.FindAsync(groupId);

                if (dbGroup == null)
                {
                    throw new Exception($"There is no group with this ID: {groupId}");
                }

                return dbGroup;
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

        public async Task<List<Group>> GetGroups()
        {
            try
            {
                return await _context.Groups.ToListAsync();
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

        public async Task<Group?> UpdateGroup(int groupId, Group group)
        {
            try
            {
                var dbGroup = await _context.Groups.FindAsync(groupId);

                if (dbGroup == null)
                {
                    throw new Exception($"There is no group with this ID: {groupId}");
                }

                dbGroup.FacultyID = group.FacultyID;
                dbGroup.Title = group.Title;

                await _context.SaveChangesAsync();

                return dbGroup;
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
