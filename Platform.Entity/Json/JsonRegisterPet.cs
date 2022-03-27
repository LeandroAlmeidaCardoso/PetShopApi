using System.ComponentModel.DataAnnotations;

namespace Platform.Entity.Json
{
    public class JsonRegisterPet : JsonBase
    {
        [Required]
        public string PetOwnerTaxNumber { get; set; }
        [Required]
        public string PetName { get; set; }
        [Required]
        public int PetType { get; set; }
        [Required]
        public int DeviveryType { get; set; }
        public JsonPetDelivery DeliveryPlace { get; set; }

    }
}
