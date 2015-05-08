using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using System.Collections.Generic;

namespace KuasCore.Services.Impl
{
    public class CourseService : ICourseService
    {

        public ICourseDao CourseDao { get; set; }

        public void AddCourse(Course Course)
        {
            CourseDao.AddCourse(Course);
        }


        public IList<Course> GetAllCourses()
        {
            return CourseDao.GetAllCourses();
        }

        public Course GetCourseByName(string name)
        {
            return CourseDao.GetCourseByName(name);
        }

        public Course GetCourseById(string id)
        {
            return CourseDao.GetCourseById(id);
        }

    }

}
