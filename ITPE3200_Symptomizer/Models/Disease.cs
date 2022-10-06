using ITPE3200_Symptomizer.Modules;
using System.Collections.Generic;

namespace ITPE3200_Symptomizer.Models
{
    public class Disease
    {
        public int Id { get; set; }
        public string DiseaseName { get; set; }
        public virtual List<Symptom> Symptoms { get; set; }
        public virtual List<Patient> Patients { get; set; }
    }
}
