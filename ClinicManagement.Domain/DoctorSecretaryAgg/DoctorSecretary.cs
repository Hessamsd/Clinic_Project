using ClinicManagement.Domain.DoctorAgg;
using ClinicManagement.Domain.SecretaryAgg;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Domain.DoctorSecretaryAgg
{
    public class DoctorSecretary
    {
        [Key]
        [Column(Order = 0)]
        public int DoctorId { get; set; }


        [Key]
        [Column(Order = 1)]
        public int SecretaryId { get; set; }


        [ValidateNever]
        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }

        [ValidateNever]
        [ForeignKey("SecretaryId")]
        public virtual Secretary Secretary { get; set; }

    }
}
