using ITPE3200_Symptomizer.Models;
using ITPE3200_Symptomizer.Modules;
using Microsoft.EntityFrameworkCore;

namespace ITPE3200_Symptomizer.DAL
{
    //public class Patients
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Lastname { get; set; }
    //    public int Age { get; set; }
    //    public virtual List<Symptoms> Symptoms { get; set; }
    //    public virtual List<Diseases> Diseases { get; set; }
    //}
    //public class Symptoms
    //{
    //    public int Symptom_Id { get; set; }
    //    public string SymptomName { get; set; }
    //    public virtual List<Patient> Patients { get; set; }
    //    public virtual List<Diseases> Diseases { get; set; }
    //}
    //public class Diseases
    //{
    //    public int Id { get; set; }
    //    public string DiseaseName { get; set; }
    //    public virtual List<Symptoms> Symptoms { get; set; }
    //    public virtual List<Patients> Patients { get; set; } //for searching patient by disease (Not sure if will  require but just in case)
    //}
    public class PatientContext: DbContext
    {
        public PatientContext(DbContextOptions<PatientContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Symptom> Symptoms { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
