using SchoolMgt.DTOs.LabDTO;
using SchoolMgt.DTOs.StudentDTO;
using SchoolMgt.DTOs.SubjectDTO;

namespace SchoolMgt.DTOs.TeacherDTO;

public class GetTeacherDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Roll { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public List<GetLabDTO> Labs { get; set; }
    public List<GetStudentDTO> Students { get; set; }
    public List<GetSubjectDTO> Subjects { get; set; }
}
