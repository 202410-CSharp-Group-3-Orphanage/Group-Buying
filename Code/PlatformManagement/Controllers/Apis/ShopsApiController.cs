using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlatformManagement.Models.EFModels;

namespace PlatformManagement.Controllers.Apis
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShopsApiController : ControllerBase
	{
		private readonly AppDbContext _context;
		public ShopsApiController(AppDbContext appDbContext)
		{
			_context = appDbContext;
		}
		[HttpGet("Test")]
		public IActionResult Test() { return Ok(); }

		//[AutoValidateAntiforgeryToken]
		[Authorize]
		[HttpPost("ChangeStatus")]
		public IActionResult ChangeStatus([FromBody] ChangeStatusRequest changeStatusRequest)
		{
			var id = changeStatusRequest.Id;
			var status = changeStatusRequest.Status;
			var shop = _context.Shops.SingleOrDefault(x => x.Id == id);
			if (shop == null) return NotFound(new { success = false, message = "店家不存在" });

			shop.Status = (short)(status ? 1 : 0);
			_context.SaveChanges();
			return Ok(new { success = true });
		}

		public class ChangeStatusRequest
		{
			public int Id { get; set; }
			public bool Status { get; set; }
		}

	}
}
