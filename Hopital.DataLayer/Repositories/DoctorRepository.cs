using Hopital.DataLayer.Context;
using Hopital.DataLayer.Entities;

namespace Hopital.DataLayer.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IReadDbContext<IHospitalEntity> readHospital;

        public DoctorRepository(IReadDbContext<IHospitalEntity> readHospital)
        {
            this.readHospital = readHospital;
        }

        public IQueryable<Doctor> Get()
        {
            return readHospital.Get<Doctor>();
        }

        public Doctor? Get(Guid id)
        {
            return readHospital.Get<Doctor>()
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
