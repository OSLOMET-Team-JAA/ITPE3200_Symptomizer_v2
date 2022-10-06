using ITPE3200_Symptomizer.Models;
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
                var findPatient = await _db.Patients.FindAsync(p.Id);
                    if(findPatient == null)
                    {
                        var newPatient = new Patient()
                        {
                            Name = p.Name,
                            Lastname = p.Lastname,
                            SymptomList = p.SymptomList,
                            Disease = p.Disease
                        };
                        _db.Patients.Add(newPatient);
                        await _db.SaveChangesAsync();                        
                    }                   
                    return true;                                                       
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeletePatient(int id)
        {
            try
            {
                Patient patient = await _db.Patients.FindAsync(id);
                _db.Patients.Remove(patient);
                await _db.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
            
        }

        public async Task<bool> EditPatient(Patient eP)
        {
            try
            {
                var editPatient = await _db.Patients.FindAsync(eP.Id);
                if(editPatient.SymptomList != eP.SymptomList)
                {
                    var findDisease = _db.Diseases.Find(eP.Disease);
                    if(findDisease == null) 
                    {
                        var newDisease = new Disease() //Probably in this body to be integrated searching in database by given symptoms but not creation of new disease
                        {
                            Id = eP.Id,
                            DiseaseName = eP.Disease.ToString(),
                            Symptoms = eP.SymptomList,
                        };
                        editPatient.Disease = newDisease;
                    }
                    else
                    {
                        editPatient.SymptomList = eP.SymptomList;
                    }

                }
            }
            catch
            {

                return false;
            }
            return true;
        }

        public async Task<List<Patient>> FindAll()
        {
            try
            {               
                List<Patient> AllPatients = await _db.Patients.Select(p => new Patient
                {
                    Id = p.Id,
                    Name = p.Name,
                    Lastname = p.Lastname,
                    SymptomList = p.SymptomList,
                    Disease = p.Disease
                }).ToListAsync();

                return AllPatients;
            }
            catch 
            {
                return null;
            }
        }

        public async Task<Patient> FindOne(int id)
        {
            Patient patient = await _db.Patients.FindAsync(id);
            var foundPatient = new Patient()
            {
                Id = patient.Id,
                Lastname = patient.Lastname,
                SymptomList = patient.SymptomList,
                Disease = patient.Disease
            };
            return foundPatient;

        }
    }
}
