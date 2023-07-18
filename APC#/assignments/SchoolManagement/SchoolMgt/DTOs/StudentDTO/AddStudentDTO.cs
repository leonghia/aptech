using SchoolMgt.DTOs.LabDTO;

namespace SchoolMgt.DTOs.StudentDTO;

public class AddStudentDTO
{
    public string Name { get; set; }
    public string Roll { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int LabId { get; set; }
    
}
