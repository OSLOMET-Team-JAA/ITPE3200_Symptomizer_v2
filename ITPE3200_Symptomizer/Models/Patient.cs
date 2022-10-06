using ITPE3200_Symptomizer.Models;
using System.Collections.Generic;
using System.Linq;

namespace ITPE3200_Symptomizer.Modules
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public virtual List<Symptom> SymptomList { get; set; }
        public virtual Disease Disease { get; set; }

     
    }
}
