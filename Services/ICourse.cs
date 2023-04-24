using StudentsCourseDetails.Models;

namespace StudentsCourseDetails.Services
{
    public interface ICourse
    {
        public List<CourseModel> GetAllCoursesdata();
        public CourseModel GetCourseData(int id);
        public bool UpdateCoursedata(int id, CourseModel objCourseData);
        public bool SaveCoursedata(CourseModel objCourseData);
        public bool DeletdCourse(int id);
    }
}
