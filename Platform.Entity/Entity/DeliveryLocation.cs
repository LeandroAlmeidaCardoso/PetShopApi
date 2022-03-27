using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Platform.Entity.Entity
{
    public class DeliveryLocation : BaseEntity
    {
        [Key]
        [Column("DeliveryLocationId")]
        public override long Id { get => base.Id; set => base.Id = value; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Neighborhood { get; set; }
    }
}
