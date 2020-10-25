using iMedOneDB.Models;
using NUnit.Framework;
using Patient.API.Services;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class PatientServiceTest
    {
        IPatientService service;
        [SetUp]
        public void Setup()
        {
            service = new MockService();

        }

        [Test]
        public void TestGetCities()
        {
            var oo = service.GetCities();
            Assert.NotNull(oo);
        }

        [Test]
        public void TestGetPatients()
        {
            var oo = service.GetPatients();
            Assert.NotNull(oo);
        }
        [Test]
        public void TestGetState()
        {
            var oo = service.GetStates();
            Assert.NotNull(oo);
        }

        [Test]
        public void TestSavePatients()
        {
            TBLPATIENT dt = new TBLPATIENT();
            dt.Name = "james";
            dt.SurName = "bond";
            dt.Gender = "M";
            dt.DOB = new System.DateTime(1980, 12, 9);
            var oo = service.SavePatient(dt);
            foreach (var item in service.GetPatients())
            {
                if (dt.Name == "james")
                {
                    Assert.AreSame(dt, item);
                }
                
            }
            
            Assert.IsTrue(oo);
            
        }
    }
}