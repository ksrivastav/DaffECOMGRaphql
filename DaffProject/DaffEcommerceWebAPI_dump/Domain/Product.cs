using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace DaffEcommerceProductService.Domain
{

    public class ProductList
    {
        public List<Product> Products { get; set; }
    }
    public class Product
    {
        [Key]
        [Display(Name = "Product")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductId { get; set; }
        public string Name { get; set; }

        public string ModelNumber { get; set; }
        public string ProductDesc { get; set; }

        public string ProductTitle { get; set; }

        public string CountryOfOrigin { get; set; }

        public string Manufacturer { get; set; }
        public double ProductPrice { get; set; }


        public long SellerId { get; set; }

        //[ForeignKey("SellerId")]
        //public User Seller { get; set; }

        public double NetWieght { get; set; }

        public long Quantity { get; set; }

        public int NetQuantity { get; set; }

        public string DimensionLWH { get; set; }
        public string Tag { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }

        public string? Image { get; set; }

        public int ProductSubCategoryId { get; set; }

        [ForeignKey("ProductSubCategoryId")]
        public virtual ProductSubCategory ProductSubCategory { get; set; }
    }
}
