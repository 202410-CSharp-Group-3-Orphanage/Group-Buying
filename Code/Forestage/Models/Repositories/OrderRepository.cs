using Forestage.Models.Dtos.Orders;
using Forestage.Models.EFModels;
using MT.Utilities.Mapper;

namespace Forestage.Models.Repositories
{
    public class OrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public void CreateOrder(int memberId, OrderCreateDto orderCreateDto)
        {
            var order = ObjectMapper.Map<OrderCreateDto, Order>(orderCreateDto);
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
