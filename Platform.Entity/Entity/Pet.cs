using Petshop.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Platform.Entity.Entity
{
    public class Pet : BaseEntity
    {
        [Key]
        [Column("PetId")]
        public override long Id { get => base.Id; set => base.Id = value; }

        [Column("PetServiceId")]
        public PetService Service { get; set; }

        [Column("PetOwnerId")]
        public PetOwner PetOwner { get; set; }

        public string Name { get; set; }

        public PetType Type { get; set; }

    }
}
