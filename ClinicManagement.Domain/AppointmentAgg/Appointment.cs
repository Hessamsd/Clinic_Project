using ClinicManagement.Domain.DoctorAgg;
using ClinicManagement.Domain.PatientAgg;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Domain.AppointmentAgg
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        [Required]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        private bool _isCurrentlyAvailable;

        [Required]
        public bool IsAvailable => AppointmentDate > DateTime.Now && _isCurrentlyAvailable;


        [ValidateNever]
        public virtual Patient Patient { get; set; }

        [ValidateNever]
        public virtual Doctor Doctor { get; set; }

        public Appointment(int doctorId, int patientId, DateTime appointmentDate)
        {
            if (appointmentDate <= DateTime.Now)
                throw new ArgumentException("Please select the correct date");

            DoctorId = doctorId;
            PatientId = patientId;
            AppointmentDate = appointmentDate;
            _isCurrentlyAvailable = true;

        }


        public void MarkAsUnavailable()
        {
            _isCurrentlyAvailable = false;
        }


        public void UpdateAppointmentDate(DateTime newDate)
        {
            if (newDate <= DateTime.Now)
                throw new ArgumentException("Please select the correct date and time");

            AppointmentDate = newDate;

            _isCurrentlyAvailable = true;

        }
    }
}
