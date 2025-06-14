using StoreOfBuild.Domain.Dtos;

namespace StoreOfBuild.Domain.Products
{
    public class CategoryStorer
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryStorer(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Store(CategoryDto dto)
        {
            var category = _categoryRepository.GetByID(dto.Id);

            if (category == null)
            {
                category = new Category(dto.Name);
                _categoryRepository.Save(category);
            }
            else
                category.Update(dto.Name);

        }

        public void Delete(int id)
        {
            try
            {
                _categoryRepository.DeleteByID(id);
            }
            catch
            {
                throw new Exception("Category in Product!");
            }
        }
    }
}