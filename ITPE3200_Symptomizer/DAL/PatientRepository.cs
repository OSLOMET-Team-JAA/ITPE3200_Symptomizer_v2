using ITPE3200_Symptomizer.Modules;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITPE3200_Symptomizer.DAL
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientContext _db;
        public PatientRepository(PatientContext db)
        {
            _db = db;
        }

        public async Task<bool> AddPatient(Patient p)
        {
            try
            {
                var newPatient = new Patients
                {
                    Firstname = p.Firstname,
                    Lastname = p.Lastname,
                };
                var findSymptoms = await _db.Diseases.FindAsync(p.Symptoms);
                if (findSymptoms == null)
                {
                    var newDisease = new Diseases
                    {
                        Symptoms = p.Symptoms,
                        DiseaseName = p.Disease
                    };
                    newPatient.Disease = newDisease;
                }
                else
                {
                    newPatient.Disease = findSymptoms;
                }
                _db.Patients.Add(newPatient);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<Patient>> FindAll()
        {
            try
            {
                List<Patient> patients = await _db.Patients.Select(p => new Patient
                {
                    Id = p.Id,
                    Firstname = p.Firstname,
                    Lastname = p.Lastname,
                    Symptoms = p.Disease.Symptoms,
                    Disease = p.Disease.DiseaseName,
                }).ToListAsync();
                return patients;
            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> DeletePatient(int id)
        {
            try
            {
                Patients patient = await _db.Patients.FindAsync(id);
                _db.Patients.Remove(patient);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<Patient> FindPatient(int id)
        {
            Patients patient = await _db.Patients.FindAsync(id);
            var foundPatient = new Patient()
            {
                Id = patient.Id,
                Firstname = patient.Firstname,
                Lastname = patient.Lastname,
                Symptoms = patient.Disease.Symptoms,
                Disease = patient.Disease.DiseaseName
            };
            return foundPatient;
        }

        public async Task<bool> EditPatient(Patient eP)
        {
            try
            {
                var editPatient = await _db.Patients.FindAsync(eP.Id);
                if (editPatient.Disease.Symptoms != eP.Symptoms)
                {
                    var findSimptoms = _db.Diseases.Find(eP.Symptoms);
                    if (findSimptoms == null)
                    {
                        var newDisease = new Diseases()
                        {
                            Symptoms = eP.Symptoms,
                            DiseaseName = eP.Disease
                        };
                        editPatient.Disease = newDisease;
                    }
                    else
                    {
                        editPatient.Disease.Symptoms = eP.Symptoms;
                    }
                }
                editPatient.Firstname = eP.Firstname;
                editPatient.Lastname = eP.Lastname;
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
            //return true;
        }
    }
}
