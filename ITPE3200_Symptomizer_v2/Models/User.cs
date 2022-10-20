using System;
using System.ComponentModel.DataAnnotations;

namespace ITPE3200_Symptomizer.Models
{
    public class User
    {
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public String Username { get; set; }
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$")]
        public String Password { get; set; }
    }
}