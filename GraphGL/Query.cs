using grpahqlsampl01.IServices;
using grpahqlsampl01.Models;

namespace grpahqlsampl01.GraphGL;

public class Query
{
    private readonly IGroupService _groupService;
    private readonly IStudentService _studentService;

    public Query(IGroupService groupService, IStudentService studentService)
    {
        _groupService = groupService;
        _studentService = studentService;
    }

    [UsePaging(SchemaType = typeof(GroupType))]
    
    public IQueryable<Group> Groups => _groupService.GetAll();

    
    [UsePaging(SchemaType = typeof(StudentType))]
    
    public IQueryable<Student> Students => _studentService.GetAll();
}