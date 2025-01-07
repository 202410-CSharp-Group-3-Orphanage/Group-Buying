using Forestage.Models.Dtos.Products;
using Forestage.Models.Repositories;
using MT.Extensions;

namespace Forestage.Models.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepo;

        public ProductService(ProductRepository productRepository)
        {
            _productRepo = productRepository;
        }
        public IEnumerable<ProductBlockDto> GetBestProducts()
        {
            int limit = 5;
            int imgLimit = 1;
            IEnumerable<ProductBlockDto> productIndexDtos = _productRepo.GetBestProducts();
            productIndexDtos = productIndexDtos
                .Select(x =>
                {
                    x.ImagePaths = x.ImagePaths.Take(imgLimit).ToList();
                    x.Info = x.Info.Truncate(20, true);
                    return x;
                });
            productIndexDtos = productIndexDtos.Take(limit);
            return productIndexDtos;
        }

        public IEnumerable<ProductBlockDto> GetNewProducts()
        {
            int limit = 6;
            int imgLimit = 1;
            IEnumerable<ProductBlockDto> productIndexDtos = _productRepo.GetNewProducts();
            productIndexDtos = productIndexDtos
                .Select(x =>
                {
                    x.ImagePaths = x.ImagePaths.Take(imgLimit).ToList();
                    x.Info = x.Info.Truncate(20, true);
                    return x;
                });
            productIndexDtos = productIndexDtos.Take(limit);
            return productIndexDtos;
        }
        public IEnumerable<ProductBlockDto> GetUpcomingProducts()
        {
            int limit = 10;
            int imgLimit = 2;
            IEnumerable<ProductBlockDto> productIndexDtos = _productRepo.GetUpcomingProducts();
            productIndexDtos = productIndexDtos
                .Select(x =>
                {
                    x.ImagePaths = x.ImagePaths.Take(imgLimit).ToList();
                    x.Info = x.Info.Truncate(20, true);
                    return x;
                });
            productIndexDtos = productIndexDtos.Take(limit);
            return productIndexDtos;
        }
    }
}