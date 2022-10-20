using ITPE3200_Symptomizer.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITPE3200_Symptomizer.Models;

namespace ITPE3200_Symptomizer.Controllers
{
    [Route("[controller]/[action]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _db;

        public PatientController(IPatientRepository db)
        {
            _db = db;
        }

        public async Task<bool> AddPatient(Patient p)
        {
            return await _db.AddPatient(p);
        }

        public async Task<List<Patient>> FindAll()
        {
            return await _db.FindAll();
        }

        public async Task<bool> DeletePatient(int id)
        {
            return await _db.DeletePatient(id);
        }

        public async Task<Patient> FindPatient(int id)
        {
            return await _db.FindPatient(id);
        }

        public async Task<bool> EditPatient(Patient eP)
        {
            return await _db.EditPatient(eP);
        }
    }
}
