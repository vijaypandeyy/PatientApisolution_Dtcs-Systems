
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iMedOneDB;
using iMedOneDB.Models;

namespace Patient.API.Services
{
    public class PatientService : IPatientService
    {
        public IEnumerable<Tblcity> GetCities()
        {
            return DBContext.GetData<Tblcity>();
        }

      
        public IEnumerable<TBLPATIENT> GetPatients()
        {
            return DBContext.GetData<TBLPATIENT>();
        }

        public IEnumerable<Tblstate> GetStates()
        {
            return DBContext.GetData<Tblstate>();
        }

        public bool SavePatient(TBLPATIENT tBLPATIENT)
        {
            var aa = new List<TBLPATIENT>();
            aa.Add(tBLPATIENT);
            if (GetPatients().Any(x => x.Gender == tBLPATIENT.Gender && x.Name == tBLPATIENT.Name &&
            x.SurName == tBLPATIENT.SurName && x.DOB == tBLPATIENT.DOB ))
            {
                throw new Exception("Record already Exists");
            }
          return  DBContext.SaveAll<TBLPATIENT>(aa);
        }
    }

    public interface IPatientService
    {
        IEnumerable<TBLPATIENT> GetPatients();
        IEnumerable<Tblstate> GetStates();
        IEnumerable<Tblcity> GetCities();

        bool SavePatient(TBLPATIENT tBLPATIENT);

    }
}
