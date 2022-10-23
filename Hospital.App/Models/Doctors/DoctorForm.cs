namespace Hospital.App.Models.Doctors
{
    public class DoctorForm
    {
        public Guid CabinetId { get; set; }
        public Guid SpecializationId { get; set; }
        public Guid? HealthLocalityId { get; set; }
    }
}
