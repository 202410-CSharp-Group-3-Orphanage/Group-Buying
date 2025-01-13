
using Forestage.Models.EFModels;
using Microsoft.EntityFrameworkCore;

namespace Forestage.Models.Repositories
{
    public class GroupBuyingRepository
    {
        private readonly AppDbContext _context;

        public GroupBuyingRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public int GetActiveGroupBuyingId(int productId)
        {
            var groupBuyings = _context.GroupBuyings
                .AsNoTracking()
                .OrderBy(g => g.Id)
                .LastOrDefault(gb => gb.ProductId == productId && gb.Enabled == true);


            return groupBuyings?.Id ?? 0;
        }
    }
}
