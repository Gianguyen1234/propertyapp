
using Microsoft.EntityFrameworkCore;
using propertyapp.Models;


namespace propertyapp.Data // Ensure this matches your actual namespace
{
    public class PropertyContext : DbContext
    {
        public PropertyContext(DbContextOptions<PropertyContext> options) : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
    }
}

