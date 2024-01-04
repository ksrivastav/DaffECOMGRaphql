using DaffEcommerceProductService.Domain;
using DaffEcommerceProductService.Repository;
using GraphQL.Types;

namespace DaffEcommerceProductService.GraphQLProj.Type
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType( )//IProductSubCategoryRepository<ProductSubCategory> productSubCategoryRepository)
        {
            Field(m => m.ProductId);
            Field(m => m.Name);
            Field(m => m.ProductDesc);
            Field(m => m.NetQuantity);
            Field(m => m.Price);
            Field(m => m.Quantity);
            Field(m => m.ProductPrice);
            Field(m => m.CountryOfOrigin);
            Field(m => m.Color);
            Field(m => m.DimensionLWH);
            Field(m => m.CreateDateTime);
            Field(m => m.UpdateDateTime);
            Field(m => m.ProductSubCategoryId);
            Field(m => m.SellerId);
            Field(m => m.ProductTitle);
            Field(m => m.Tag);
            


        }
    }
}
