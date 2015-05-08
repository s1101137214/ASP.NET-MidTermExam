using KuasCore.Models;
using System;
using System.Collections.Generic;

namespace KuasCore.Dao
{
    public interface ICourseDao
    {

        void AddCourse(Course Course);

        IList<Course> GetAllCourses();

        Course GetCourseByName(string name);

        Course GetCourseById(string id);

    }
}
