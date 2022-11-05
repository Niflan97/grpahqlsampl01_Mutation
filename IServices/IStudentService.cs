using grpahqlsampl01.Models;

namespace grpahqlsampl01.IServices;

public interface IStudentService
{
    IQueryable<Student> GetAll();

    Student Create(CreateStudent inputStudent);
    Student Delete(DeleteStudent inputStudent);
}