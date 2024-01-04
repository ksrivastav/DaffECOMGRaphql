using DaffEcommerceProductService.Domain;
using GraphQL.Client.Abstractions;
using GraphQL;
using DaffEcommerceProductService.GraphQLProj.Type;
using GraphQL.Types;

namespace DaffEcommerceProductService.Consumer
{
    public class ProductConsumer
    {
        IGraphQLClient graphQLClient;
        public ProductConsumer(IGraphQLClient _graphQLClient) {
            graphQLClient=_graphQLClient;
        }


        public async Task<ProductList> GetAllProduct()
        {
            var query = new GraphQLRequest
            {
                Query = @"
               query firstQuerry{
  
                  products{    
                    productId
                    name
                    productDesc
                    productPrice
                    productSubCategoryId
                    price
                    countryOfOrigin
                    color
                    dimensionLWH
                    netQuantity
    
                  }
                }"
            };

            
            var response = await graphQLClient.SendQueryAsync<ProductList>(query);

       
            
            return response.Data;
        }

    }
}
