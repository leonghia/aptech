namespace SchoolMgt.Models;

public class Subject
{
    public int Id { get; set; }
    public string Roll { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Student> Students { get; set; }
    public List<Teacher> Teachers { get; set; }
}
