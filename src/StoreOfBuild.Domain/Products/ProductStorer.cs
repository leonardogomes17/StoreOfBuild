using StoreOfBuild.Domain.Dtos;

namespace StoreOfBuild.Domain.Products
{
    public class ProductStorer
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;

        public ProductStorer(IRepository<Product> productRepository, IRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public void Store(ProductDto dto)
        {
            var category = _categoryRepository.GetByID(dto.Categoryid);
            DomainException.When(category == null, "Category Invalid");

            var product = _productRepository.GetByID(dto.Id, nameof(Product.Category));
            if (product == null)
            {
                product = new Product();
                product.SetProperties(dto.Name, category, dto.Price, dto.StockQuantity);
                _productRepository.Save(product);
            }
            else
                product.Update(dto.Name, category, dto.Price, dto.StockQuantity);

        }

        public void Delete(int id)
        {
            _productRepository.DeleteByID(id);
        }
    }
}