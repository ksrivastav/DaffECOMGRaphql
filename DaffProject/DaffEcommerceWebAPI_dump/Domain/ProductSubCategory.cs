using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaffEcommerceProductService.Domain
{
    public class ProductSubCategory
    {
        [Key]
        [Display(Name = "ProductSubCategoryId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductSubCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Tags { get; set; }

        public int ProductCategoryId { get; set; }

        [ForeignKey("ProductCategoryId")]
        public virtual ProductCategory ProductCategory { get; set; }

        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
