using Forestage.Models.EFModels;
using Forestage.Models.Services;
using Forestage.Models.ViewModels.Paging;
using Forestage.Models.ViewModels.Products;
using Forestage.Models.ViewModels.Sort;

namespace Forestage.Models.ViewModels.Shops
{
    public class ShopInfoVm
    {
        public string Name { get; set; }

        public string Avatar { get; set; }

        public string Address { get; set; }

        public int ProductCount { get; set; }

        public PagedList<ProductBlockVm, SortInfo<Product>> Products { get; set; }
    }
}
