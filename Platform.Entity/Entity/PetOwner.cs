using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Platform.Entity.Entity
{
    public class PetOwner : BaseEntity
    {
        [Key]
        [Column("PetOwnerId")]
        public override long Id { get => base.Id; set => base.Id = value; }

        [Column("DeliveryLocationId")]
        public DeliveryLocation DeliveryLocation { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public string PhoneNumber { get; set; }

    }
}
