using ITPE3200_Symptomizer.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ITPE3200_Symptomizer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ITPE3200_Symptomizer.Controllers
{
    [Route("[controller]/[action]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _db;
        private ILogger<PatientController> _log;
        private const string _loggedIn = "loggedIn";

        public PatientController(IPatientRepository db, ILogger<PatientController> log)
        {
            _db = db;
            _log = log;
        }
        public async Task<ActionResult> AddPatient(Patient p)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggedIn)))
            {
                return Unauthorized();
            }
            if (ModelState.IsValid)
            {
                bool returnOk = await _db.AddPatient(p);
                if (!returnOk)
                {
                    _log.LogInformation("Patient was not created");
                    return BadRequest("Patient was not created");
                }

                return Ok("Patient was created");
            }
            _log.LogInformation("Inputs' validation is failed");
            return BadRequest("Inputs' validation is failed");
        }

        public async Task<ActionResult> FindAll()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggedIn)))
            {
                return Unauthorized();
            }
            List<Patient> allPatients = await _db.FindAll(); 
            //We can also use "var allPatients" instead of List<> (List<> usage not required)
            return Ok(allPatients);
        }

        public async Task<ActionResult> DeletePatient(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggedIn)))
            {
                return Unauthorized();
            }
            bool returnOk = await _db.DeletePatient(id);
            if (!returnOk)
            {
                _log.LogInformation("Patient was not deleted");
                return NotFound("Customer was not deleted");
            }
            return Ok("Customer was deleted");
        }

        public async Task<ActionResult> FindPatient(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggedIn)))
            {
                return Unauthorized();
            }
            Patient foundPatient = await _db.FindPatient(id);
            if(foundPatient == null)
            {
                _log.LogInformation("Patient was not found");
                return NotFound("Customer was not found");
            }
            return Ok(foundPatient);
        }
        public async Task<ActionResult> EditPatient(Patient eP)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggedIn)))
            {
                return Unauthorized();
            }
            if (ModelState.IsValid)
            {
                bool returnOk = await _db.EditPatient(eP);
                if (!returnOk)
                {
                    _log.LogInformation("Patient's info was not changed");
                    return BadRequest("Patient's info was not changed");
                }
                return Ok("Patient's info was changed");
            }
            _log.LogInformation("Input's validation failed");
            return BadRequest("Inputs' validation failed");
        }

        public async Task<ActionResult> LoggIn(User user)
        {
            if (ModelState.IsValid)
            {
                bool returnOk = await _db.LoggIn(user);
                if (!returnOk)
                {
                    _log.LogInformation("Failed to logg in with user name {user.Username}", user.Username);
                    HttpContext.Session.SetString(_loggedIn,"");
                    return Ok(false);
                }
                HttpContext.Session.SetString(_loggedIn, "loggedIn");
                return Ok(true);
            }
            _log.LogInformation("Fail in input validation");
            return BadRequest("Fail in input validation on server side");
        }
        public void LoggOut()
        {
            HttpContext.Session.SetString(_loggedIn,"");
        }
    }
}
