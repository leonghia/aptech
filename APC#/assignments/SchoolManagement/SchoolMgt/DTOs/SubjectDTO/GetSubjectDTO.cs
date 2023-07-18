using SchoolMgt.DTOs.StudentDTO;
using SchoolMgt.DTOs.TeacherDTO;

namespace SchoolMgt.DTOs.SubjectDTO;

public class GetSubjectDTO
{
    public int Id { get; set; }
    public string Roll { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<GetStudentDTO> Students { get; set; }
    public List<GetTeacherDTO> Teachers { get; set; }
}
