using System.ComponentModel.DataAnnotations.Schema;

namespace Hopital.DataLayer.Entities
{
    public class LocalDoctor : IHospitalEntity, IIdentifiable
    {
        public Guid Id { get; set; }
        public Guid CabinetId { get; set; }
        public Guid SpecializationId { get; set; }
        public Guid? HealthLocalityId { get; set; }

        [ForeignKey("CabinetId")]
        public virtual Cabinet? Cabinet { get; set; }
        [ForeignKey("SpecializationId")]
        public virtual Specialization? Specialization { get; set; }
        [ForeignKey("HealthLocalityId")]
        public virtual HealthLocality? HealthLocality { get; set; }
    }
}
