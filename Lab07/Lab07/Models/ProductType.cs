using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab07
{ 
    public partial class ProductType
    {
        public ProductType()
        {
            products = new HashSet<Product>();
        }

        [Key]
        public int ProductTypeId { get; set; }

        [Required]
        [StringLength(45)]
        public string PType { get; set; }

        public virtual ICollection<Product> products { get; set; }
    }
}
