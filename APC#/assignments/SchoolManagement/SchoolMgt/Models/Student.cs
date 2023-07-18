namespace SchoolMgt.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Roll { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int LabId { get; set; }
    public Lab Lab { get; set; }
    public List<Subject> Subjects { get; set; }
    public List<Teacher> Teachers { get; set; }
}
