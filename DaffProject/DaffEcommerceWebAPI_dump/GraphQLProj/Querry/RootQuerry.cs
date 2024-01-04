using GraphQL.Types;

namespace DaffEcommerceProductService.GraphQLProj.Querry
{
    public class RootQuerry:ObjectGraphType
    {
        public  RootQuerry()
        {

            Field<ProductQuerry>("ProductQuerry").Resolve(context => new { });
        }
    }
}
