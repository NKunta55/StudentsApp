using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsCourseDetails.Classes;
using StudentsCourseDetails.Controllers;
using StudentsCourseDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsCourseDetails.Controllers.Tests
{
   
    public class StudentTest
    {
        [Test]
        public void DetailsTest()
        {
            var controller = new StudentController();
            var result = controller.Details(1) as PartialViewResult;
            var student = (StudentModel)result.ViewData.Model;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Narender", student.StudentName);
        }
        [Test]
        public void UpdateStudentTest()
        {
            var student = new Student();
        }
    }
}