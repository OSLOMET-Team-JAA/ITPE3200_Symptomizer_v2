using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITPE3200_Symptomizer.DAL
{
    public class Patients
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public virtual Diseases Disease { get; set; }
    }

    public class Diseases
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Symptoms { get; set; }
        public string DiseaseName { get; set; }
        public virtual List<Patients> Patients { get; set; }
    }

    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
    }

    public class PatientContext : DbContext
    {
        public PatientContext(DbContextOptions<PatientContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Diseases> Diseases { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}