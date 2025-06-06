using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crud.Data.Models
{
    public class Customer
    {
        [Key]  
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int customerId { get; set; }

        [Required]
        [StringLength(50)]
        public string customerCode { get; set; }

        [Required]
        [StringLength(225)]
        public string customerName { get; set; }

        [Required]
        [StringLength(1000)]
        public string customerAddress { get; set; }

        [Required]
        public int createdBy { get; set; }

        [Required]
        public DateTime createdAt { get; set; }

        public int? modifiedBy { get; set; }

        public DateTime? modifiedAt { get; set; }

    }
}
