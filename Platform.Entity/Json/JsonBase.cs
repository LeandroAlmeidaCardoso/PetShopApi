using System.ComponentModel.DataAnnotations;

namespace Platform.Entity.Json
{
    public class JsonBase
    {
        [Required(ErrorMessage = "Campo PetShopId é Requirido")]
        public long PetShopId { get; set; }
        [Required(ErrorMessage = "Campo EmployeeId é Requirido")]
        public long EmployeeId { get; set; }
        [Required(ErrorMessage = "Campo Method é Requirido")]
        public string Method { get; set; }
    }
}
