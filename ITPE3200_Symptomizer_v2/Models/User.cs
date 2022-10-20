using System.ComponentModel.DataAnnotations;

namespace ITPE3200_Symptomizer.Models
{
    public class User
    {
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20a}$")]
        public string Username { get; set; }
        [RegularExpression(@"^(?=.*[a-zA-ZæøåÆØÅ])(?=.*\d)[a-zA_ZæøåÆØÅ\d](?=.*[!#$%&? ]){6,}$")]
        public string Password { get; set; }
    }
}