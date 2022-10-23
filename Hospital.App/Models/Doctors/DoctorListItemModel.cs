namespace Hospital.App.Models.Doctors
{
    public class DoctorListItemModel
    {
        public DoctorListItemModel(Guid id, string cabinet, string specialization, string? healthLocality)
        {
            Id = id;
            Cabinet = cabinet;
            Specialization = specialization;
            HealthLocality = healthLocality;
        }

        public Guid Id { get; set; }
        public string Cabinet { get; set; }
        public string Specialization { get; set; }
        public string? HealthLocality { get; set; }
    }
}
