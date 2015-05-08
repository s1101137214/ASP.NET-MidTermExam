
using KuasCore.Dao.Base;
using KuasCore.Dao.Mapper;
using KuasCore.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System.Collections.Generic;
using System.Data;

namespace KuasCore.Dao.Impl
{
    public class CourseDao : GenericDao<Course>, ICourseDao
    {
       
        override protected IRowMapper<Course> GetRowMapper()
        {
            return new CourseRowMapper();
        }

        public void AddCourse(Course Course)
        {
            string command = @"INSERT INTO Course (Course_ID, Course_Name, Course_Description) VALUES (@Id, @Name, @Des);";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = Course.Course_ID;
            parameters.Add("Name", DbType.String).Value = Course.Course_Name;
            parameters.Add("Des", DbType.String).Value = Course.Course_Description;

            ExecuteNonQuery(command, parameters);
        }

        public IList<Course> GetAllCourses()
        {
            string command = @"SELECT * FROM Course ORDER BY Id ASC";
            IList<Course> Course = ExecuteQueryWithRowMapper(command);
            return Course;
        }

        public Course GetCourseByName(string name)
        {
            string command = @"SELECT * FROM Course WHERE Course_Name = @name";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("name", DbType.String).Value = name;

            IList<Course> Course = ExecuteQueryWithRowMapper(command, parameters);
            if (Course.Count > 0)
            {
                return Course[0];
            }

            return null;
        }
        public Course GetCourseById(string id)
        {
            string command = @"SELECT * FROM Course WHERE Course_ID = @Id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Id", DbType.String).Value = id;

            IList<Course> Course = ExecuteQueryWithRowMapper(command, parameters);
            if (Course.Count > 0)
            {
                return Course[0];
            }

            return null;
        }
     
    }
}
