using Hopital.DataLayer.Context;
using Hopital.DataLayer.Entities;

namespace Hopital.DataLayer.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IReadDbContext<IHospitalEntity> readHospital;

        public PatientRepository(IReadDbContext<IHospitalEntity> readHospital)
        {
            this.readHospital = readHospital;
        }

        public Patient? Get(Guid id)
        {
            return readHospital.Get<Patient>()
                .FirstOrDefault(patient => patient.Id == id);
        }

        public IQueryable<Patient> Get()
        {
            return readHospital.Get<Patient>();
        }
    }
}
