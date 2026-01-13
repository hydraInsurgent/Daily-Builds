using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagementAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Specify exact column specs to be created in DB.
        // decimal(precision, scale)
        [Column(TypeName ="decimal(18,2)")] 
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }

        public string? CreatedBy { get; set; } // Name of the user who added the product
        public DateTime? CreatedDate { get; set; } // When product was added.
    }
}
