using grpahqlsampl01.Excep;
using grpahqlsampl01.IServices;
using grpahqlsampl01.Models;

namespace grpahqlsampl01.Service;

public class StudentService : IStudentService
{
    private IList<Student> _students;

    public StudentService()
    {
        _students = new List<Student>()
        {
            new Student() {StudentId = 1, SName = "Raja", GroupId = 1},
            new Student() {StudentId = 2, SName = "John", GroupId = 2},
            new Student() {StudentId = 3, SName = "kamal", GroupId = 3},
            new Student() {StudentId = 4, SName = "Sana", GroupId = 2},
            new Student() {StudentId = 5, SName = "Vick", GroupId = 1},
            new Student() {StudentId = 6, SName = "Michel", GroupId = 1},
                
        };
    }

    public IQueryable<Student> GetAll()
    {
        return _students.AsQueryable();
    }

    public Student Create(CreateStudent inputStudent)
    {
        var student = new Student()
        {
            StudentId = _students.Max(x => x.StudentId) + 1,
            SName = inputStudent.SName,
            GroupId  = inputStudent.GroupId
        };
        
        _students.Add(student);

        return student;
    }


    public Student Delete(DeleteStudent inputStudent)
    {
        var student = _students.FirstOrDefault(x => x.StudentId == inputStudent.StudentID);
        if (student == null) throw new StudentNotFoundException() { StudentID = inputStudent.StudentID };
        _students.Remove(student);
        return student;
    }
}