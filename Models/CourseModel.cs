namespace StudentsCourseDetails.Models
{
    public class CourseModel
    {
        private int _courseID;
        private string _courseName;
        private string _courseYear;
        public int CourseID
        {
            get { return _courseID; }
            set { _courseID = value; }
        }
        public string CourseName
        {
            get { return _courseName; }
            set { _courseName = value; }
        }
        public string CourseYear
        {
            get { return _courseYear; }
            set { _courseYear = value; }
        }

    }
}
