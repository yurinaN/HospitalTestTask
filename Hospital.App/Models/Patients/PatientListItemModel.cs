using Hopital.DataLayer.Enums;
using Hospital.Core.Extensions;

namespace Hospital.App.Models.Patients
{
    public class PatientListItemModel
    {
        public PatientListItemModel(Guid id, string surmane, string name, string? patronymic, string address, 
            DateTime birthday, Gender gender, string healthLocality)
        {
            Id = id;
            Surmane = surmane;
            Name = name;
            Patronymic = patronymic;
            Address = address;
            Birthday = birthday;
            Gender = gender.GetEnumDescription();
            HealthLocality = healthLocality;
        }

        public Guid Id { get; set; }
        public string Surmane { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string HealthLocality { get; set; }
    }
}
