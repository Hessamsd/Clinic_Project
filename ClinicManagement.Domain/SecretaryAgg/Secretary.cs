using ClinicManagement.Domain.DoctorSecretaryAgg;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Domain.SecretaryAgg
{
    public class Secretary
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [Phone]
        public string ContactNumber { get; set; }


        [ValidateNever]
        public virtual ICollection<DoctorSecretary> DoctorSecretaries { get; set; }

        public Secretary()
        {
            DoctorSecretaries = new HashSet<DoctorSecretary>();
        }

        public Secretary(string fullName, string contactNumber)
        {
            FullName = fullName;
            ContactNumber = contactNumber;
        }
    }
}
