using grpahqlsampl01.IServices;
using grpahqlsampl01.Models;

namespace grpahqlsampl01.Service;

public class GroupService : IGroupService
{
    private IList<Group> _groups;

    public GroupService()
    {
        _groups = new List<Group>()
        {
            new Group() {GroupId = 1, GName = "Technology", ShortName = "Tech"},
            new Group() {GroupId = 2, GName = "Science", ShortName = "SC"},
            new Group() {GroupId = 3, GName = "Mathematics", ShortName = "Maths"}
        };
    }
    
    public IQueryable<Group> GetAll()
    {
        return _groups.AsQueryable();
    }
}