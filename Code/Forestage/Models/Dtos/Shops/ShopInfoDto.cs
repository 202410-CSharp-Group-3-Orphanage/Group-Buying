using Forestage.Models.Dtos.Products;
using Forestage.Models.EFModels;
using Forestage.Models.Infra;
using Forestage.Models.Services;
using Forestage.Models.ViewModels.Products;

namespace Forestage.Models.Dtos.Shops
{
    public class ShopInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Avatar { get; set; }

        public string Address { get; set; }

        public int ProductCount { get; set; }

        public PagedList<ProductBlockDto, SortInfo<ProductBlockDto>> Products { get; set; }
    }
}
