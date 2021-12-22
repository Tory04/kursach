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
    public class PatientsControllerTests
    {
        [TestMethod()]
        public void GetPatientsTest()
        {
            //Arrange
            PatientsController patientsController = new PatientsController();
            List<Patient> patientModels = new List<Patient>();

            //Act
            patientModels = patientsController.GetPatients();

            //Assert
            Assert.IsNotNull(patientModels);
        }
    }
}