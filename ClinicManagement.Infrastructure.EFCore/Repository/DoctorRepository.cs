using ClinicManagement.Application.Contracts.Doctor;
using ClinicManagement.Domain.DoctorAgg;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Infrastructure.EFCore.Repository
{
    public class DoctorRepository : RepositoryBase<int, Doctor>, IDoctorRepository
    {
        private readonly ClinicContext _context;

        public DoctorRepository(ClinicContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Doctor> GetDetails(int id)
        {
            return await _context.Doctors
             .Include(d => d.Specialty)
             .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<DoctorVM>> GetDoctors()
        {
            return await _context.Doctors
            .Select(d => new DoctorVM
            {
                Id = d.Id,
                FullName = d.FullName,
                Specialty = d.Specialty != null ? d.Specialty : string.Empty
            }).ToListAsync();
        }

        public async Task<List<DoctorVM>> Search(DoctorSearchModel searchModel)
        {
            var query = _context.Doctors.AsQueryable();

            if (!string.IsNullOrEmpty(searchModel.FullName))
            {
                query = query.Where(d => d.FullName.Contains(searchModel.FullName));
            }

            return await query.Select(d => new DoctorVM
            {
                Id = d.Id,
                FullName = d.FullName,
                Specialty = d.Specialty != null ? d.Specialty : string.Empty
            }).ToListAsync();
        }
    }
}
