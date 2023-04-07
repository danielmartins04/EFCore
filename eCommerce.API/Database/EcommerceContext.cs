using Microsoft.EntityFrameworkCore;

namespace eCommerce.API.Database
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=localhost,1433;Database=ecommerce;User ID=sa;Password=1q2w3e4r@#$");
        //}
    }
}
