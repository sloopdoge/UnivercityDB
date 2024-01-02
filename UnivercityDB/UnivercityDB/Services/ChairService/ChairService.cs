using Microsoft.EntityFrameworkCore;
using UnivercityDB.Data;
using UnivercityDB.Entities;

namespace UnivercityDB.Services.ChairService
{
    public class ChairService : IChairService
    {
        private readonly DataContext _context;

        public ChairService(DataContext context)
        {
            _context = context;
        }

        public async Task<Chair> CreateChair(Chair chair)
        {
            try
            {
                _context.Add(chair);
                await _context.SaveChangesAsync();

                return chair;

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

        public async Task<bool> DeleteChair(int chairId)
        {
            try
            {
                var dbChair = await _context.Chairs.FindAsync(chairId);

                if (dbChair == null)
                {
                    throw new Exception($"There is no chair with this ID: {chairId}");
                }

                _context.Remove(dbChair);
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

        public async Task<Chair> GetChair(int chairId)
        {
            try
            {
                var dbChair = await _context.Chairs.FindAsync(chairId);

                if (dbChair == null)
                {
                    throw new Exception($"There is no chair with this ID: {chairId}");
                }

                return dbChair;

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

        public async Task<List<Chair>> GetChairs()
        {
            try
            {
                return await _context.Chairs.ToListAsync();

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

        public async Task<Chair> UpdateChair(int chairId, Chair chair)
        {
            try
            {
                var dbChair = await _context.Chairs.FindAsync(chairId);

                if (dbChair == null)
                {
                    throw new Exception($"There is no chair with this ID: {chairId}");
                }

                dbChair.ChairName = chair.ChairName;

                await _context.SaveChangesAsync();
                return dbChair;

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
