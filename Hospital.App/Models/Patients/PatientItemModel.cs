using Hopital.DataLayer.Enums;

namespace Hospital.App.Models.Patients
{
    public class PatientItemModel
    {
        public PatientItemModel(Guid id, string surmane, string name, string? patronymic, string address, 
            DateTime birthday, Gender gender, Guid healthLocalityId)
        {
            Id = id;
            Surmane = surmane;
            Name = name;
            Patronymic = patronymic;
            Address = address;
            Birthday = birthday;
            Gender = gender;
            HealthLocalityId = healthLocalityId;
        }

        public Guid Id { get; set; }
        public string Surmane { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public Guid HealthLocalityId { get; set; }
    }
}
