using grpahqlsampl01.IServices;
using grpahqlsampl01.Models;
using HotChocolate.Resolvers;

namespace grpahqlsampl01.GraphGL;

public class GroupType : ObjectType<Group>
{
    protected override void Configure(IObjectTypeDescriptor<Group> descriptor)
    {
        descriptor.Field(x => x.GroupId).Type<IdType>();
        descriptor.Field(x => x.GName).Type<StringType>();
        descriptor.Field(x => x.ShortName).Type<StringType>();

        descriptor.Field<StudentResolver>(x => x.GetStudents(default, default));
    }
}

public class StudentResolver
{
    private readonly IStudentService _studentService;

    public StudentResolver([Service] IStudentService studentService)
    {
        _studentService = studentService;
    }

    public IEnumerable<Student> GetStudents(Group? group, IResolverContext? ctx)
    {
        return _studentService.GetAll().Where(x => group != null && x.GroupId == group.GroupId);
    }

}