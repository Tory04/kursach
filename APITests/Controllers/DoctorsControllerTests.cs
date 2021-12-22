using Microsoft.VisualStudio.TestTools.UnitTesting;
using API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace API.Controllers.Tests
{
    [TestClass()]
    public class DoctorsControllerTests
    {
        [TestMethod()]
        public void GetDoctorsListTest()
        {
            //Arrange
            DoctorsController doctorsController = new DoctorsController();
            List<Doctor> doctorModels = new List<Doctor>();

            //Act
            doctorModels = doctorsController.GetDoctorsList();

            //Assert
            Assert.IsNotNull(doctorModels);
        }
    }
}