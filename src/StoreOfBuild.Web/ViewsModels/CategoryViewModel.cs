using System.ComponentModel.DataAnnotations;

namespace StoreOfBuild.Web.ViewsModels
{
    public class CategoryViewModel
    {
        public int Id {get; set;} 

        public required string Name {get; set;} = string.Empty;
    }
    
}