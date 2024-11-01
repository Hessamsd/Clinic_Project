using ClinicManagement.Application.Contracts.Doctor;
using Framework.Domain;

namespace ClinicManagement.Domain.DoctorAgg
{
    public interface IDoctorRepository : IRepository<int, Doctor>
    {
        Doctor GetDetails(int id);                        
        List<DoctorVM> Search(DoctorSearchModel searchModel); 
        List<DoctorVM> GetDoctors();

    }
}
