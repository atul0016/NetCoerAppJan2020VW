using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Core_APIApp.Models
{
    public class Category
    {
        [Key]
        public int CategoryRowId { get; set; }
        [Required(ErrorMessage ="Category Id is required")]
        [StringLength(20)]
        public string CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is required")]
        [StringLength(100)]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Base Price is required")]
        public int BasePrice { get; set; }

        // navigation property
      //  public ICollection<Product> Products { get; set; }
    }

    public class Product
    {
        [Key]
        public int ProductRowId { get; set; }
        [Required(ErrorMessage = "Product Id is required")]
        [StringLength(20)]
        public string ProductId { get; set; }
        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(100)]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Manufacturer is required")]
        [StringLength(150)]
        public string Manufacturer { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Categiry Id required")]
        public int CategoryRowId { get; set; } // foreign Key
        public Category Category { get; set; } // referential integrity

    }
}
