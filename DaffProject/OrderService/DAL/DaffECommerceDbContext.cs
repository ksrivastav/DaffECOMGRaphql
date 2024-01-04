using OrderService.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace OrderService.DAL
{
    public class DaffECommerceDbContext : DbContext
    {
        public DaffECommerceDbContext()
        {

        }
        public DaffECommerceDbContext(DbContextOptions options) : base(options)
        {


        }

        // DB Context Classes
        //public DbSet<User> User { get; set; }
        //public DbSet<UserContact> UserContact { get; set; }
        //public DbSet<UserProfile> UserProfile { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }
        //public DbSet<UserRoleAssoc> UserRoleAssoc { get; set; }
        //public DbSet<Product> Product { get; set; }
        //public DbSet<ProductSubCategory> ProductSubCategory { get; set; }
        //public DbSet<ProductCategory> ProductCategory { get; set; }
        //public DbSet<Payment> Payment { get; set; }
        //public DbSet<PaymentStatus> PaymentStatus { get; set; }
         public DbSet<Order> Order { get; set; }
        //public DbSet<OrderStatus> OrderStatus { get; set; }
        //public DbSet<UserCart> UserCart { get; set; }
        //public DbSet<UserClaim> UserClaim { get; set; }
        //public DbSet<RoleClaim> RoleClaim { get; set; }
        //public DbSet<UserToken> UserToken { get; set; }
        //public DbSet<UserLogin> UserLogins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);

            Order o = new Order();
            o.OrderId = 1;
            o.OrderQuantity = 1;
            o.OrderStatus =1;
            o.Product = 1;
            o.User = 1; 
            o.Payment = 1;
            modelBuilder.Entity<Order>().HasData(o);





        }
    }
}
