namespace SchoolMgt.Models;

public class Lab
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Student> Students { get; set; }
    public List<Teacher> Teachers { get; set; }
}
