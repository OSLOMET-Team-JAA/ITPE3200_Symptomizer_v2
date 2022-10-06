using ITPE3200_Symptomizer.Modules;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITPE3200_Symptomizer.DAL
{
    public interface IPatientRepository
    {
        Task<bool> AddPatient(Patient p);
        Task<List<Patient>> FindAll();
        Task<bool> DeletePatient(int id);
        Task<Patient> FindOne(int id);
        Task<bool> EditPatient(Patient eP);
    }
}
