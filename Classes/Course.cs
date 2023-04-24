using StudentsCourseDetails.Models;
using StudentsCourseDetails.Services;
using System.Text.Json;
namespace StudentsCourseDetails.Classes
{
    public class Course: ICourse
    {
        const string Path = @"C:\Courses.json";
        private List<CourseModel> objexistingdata;

        public List<CourseModel> GetAllCoursesdata()
        {
            string json;
            using (var streamReader = new StreamReader(Path))
            {
                json = streamReader.ReadToEnd();
            }
            var objCoursedata = JsonSerializer.Deserialize<List<CourseModel>>(json);
            return objCoursedata;
        }

        public CourseModel GetCourseData(int id)
        {
            List<CourseModel> objdata = GetAllCoursesdata();
            CourseModel student = objdata.Where(e => e.CourseID == id).FirstOrDefault();
            return student;
        }

        public bool SaveCoursedata(CourseModel objCourseData)
        {
            objexistingdata = GetAllCoursesdata();
            try
            {
                objexistingdata.Add(objCourseData);
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
        public bool UpdateCoursedata(int id, CourseModel objCourseData)
        {
            try
            {
                objexistingdata = GetAllCoursesdata();

                if (objexistingdata.Any(w => w.CourseID == id))
                {
                    var item = objexistingdata.FirstOrDefault(x => x.CourseID == objCourseData.CourseID);
                    item.CourseID = objCourseData.CourseID;
                    item.CourseName = objCourseData.CourseName;
                    item.CourseYear = objCourseData.CourseYear;
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
        public bool DeletdCourse(int id)
        {
            objexistingdata = GetAllCoursesdata();
            try
            {
                var deleteItem = objexistingdata.SingleOrDefault(st => st.CourseID == id);
                if (deleteItem.CourseID != 0)
                {
                    objexistingdata.Remove(deleteItem);
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
