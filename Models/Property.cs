using System.ComponentModel.DataAnnotations;

namespace propertyapp.Models 
{
    public class Property
    {
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Address { get; set; }

        public decimal Price { get; set; }

        public int Bedrooms { get; set; }

        public int Bathrooms { get; set; }
    }
}
