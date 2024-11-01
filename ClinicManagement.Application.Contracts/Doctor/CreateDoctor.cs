using Framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Application.Contracts.Doctor
{
    public class CreateDoctor
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string FullName { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string City { get; set; }

        [Required(ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile Photo { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Specialty { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MedicalLicenseNumber { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ClinicNumber { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Biography { get; set; }

    }
}
