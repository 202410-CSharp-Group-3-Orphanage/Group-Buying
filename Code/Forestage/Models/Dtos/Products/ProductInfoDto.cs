using Forestage.Models.Dtos.GroupBuyings;
using Forestage.Models.Dtos.Shops;
using Forestage.Models.EFModels;

namespace Forestage.Models.Dtos.Products
{
    public class ProductInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Info { get; set; }
        public IEnumerable<ProductImageInfoDto> ProductImages { get; set; }
        public IEnumerable<GroupBuyingInfoDto> GroupBuyings { get; set; }
        public ShopInfoDto Shop {  get; set; }


        // 以下是 ProductInfoVm 需要的資料，但不想多開一個 Dto 了
        public List<string> ImagePaths { get; set; }
        public int Participants { get; set; }
        public int MinimumGroupSize { get; set; }
        public DateTime EndDate { get; set; }
        public string ShopName { get; set; }
        public string ShopLink {  get; set; }
        public string ShopAvatar { get; set; }
        public int GroupBuyingPrice { get; set; }
        public string Description { get; set; }
    }
}
