using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using iMedOneDB.Models;
using Patient.API.Services;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace Patient.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_AllowSpecificOrigins")]
    public class PatientsController : ControllerBase
    {
        IPatientService _service;
        public PatientsController(IPatientService service)
        {
            _service = service;
        }
        [HttpPost]
        [DisableCors]
        [EnableCors("_AllowSpecificOrigins")]
        public void Post([FromBody] TBLPATIENT value)
        {
            if (_service.SavePatient(value))
            {
                Ok("Data saved");
            }
            else
            {
                throw new ArgumentException("Data not saved for value :"+value.Name+value.SurName);
            }
        }

        [HttpGet]
        [EnableQuery]
        [EnableCors("_AllowSpecificOrigins")]
        public IEnumerable<TBLPATIENT> Get()
        {
           return _service.GetPatients();
        }
    }
}