using StudentsCourseDetails.Models;

namespace StudentsCourseDetails.Services
{
    public interface IStudent
    {
        public bool SaveStudent(StudentModel objStudent);
        public List<StudentModel> GetAllStudentsdata();
        public StudentModel GetStudentData(int id);
        public bool UpdateStudent(int id, StudentModel objStudent);
        public bool DeletdStudent(int id);
    }
}
