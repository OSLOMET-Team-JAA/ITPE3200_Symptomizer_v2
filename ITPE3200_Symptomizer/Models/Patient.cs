
namespace ITPE3200_Symptomizer.Modules
{
    public class Patient
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Symptoms { get; set; } //We will hold our symptoms as string
        public string Disease { get; set; }
    }
}
