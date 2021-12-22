﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Entities;

namespace Data.Reposirories.Tests
{
    [TestClass()]
    public class DoctorsRepositoryTests
    {
        [TestMethod()]
        public void GetDoctorsTest()
        {
            //Arrange
            DoctorsRepository doctorsRepository = new DoctorsRepository();
            List<Doctor> doctorEntities = new List<Doctor>();

            //Act
            doctorEntities = doctorsRepository.GetDoctors();

            //Assert
            Assert.IsNotNull(doctorEntities);
        }
    }
}