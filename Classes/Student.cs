using StudentsCourseDetails.Models;
using StudentsCourseDetails.Services;
using System.Text.Json;

namespace StudentsCourseDetails.Classes
{
    public class Student : IStudent
    {
        const string Path = @"C:\Students.json";
        public List<StudentModel> objexistingdata;
        public bool SaveStudent(StudentModel objStudent)
        {
            objexistingdata = GetAllStudentsdata();
            try
            {
                objexistingdata.Add(objStudent);
                string json = JsonSerializer.Serialize(objexistingdata);
                File.WriteAllText(Path, json);
                return true;
            }
            catch (Exception e)
            {
                throw e;
                return false;
            }
        }
        public List<StudentModel> GetAllStudentsdata()
        {
            string json;
            using (var streamReader = new StreamReader(Path))
            {
                json = streamReader.ReadToEnd();
            }
            var objStudentsdata = JsonSerializer.Deserialize<List<StudentModel>>(json);
            return objStudentsdata;
        }
        public StudentModel GetStudentData(int id)
        {
            List<StudentModel> objexistingdata = GetAllStudentsdata();
            StudentModel student = objexistingdata.Where(e => e.StudentId == id).FirstOrDefault();
            return student;
        }
        public bool UpdateStudent(int id, StudentModel objStudent)
        {
            try
            {
                objexistingdata = GetAllStudentsdata();

                if (objexistingdata.Any(w => w.StudentId == id))
                {
                    var item = objexistingdata.FirstOrDefault(x => x.StudentId == objStudent.StudentId);
                    item.StudentId = objStudent.StudentId;
                    item.StudentName = objStudent.StudentName;
                    item.CourseID = objStudent.CourseID;
                    item.CourseName = objStudent.CourseName;
                    item.MailId= objStudent.MailId;
                    item.Attendance = objStudent.Attendance;
                    item.AttendanceText = objStudent.AttendanceText;
                }
               
                string json = JsonSerializer.Serialize(objexistingdata);
                File.WriteAllText(Path, json);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeletdStudent(int id)
        {
            objexistingdata = GetAllStudentsdata();
            try
            {               
                var studentItem = objexistingdata.SingleOrDefault(st => st.StudentId == id);
                if (studentItem.StudentId != 0)
                {
                    objexistingdata.Remove(studentItem);
                }
                string json = JsonSerializer.Serialize(objexistingdata);
                File.WriteAllText(Path, json);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
