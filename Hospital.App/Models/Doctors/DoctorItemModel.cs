namespace Hospital.App.Models.Doctors
{
    public class DoctorItemModel
    {
        public Guid Id { get; set; }
        public Guid CabinetId { get; set; }
        public Guid SpecializationId { get; set; }
        public Guid? HealthLocalityId { get; set; }
    }
}
