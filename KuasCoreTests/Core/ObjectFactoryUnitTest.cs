using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using KuasCore.Models;
using KuasCore.Services.Impl;
using Core;
using Spring.Context;
using Spring.Context.Support;
using KuasCore.Services;

namespace KuasCoreTests.Core
{
    [TestClass]
    public class ObjectFactoryUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    //assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        [TestMethod]
        public void TestObjectFactory_GetApplicationContext()
        {

            // 利用 Spring Object Name 來依賴尋找找出我們要的 Spring Object.
            IApplicationContext applicationContext = ObjectFactory.GetApplicationContext();
            ICourseService courseService = (ICourseService)applicationContext["CourseService"];

            Course course = courseService.GetCourseById("001");
            Assert.IsNotNull(course);

            Console.WriteLine("編號為 = " + course.Course_ID);
            Console.WriteLine("名稱為 = " + course.Course_Name);
            Console.WriteLine("內容為 = " + course.Course_Description);

        }

        [TestMethod]
        public void TestObjectFactory_GetObject()
        {

            // 利用 Spring Object Name 來依賴尋找找出我們要的 Spring Object.
            ICourseService courseService = (ICourseService)ObjectFactory.GetObject("CourseService");

            Course course = courseService.GetCourseById("001");
            Assert.IsNotNull(empolyee);

            Console.WriteLine("編號為 = " + course.Course_ID);
            Console.WriteLine("名稱為 = " + course.Course_Name);
            Console.WriteLine("內容為 = " + course.Course_Description);
        }

    }
}
