using ClinicManagement.Domain.AppointmentAgg;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Domain.PatientAgg
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        public int Age { get; set; }


        [Required]
        [Phone]
        public string ContactNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }


        [ValidateNever]
        public virtual ICollection<Appointment> Appointments { get; set; }


        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public Patient(string fullName, int age, string contactNumber,
            string city, string description)
        {
            FullName = fullName;
            Age = age;
            ContactNumber = contactNumber;
            City = city;
            Description = description;
        }
    }
}
