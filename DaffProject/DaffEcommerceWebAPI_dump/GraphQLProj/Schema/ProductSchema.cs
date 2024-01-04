using DaffEcommerceProductService.GraphQLProj.Mutation;
using DaffEcommerceProductService.GraphQLProj.Querry;
using GraphQL.Types;

namespace DaffEcommerceProductService.GraphQLProj.Schema
{
    public class ProductSchema : GraphQL.Types.Schema
    {
        public ProductSchema(ProductQuerry rootQuerry, ProductMutation productMutation)////, ProductMutation productMutation
        {
            Query = rootQuerry;
            Mutation = productMutation;
        }
    }
}
