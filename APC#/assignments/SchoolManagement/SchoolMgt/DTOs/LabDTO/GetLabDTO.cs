using SchoolMgt.DTOs.StudentDTO;
using SchoolMgt.DTOs.TeacherDTO;

namespace SchoolMgt.DTOs.LabDTO;

public class GetLabDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<GetStudentDTO> Students { get; set; }
    public List<GetTeacherDTO> Teachers { get; set; }
}
