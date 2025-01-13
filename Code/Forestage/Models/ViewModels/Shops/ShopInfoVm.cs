using Forestage.Models.Dtos.Products;
using Forestage.Models.EFModels;
using Forestage.Models.Infra;
using Forestage.Models.Services;
using Forestage.Models.ViewModels.Products;

namespace Forestage.Models.ViewModels.Shops
{
    public class ShopInfoVm
    {
        public string Name { get; set; }

        public string Avatar { get; set; }

        public string Address { get; set; }

        public int ProductCount { get; set; }

        public PagedList<ProductBlockVm, SortInfo<ProductBlockDto>> Products { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }

        public SortInfo<ProductBlockDto> SortInfo { get; set; }
    }
}
