using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsCourseDetails.Classes;
using StudentsCourseDetails.Models;
using StudentsCourseDetails.Services;

namespace StudentsCourseDetails.Controllers
{
    public class CoursesController : Controller
    {
        protected ICourse ObjCourse;
        // GET: CoursesController
        public ActionResult Index()
        {
            ObjCourse = new Course();
            IList<CourseModel> data = ObjCourse.GetAllCoursesdata();
            if (data.Count > 0)
            {
                return View("Index",data);
            }
            else
            {
                return View("Create");
            }
           
        }

        // GET: CoursesController/Details/5
        public ActionResult Details(int id)
        {
            ObjCourse = new Course();
            var objStudent = ObjCourse.GetCourseData(id);
            return PartialView("CourseDetails", objStudent);
        }

        // GET: CoursesController/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Save([FromBody] CourseModel objCourse)
        {
            if (objCourse != null)
            {
                ObjCourse = new Course();
                if (ObjCourse.SaveCoursedata(objCourse))
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
            ObjCourse = new Course();
            var objCourse = ObjCourse.GetCourseData(id);
            return PartialView(objCourse);
        }


        public ActionResult Update(int id, [FromBody] CourseModel objCourse)
        {
            if(objCourse != null)
            {
                id = objCourse.CourseID;
                ObjCourse = new Course();
                if (ObjCourse.UpdateCoursedata(id, objCourse))
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
                ObjCourse = new Course();
                if (ObjCourse.DeletdCourse(id))
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
