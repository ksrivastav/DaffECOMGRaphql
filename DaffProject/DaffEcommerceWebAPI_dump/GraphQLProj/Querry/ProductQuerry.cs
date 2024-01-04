using DaffEcommerceProductService.Domain;
using DaffEcommerceProductService.GraphQLProj.Type;
using DaffEcommerceProductService.Repository;
using GraphQL;
using GraphQL.Types;
using System.Data.Entity.Core.Objects;

namespace DaffEcommerceProductService.GraphQLProj.Querry
{
    public class ProductQuerry : ObjectGraphType
    {

        public ProductQuerry(IProductRepository<Product> ProductRepository)
        {


            Field<ListGraphType<ProductType>>("Products").Resolve(context =>
                {
                    var listP = ProductRepository.getAllItemProd();
                    return listP;
                });

            Field<ProductType>("Product").Arguments(new QueryArguments(new QueryArgument<LongGraphType> { Name = "Id" })).Resolve(context =>
            {
                return ProductRepository.getSingleItemProd(context.GetArgument<long>("Id"));

            });
        }




    }
}
