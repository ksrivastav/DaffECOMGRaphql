using DaffEcommerceProductService.Domain;
using GraphQL.Types;

namespace DaffEcommerceProductService.GraphQLProj.Type
{
    public class ProductInputType: InputObjectGraphType//<Product>
    {
        public ProductInputType()
        {


            Field<LongGraphType>("productId");
            Field<StringGraphType>("name");
            Field<StringGraphType>("productDesc");
            Field<StringGraphType>("netQuantity");
            Field<StringGraphType>("price");
            Field<IntGraphType>("quantity");
            Field<StringGraphType>("productPrice");
            Field<StringGraphType>("countryOfOrigin");
            Field<StringGraphType>("color");
            Field<StringGraphType>("dimensionLWH");
            Field<DateTimeGraphType>("createDateTime");
            Field<DateTimeGraphType>("updateDateTime");
            Field<IntGraphType>("productSubCategoryId");
            Field<IntGraphType>("sellerId");
            Field<StringGraphType>("ProductTitle");
            Field<StringGraphType>("Tag");
        }
    }
}
