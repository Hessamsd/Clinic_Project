using ClinicManagement.Domain.AppointmentAgg;
using ClinicManagement.Domain.DoctorSecretaryAgg;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Domain.DoctorAgg
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(250)]
        public string Photo { get; set; }


        [Required]
        [MaxLength(100)]
        public string Specialty { get; set; }

        [Required]
        [RegularExpression(@"^\d{7}$", ErrorMessage = "The number is not correct.")]
        public string MedicalLicenseNumber { get; set; }


        [Required]
        [Phone]
        public string ClinicNumber { get; set; }

        [Required]
        [MaxLength(500)]
        public string Biography { get; set; }

        [ValidateNever]
        public virtual ICollection<DoctorSecretary> DoctorSecretaries { get; set; }

        [ValidateNever]
        public virtual ICollection<Appointment> Appointments { get; set; }

        public Doctor()
        {
            DoctorSecretaries = new HashSet<DoctorSecretary>();
            Appointments = new HashSet<Appointment>();
        }

        public Doctor(string fullName, string photo, string specialty,string city,
            string medicalLicenseNumber, string clinicNumber,
            string biography)
        {
            FullName = fullName;
            City = city;
            Photo = photo;
            Specialty = specialty;
            MedicalLicenseNumber = medicalLicenseNumber;
            ClinicNumber = clinicNumber;
            Biography = biography;
        }
    }
}
