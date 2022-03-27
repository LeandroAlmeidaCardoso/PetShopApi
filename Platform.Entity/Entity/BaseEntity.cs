using System;
using System.ComponentModel.DataAnnotations;

namespace Platform.Entity.Entity
{
    public class BaseEntity
    {
        [Key]
        public virtual long Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
