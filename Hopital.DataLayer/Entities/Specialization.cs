namespace Hopital.DataLayer.Entities
{
    public class Specialization : IHospitalEntity, IIdentifiable
    {
        public Specialization(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
