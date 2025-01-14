using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatformManagement.Models.EFModels;

namespace PlatformManagement.Controllers.Apis
{
	[Route("api/[controller]")]
	[ApiController]
	public class GroupBuyingsApiController : ControllerBase
	{
		private readonly AppDbContext _context;

		public GroupBuyingsApiController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet("ProcessGroupBuying")]
		public IActionResult ProcessGroupBuying()
		{
			IEnumerable<GroupBuying> groupBuyings = _context.GroupBuyings
					//.Where(g => g.Enabled == true && g.EndDate < DateTime.Now) TODO: 正式上線後要用這個
					.Where(g => g.Enabled == true)
					.ToList();

			foreach (var groupBuying in groupBuyings)
			{
				// 先把團購關閉
				groupBuying.Enabled = false;
				groupBuying.UpdatedAt = DateTime.Now;

				//取得目前參與的訂單
				IEnumerable<Order> orders = _context.Orders
					.Where(o => o.GroupBuyingId == groupBuying.Id && o.Status == 1)
					.ToList();
				// 計算總數量
				int totalQuantity = orders.Sum(o => o.Quantity);

				// 判斷是否滿足團購條件
				if (totalQuantity >= groupBuying.MinimumGroupSize)
				{
					foreach (var order in orders)
					{
						// 將訂單狀態改為成立
						order.Status = 2;
						order.UpdatedAt = DateTime.Now;
					}
				}
				else
				{
					foreach (var order in orders)
					{
						// 將訂單狀態改為取消
						order.Status = 0;
						order.UpdatedAt = DateTime.Now;
					}
				}

			}
			_context.SaveChanges();
			return Ok();
		}
	}
}
