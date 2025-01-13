using Forestage.Models.Repositories;

namespace Forestage.Models.Services
{
    public class GroupBuyingService
    {
        private readonly GroupBuyingRepository _groupBuyingRepo;

        public GroupBuyingService(GroupBuyingRepository groupBuyingRepository)
        {
            _groupBuyingRepo = groupBuyingRepository;
        }

        public int GetActiveGroupBuyingId(int productId)
        {
            return _groupBuyingRepo.GetActiveGroupBuyingId(productId);
        }
    }
}
