using Hopital.DataLayer.Enums;

namespace Hospital.App.Models.Patients
{
    public class PatientForm
    {
        public string Surmane { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public Guid HealthLocalityId { get; set; }
    }
}
