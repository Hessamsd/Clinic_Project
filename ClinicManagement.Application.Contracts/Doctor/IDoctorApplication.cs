using Framework.Application;

namespace ClinicManagement.Application.Contracts.Doctor
{
    public interface IDoctorApplication
    {
        OperationResult Create(CreateDoctor command);
        OperationResult Edit(EditDoctor command);
        EditDoctor GetDetails(int id);
        List<DoctorVM> Search(DoctorSearchModel doctorSearch);
        List<DoctorVM> GetDoctors();
    }
}
