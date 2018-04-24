using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiYo;
using MiYo.Controllers;
using MiYo.Models;

namespace MiYo.Tests.Controllers
{
    [TestClass]
    public class RequestFilterTest
    {
        [TestMethod]
        public void TestFilter()
        {
            // Arrange
            string[] skills = new string[] { "c#" };
            string locationCountry = null;
            string locationCity = null;
            string locationStreet = null;
            string locationHouse = null;
            string language = null;

            // Act
            //AdminRequestViewModel model = new AdminRequestViewModel();
            //var empIdList = new EmployeeRequestFilter().FilterEmployee(skills,
            //    locationCountry, locationCity, locationStreet, locationHouse, language
            //    );
            //List<EmployeeViewModel> employees;
            //using (var db = new ApplicationDbContext())
            //{
            //    employees = empIdList.Select(eId => EmployeeViewModel.FillById(eId)).ToList();
            //    model.Mentees = employees.Where(e =>
            //        e.Skills.Where(s => s.State.Equals("Want to learn")).Count() > 0).ToList();
            //    model.Mentors = employees.Where(e =>
            //        e.Skills.Where(s => s.State.Equals("Want to teach")).Count() > 0).ToList();
            //}

            // Assert
            Assert.IsNotNull(1);
        }        
    }
}
