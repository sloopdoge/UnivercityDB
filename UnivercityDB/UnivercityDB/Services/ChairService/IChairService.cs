using UnivercityDB.Entities;

namespace UnivercityDB.Services.ChairService
{
    public interface IChairService
    {
        public Task<Chair> GetChair(int chairId);
        public Task<Chair> CreateChair(Chair chair);
        public Task<Chair> UpdateChair(int chairId, Chair chair);
        public Task<bool> DeleteChair(int chairId);
        public Task<List<Chair>> GetChairs();
    }
}
