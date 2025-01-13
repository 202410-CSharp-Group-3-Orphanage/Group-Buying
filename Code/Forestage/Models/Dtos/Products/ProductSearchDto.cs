using Forestage.Models.Infra;
using Forestage.Models.ViewModels.Products;

namespace Forestage.Models.Dtos.Products
{
    public class ProductSearchDto
    {
        public int? CategoryId { get; set; }
        public int ProductCount { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string? SearchKeyword { get; set; }
        public List<CategoryDto> categories { get; set; }
        public PagedList<ProductBlockDto, SortInfo<ProductBlockDto>> SearchProducts { get; set; }
    }
}
