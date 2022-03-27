using Petshop.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Platform.Entity.Entity
{
    public class PetService : BaseEntity
    {
        [Key]
        [Column("PetServiceId")]
        public override long Id { get => base.Id; set => base.Id = value; }
        public string Description { get; set; }
        public PetServiceType Type { get; set; }
    }
}
