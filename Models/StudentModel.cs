using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentsCourseDetails.Models
{
    public class StudentModel
    {
        private int _studentid;
        private string _studentName;
        private string _mailId;
        private int _courseID;
        private string _courseName;
        private int _attendance;
        private string _attendanceText;
        public int StudentId
        {
            get { return _studentid; }
            set { _studentid = value; }
        }

        public string StudentName
        {
            get { return _studentName; }
            set { _studentName = value; }
        }
        public string MailId
        {
            get { return _mailId; }
            set{ _mailId = value; }
        }
        public int CourseID
        {
            get{ return _courseID; }
            set { _courseID = value; }
        }
        public string CourseName
        {
            get { return _courseName; }
            set { _courseName = value; }
        }
        public int Attendance
        {
            get { return _attendance; }
            set { _attendance = value; }
        }
        public string AttendanceText
        {
            get { return _attendanceText; }
            set { _attendanceText = value; }
        }
    }
}
