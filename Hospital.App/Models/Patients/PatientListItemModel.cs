using Hopital.DataLayer.Enums;

namespace Hospital.App.Models.Patients
{
    public class PatientListItemModel
    {
        public Guid Id { get; set; }
        public string Surmane { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public string HealthLocality { get; set; }
    }
}
