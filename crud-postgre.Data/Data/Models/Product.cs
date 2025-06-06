using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crud.Data.Models
{
    public class Product
    {
        [Key]  
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productId { get; set; }

        [Required]
        [StringLength(50)]
        public string productCode { get; set; }

        [Required]
        [StringLength(225)]
        public string productName { get; set; }

        [Required]
        public int createdBy { get; set; }

        [Required]
        public DateTime createdAt { get; set; }

        public int? modifiedBy { get; set; }

        public DateTime? modifiedAt { get; set; }

    }
}
