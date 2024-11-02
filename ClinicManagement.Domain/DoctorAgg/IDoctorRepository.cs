using ClinicManagement.Application.Contracts.Doctor;
using Framework.Domain;
using System.Linq.Expressions;

namespace ClinicManagement.Domain.DoctorAgg
{
    public interface IDoctorRepository : IRepository<int, Doctor>
    {
                
        Task<Doctor> GetDetails(int id); 
        Task<List<DoctorVM>> GetDoctors(); 
        Task<List<DoctorVM>> Search(DoctorSearchModel searchModel);

    }
}
