using KuasCore.Models;
using Spring.Data.Generic;
using System.Data;

namespace KuasCore.Dao.Mapper
{
    class CourseRowMapper : IRowMapper<Course>
    {
        public Course MapRow(IDataReader dataReader, int rowNum)
        {
            Course target = new Course();

            target.Course_ID = dataReader.GetString(dataReader.GetOrdinal("Id"));
            target.Course_Name = dataReader.GetString(dataReader.GetOrdinal("Name"));
            target.Course_Description = dataReader.GetString(dataReader.GetOrdinal("Des"));

            return target;
        }

    }
}
