using Forestage.Models.EFModels;

namespace Forestage.Models.Dtos.Shops
{
    public class ShopInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Avatar { get; set; }

        public string Address { get; set; }

        public int ProductCount { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
