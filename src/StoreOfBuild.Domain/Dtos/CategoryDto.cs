using System.ComponentModel.DataAnnotations;

namespace StoreOfBuild.Domain.Dtos
{
    public class CategoryDto
    {
        public int Id {get; set;}
        
        [Required]
        public string Name {get; set;}
    }
}