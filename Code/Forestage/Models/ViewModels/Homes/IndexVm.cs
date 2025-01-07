using Forestage.Models.ViewModels.Products;

namespace Forestage.Models.ViewModels.Homes
{
    public class IndexVm
    {
        public List<ProductBlockVm> BestProducts { get; set; }
        public List<ProductBlockVm> NewProducts { get; set; }
        public List<ProductBlockVm> UpcomingProducts { get; set; }
    }
}
