using grpahqlsampl01.Models;

namespace grpahqlsampl01.IServices;

public interface IGroupService
{
    IQueryable<Group> GetAll();
}