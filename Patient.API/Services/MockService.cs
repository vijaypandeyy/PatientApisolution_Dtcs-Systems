using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iMedOneDB.Models;

namespace Patient.API.Services
{
    public class MockService : IPatientService
    {
        List<TBLPATIENT> Patients = new List<TBLPATIENT>();
        List<Tblcity> Cities = new List<Tblcity>();
        List<Tblstate> states = new List<Tblstate>();
        public MockService()
        {
            Patients.Add(new TBLPATIENT() { Name = "vijay", SurName = "Pandey", DOB = new DateTime(1994, 5, 7), CityId = 1, Gender = "Male" });
            Cities.Add(new Tblcity() { Id=1,Name="Mumbai", StateId =1});
            Cities.Add(new Tblcity() { Id = 2, Name = "Pune", StateId = 1 });
            Cities.Add(new Tblcity() { Id = 3, Name = "Surat", StateId = 2 });
            states.Add(new Tblstate() { Id = 1, Name = "MH" });
            states.Add(new Tblstate() { Id = 2, Name = "GJ" });
        }
        public IEnumerable<Tblcity> GetCities()
        {
            return Cities;
        }

       

        public IEnumerable<TBLPATIENT> GetPatients()
        {
            return Patients;
        }

        public IEnumerable<Tblstate> GetStates()
        {
            return states;
        }

        public bool SavePatient(TBLPATIENT tBLPATIENT)
        {
            if (Patients.Any(x => x.Name == tBLPATIENT.Name && x.SurName == tBLPATIENT.SurName))
            {
                throw new Exception("Records Exists");
            }
            Patients.Add(tBLPATIENT);
            return true;
        }
    }
}
