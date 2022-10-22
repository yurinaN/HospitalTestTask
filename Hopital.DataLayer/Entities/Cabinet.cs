namespace Hopital.DataLayer.Entities
{
    public class Cabinet : IHospitalEntity, IIdentifiable
    {
        public Cabinet(string number)
        {
            Id = Guid.NewGuid();
            Number = number;
        }

        public Guid Id { get; set; }
        public string Number { get; set; }
    }
}
