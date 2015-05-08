using KuasCore.Models;
using KuasCore.Services;
using KuasCore.Services.Impl;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace KuasWebApp.Controllers
{
    public class CourseController : ApiController
    {

        public ICourseService CourseService { get; set; }

        [HttpPost]
        public Course AddCourse(Course Course)
        {
            CheckCourseIsNotNullThrowException(Course);

            try
            {
                CourseService.AddCourse(Course);
                return CourseService.GetCourseById(Course.Course_ID);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

       

       
        [HttpGet]
        public IList<Course> GetAllCourses()
        {
            return CourseService.GetAllCourses();
        }

        [HttpGet]
        [ActionName("byId")]
        public Course GetCourseById(string id)
        {
            var Course = CourseService.GetCourseById(id);

            if (Course == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Course;
        }

      
        private void CheckCourseIsNullThrowException(Course Course)
        {
            Course dbCourse = CourseService.GetCourseById(Course.Course_ID);

            if (dbCourse == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

      
        private void CheckCourseIsNotNullThrowException(Course Course)
        {
            Course dbCourse = CourseService.GetCourseById(Course.Course_ID);

            if (dbCourse != null)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }

    }

}
