namespace ClinicManagement.Application.Contracts.Doctor
{
    public class DoctorVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string Photo { get; set; }
        public string Specialty { get; set; }
        public string MedicalLicenseNumber { get; set; }
        public string ClinicNumber { get; set; }
        public string Biography { get; set; }
    }
}
