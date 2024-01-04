using Asp.Versioning;
using DaffEcommerceProductService.DAL;
using DaffEcommerceProductService.Domain;
using DaffEcommerceProductService.Repository;
using DaffEcommerceProductService.Service;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using DaffEcommerceProductService.GraphQLProj.Querry;
using DaffEcommerceProductService.GraphQLProj.Type;
using GraphQL.Types;
using DaffEcommerceProductService.GraphQLProj.Schema;
using DaffEcommerceProductService.GraphQLProj.Mutation;
using GraphQL;
using GraphiQl;
using GraphQL.MicrosoftDI;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using DaffEcommerceProductService.Consumer;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddGraphQLServer()
//     .AddQueryType<ProductQuerry>();
//    //.AddMutationType<Mutation>()
//    //.AddSubscriptionType<Subscription>()

//builder.Services.AddDbContext<DaffECommerceDbContext>();
builder.Services.AddDbContext<DaffECommerceDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDbConnectionString"));
});

builder.Services.AddTransient<IProductCategoryService<ProductCategory>, ProductCategoryService>();
builder.Services.AddTransient<IProductSubCategoryService<ProductSubCategory>, ProductSubCategoryService>();
builder.Services.AddTransient<IProductService<Product>, ProductService>();
builder.Services.AddTransient<IProductCategoryRepository<ProductCategory>, ProductCategoryRepository>();
builder.Services.AddTransient<IProductSubCategoryRepository<ProductSubCategory>, ProductSubCategoryRepository>();
builder.Services.AddTransient<IProductRepository<Product>, ProductRepository>();
builder.Services.AddTransient<Product>();
builder.Services.AddTransient<ProductSubCategory>();
builder.Services.AddTransient<ProductCategory>();
builder.Services.AddTransient<ProductQuerry>();
builder.Services.AddTransient<RootQuerry>();
builder.Services.AddTransient<ProductMutation>();
builder.Services.AddTransient<ProductType>();
builder.Services.AddTransient<ProductInputType>();
builder.Services.AddTransient<ProductConsumer>();
builder.Services.AddTransient<ISchema, ProductSchema>();
builder.Services.AddGraphQL(b => b.AddAutoSchema<ISchema>().AddSystemTextJson());
builder.Services.AddScoped<IGraphQLClient>(s => new GraphQLHttpClient(
        builder.Configuration["GraphQLURI"], new NewtonsoftJsonSerializer()
        ));
builder.Services.AddApiVersioning(
    o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new ApiVersion(1, 0);
    o.ReportApiVersions = true;
    o.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("ver"));
}
).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseGraphiQl("/graphql");
app.UseGraphQL<ISchema>();


app.UseAuthorization();

app.MapControllers();

app.Run();
