using Framework.Application;

namespace ClinicManagement.Application.Contracts.Doctor
{
    public interface IDoctorApplication
    {
        Task<OperationResult> Create(CreateDoctor command); 
        Task<OperationResult> Edit(EditDoctor command);    
        Task<EditDoctor> GetDetails(int id);               
        Task<List<DoctorVM>> Search(DoctorSearchModel doctorSearch); 
        Task<List<DoctorVM>> GetDoctors();
    }
}
