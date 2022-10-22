namespace Hopital.DataLayer.Entities
{
    public class HealthLocality : IHospitalEntity, IIdentifiable
    {
        public HealthLocality(string number)
        {
            Id = Guid.NewGuid();
            Number = number;
        }

        public Guid Id { get; set; }
        public string Number { get; set; }
    }
}
