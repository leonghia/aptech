using SchoolMgt.DTOs.LabDTO;
using SchoolMgt.DTOs.SubjectDTO;
using SchoolMgt.DTOs.TeacherDTO;

namespace SchoolMgt.DTOs.StudentDTO;

public class GetStudentDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Roll { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int LabId { get; set; }
    public GetLabDTO Lab { get; set; }
    public List<GetSubjectDTO> Subjects { get; set; }
    public List<GetTeacherDTO> Teachers { get; set; }
}
