namespace SchoolMgt.Models;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Roll { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public List<Lab> Labs { get; set; }
    public List<Student> Students { get; set; }
    public List<Subject> Subjects { get; set; }
}
