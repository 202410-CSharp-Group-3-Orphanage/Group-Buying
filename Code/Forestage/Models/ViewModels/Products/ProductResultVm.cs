using Forestage.Models.Dtos.Products;
using Forestage.Models.Infra;

namespace Forestage.Models.ViewModels.Products
{
    public class ProductResultVm
    {
        public ProductSearchVm SearchVm { get; set; }
        public List<CategoryDto> categories { get; set; }
        public PagedList<ProductBlockVm, SortInfo<ProductBlockDto>> SearchProducts { get; set; }
    }
}
