﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ValuesController : ControllerBase
    {
        IPatientService _service;
        public ValuesController(IPatientService service)
        {
            _service = service;
        }
        // GET api/values
        [HttpGet]
        [EnableQuery]
        [Route("States")]
        [EnableCors("_AllowSpecificOrigins")]
       
        public IEnumerable<Tblstate> GetStates()
        {
            return _service.GetStates();
        }

        [HttpGet]
        [EnableQuery]
        [Route("Cities")]
        [EnableCors("_AllowSpecificOrigins")]
        public IEnumerable<Tblcity> GetCities()
        {
            return _service.GetCities();
        }

        
    }
}
