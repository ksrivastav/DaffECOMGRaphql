using DaffEcommerceProductService.Domain;
using DaffEcommerceProductService.GraphQLProj.Type;
using DaffEcommerceProductService.Repository;
using GraphQL;
using GraphQL.Types;

namespace DaffEcommerceProductService.GraphQLProj.Mutation
{
    public class ProductMutation: ObjectGraphType
    {
        public ProductMutation (IProductRepository<Product> ProductRepository)
        {
            Field<ProductType>("CreateSingleProduct").Arguments(new QueryArguments(new QueryArgument<ProductInputType> { Name = "inputProduct" })).Resolve(context =>
            {
                var id =  ProductRepository.insertSingleItemProduct(context.GetArgument<Product>("inputProduct"));
                return id;

            });
            Field<ProductType>("UpdateSingleProduct").Arguments(new QueryArguments(new QueryArgument<ProductInputType> { Name = "inputProduct" })).Resolve(context =>
            {
                var id = ProductRepository.updateSingleItemProduct(context.GetArgument<Product>("inputProduct"));
                return id;

            });
        }
    }
}
