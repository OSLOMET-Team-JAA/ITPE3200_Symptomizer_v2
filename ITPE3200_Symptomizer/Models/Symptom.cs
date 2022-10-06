using ITPE3200_Symptomizer.Modules;
using System.Collections.Generic;

namespace ITPE3200_Symptomizer.Models
{
    public class Symptom
    {
        public int Symptom_Id { get; set; }
        public string SymptomName { get; set; }
        public virtual List<Patient> Patient { get; set; }
        public virtual List<Disease> Diseases { get; set; }
    }
}
