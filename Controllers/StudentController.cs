using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsCourseDetails.Classes;
using StudentsCourseDetails.Models;
using StudentsCourseDetails.Services;

namespace StudentsCourseDetails.Controllers
{
    public class StudentController : Controller
    {
        protected IStudent ObjStudent;
        
        public ActionResult Index()
        {
            ObjStudent = new Student();
            IList<StudentModel> objStudents = ObjStudent.GetAllStudentsdata();
            if (objStudents.Count > 0)
            {
                return View(objStudents);
            }
            else
            {
                return View("Create");
            }
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            ObjStudent = new Student();
            var objStudent = ObjStudent.GetStudentData(id);
            return PartialView("StudentDetails", objStudent);
        }

        public ActionResult Create()
        {
            return PartialView();
        }


        [HttpPost]
        public ActionResult Save([FromBody] StudentModel objStudent)
        {

            if (objStudent != null)
            {
                ObjStudent = new Student();
                var atype = (AttendacneType)objStudent.Attendance;
                objStudent.AttendanceText = atype.ToString();
                if (ObjStudent.SaveStudent(objStudent))
                {
                    return Json(new
                    {
                        msg = "Success"
                    }); ;
                }
                return Json(new { msg = "failed" });
            }
            else
            {
                return Json(new { msg = "failed" });
            }
        }

        public ActionResult Edit(int id)
        {
            ObjStudent = new Student();
            var objStudent = ObjStudent.GetStudentData(id);
            return PartialView(objStudent);
        }

       
        public ActionResult Update([FromBody] StudentModel objstudent)
        {
            if (objstudent != null)
            {
                int id = objstudent.StudentId;
                ObjStudent = new Student();
                var atype = (AttendacneType)objstudent.Attendance;
                objstudent.AttendanceText = atype.ToString();
                if (ObjStudent.UpdateStudent(id, objstudent))
                {
                    return Json(new
                    {
                        msg = "Success"
                    });
                }
                else
                {
                    return Json(new { msg = "failed" });

                }
            }
            else
            {
                return Json(new { msg = "failed" });
            }
        }

        public ActionResult Delete(int id)
        {
            if (id != 0)
            {
                ObjStudent = new Student();
                if (ObjStudent.DeletdStudent(id))
                {
                    return Json(new
                    {
                        msg = "Success"
                    });
                }
                else
                {
                    return Json(new { msg = "failed" });

                }
            }
            else
            {
                return Json(new { msg = "failed" });
            }
        }      
    }
}
