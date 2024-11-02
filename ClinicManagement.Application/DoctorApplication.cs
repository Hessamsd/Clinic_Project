using _0_Framework.Application;
using ClinicManagement.Application.Contracts.Doctor;
using ClinicManagement.Domain.DoctorAgg;
using Framework.Application;

namespace ClinicManagement.Application
{
    public class DoctorApplication : IDoctorApplication
    {

        private readonly IDoctorRepository _doctorRepository;

        public DoctorApplication(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<OperationResult> Create(CreateDoctor command)
        {

            var operation = new OperationResult();

            if (await _doctorRepository.Exists(x => x.FullName == command.FullName))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var doctor = new Doctor(command.FullName, command.Photo.FileName,   
                command.Specialty, command.MedicalLicenseNumber, command.ClinicNumber, command.Biography);

            await _doctorRepository.Add(doctor);
            await _doctorRepository.SaveChangesAsync();
            return operation.Succedded();
        }

        public async Task<OperationResult> Edit(EditDoctor command)
        {
            var operation = new OperationResult();

            var doctor = await _doctorRepository.GetById(command.Id);
            if (doctor == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (await _doctorRepository.Exists(x => x.FullName == command.FullName && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);


            doctor.FullName = command.FullName;
            doctor.City = command.City;
            doctor.Specialty = command.Specialty;
            doctor.MedicalLicenseNumber = command.MedicalLicenseNumber;
            doctor.ClinicNumber = command.ClinicNumber;
            doctor.Biography = command.Biography;


            await _doctorRepository.Update(doctor);
            return operation.Succedded();
        }

        public async Task<EditDoctor> GetDetails(int id)
        {
            var operation = new OperationResult();

            var doctor = await _doctorRepository.GetDetails(id);
            if (doctor == null)
                throw new Exception(ApplicationMessage.RecordNotFound);


            return new EditDoctor
            {
                Id = doctor.Id,
                FullName = doctor.FullName,
                City = doctor.City,
                Specialty = doctor.Specialty,
                MedicalLicenseNumber = doctor.MedicalLicenseNumber,
                ClinicNumber = doctor.ClinicNumber,
                Biography = doctor.Biography
            };
        }

        public async Task<List<DoctorVM>> GetDoctors()
        {
            return await _doctorRepository.GetDoctors();
        }

        public async Task<List<DoctorVM>> Search(DoctorSearchModel doctorSearch)
        {
            return await _doctorRepository.Search(doctorSearch);
        }
    }
}
