using grpahqlsampl01.IServices;
using grpahqlsampl01.Models;
using HotChocolate.Resolvers;

namespace grpahqlsampl01.GraphGL;

public class StudentType : ObjectType<Student>
{
    protected override void Configure(IObjectTypeDescriptor<Student> descriptor)
    {
        descriptor.Field(x => x.StudentId).Type<IdType>();
        descriptor.Field(x => x.SName).Type<StringType>();
        descriptor.Field<GroupResolver>(x => x.GetGroup(default, default));
    }
}

public class GroupResolver
{
    private readonly IGroupService _groupService;

    public GroupResolver([Service] IGroupService groupService)
    {
        _groupService = groupService;
        
    }

    public Group GetGroup(Student student, IResolverContext ctx)
    {
        return _groupService.GetAll().FirstOrDefault(x => x.GroupId == student.GroupId);
    } 
}