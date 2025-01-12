using Forestage.Models.Dtos.Products;
using Forestage.Models.Infra;

namespace Forestage.Models.ViewModels.Products
{
    public class ProductSearchVm
    {
        public int CaregoryId { get; set; }
        public string CategoryName { get; set; }
        public int ProductCount { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public string SearchKeyword { get; set; }
        public PagedList<ProductBlockVm, SortInfo<ProductBlockDto>> SearchProducts { get; set; }
    }
}
