using KuasCore.Dao;
using KuasCore.Models;
using System.Collections.Generic;

namespace KuasCore.Services
{
    public interface ICourseService
    {

        void AddCourse(Course Course);

        IList<Course> GetAllCourses();

        Course GetCourseByName(string name);

        Course GetCourseById(string id);
    }
}
