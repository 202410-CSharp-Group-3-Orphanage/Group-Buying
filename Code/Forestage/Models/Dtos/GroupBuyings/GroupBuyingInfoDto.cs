using Forestage.Models.Dtos.Orders;

namespace Forestage.Models.Dtos.GroupBuyings
{
    public class GroupBuyingInfoDto
    {
        public int Price { get; set; }
        public int MinimumGroupSize { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Enabled { get; set; }
        public IEnumerable<OrderInfoDto> Orders { get; set; }
    }
}
