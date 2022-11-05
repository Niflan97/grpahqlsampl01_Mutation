using grpahqlsampl01.IServices;
using grpahqlsampl01.Models;

namespace grpahqlsampl01.GraphGL;

public class Mutation
{
    private readonly IStudentService _studentService;

    public Mutation(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public Student CreateStudents(CreateStudent inputStudent)
    {
        return _studentService.Create(inputStudent);
    }

    public Student DeleteStudents(DeleteStudent inputStudent)
    {
        return _studentService.Delete(inputStudent);
    }
}