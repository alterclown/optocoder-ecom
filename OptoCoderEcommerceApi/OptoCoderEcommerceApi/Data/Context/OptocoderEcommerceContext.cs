using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OptoCoderEcommerceApi.Data.Entities;

namespace OptoCoderEcommerceApi.Data.Context
{
    public partial class OptocoderEcommerceContext : DbContext
    {
        public OptocoderEcommerceContext()
        {
        }

        public OptocoderEcommerceContext(DbContextOptions<OptocoderEcommerceContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Images> Image { get; set; }
    }
}
