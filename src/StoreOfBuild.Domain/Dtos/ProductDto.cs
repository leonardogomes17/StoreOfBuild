using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreOfBuild.Domain.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Categoryid { get; set; }

        public decimal Price { get; set; }

        [Required]
        public int StockQuantity { get; set; }
        
        public IEnumerable<CategoryDto> ListCategories { get; set; }
    }
}