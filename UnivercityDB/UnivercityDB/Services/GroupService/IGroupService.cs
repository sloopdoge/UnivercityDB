using UnivercityDB.Entities;

namespace UnivercityDB.Services.GroupService
{
    public interface IGroupService
    {
        Task<List<Group>> GetGroups();
        Task<Group?> GetGroup(int groupId);
        Task<Group?> CreateGroup(Group group);
        Task<Group?> UpdateGroup(int groupId, Group group);
        Task<bool> DeleteGroup(int groupId); 
    }
}
