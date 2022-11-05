namespace grpahqlsampl01.Excep;

public class StudentNotFoundException : Exception
{
    public int StudentID { get; internal set; }
}