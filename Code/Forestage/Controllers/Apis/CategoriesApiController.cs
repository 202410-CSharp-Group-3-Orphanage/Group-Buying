using Forestage.Models.EFModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forestage.Controllers.Apis
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesApiController : ControllerBase
	{
		private readonly AppDbContext _context;

		public CategoriesApiController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet()]
		public IActionResult GetAll()
		{
			//SELECT c.id,
			//       c.Name
			//FROM Categories c
			//JOIN Products p ON c.Id = p.CategoryId
			//GROUP BY c.id,
			//         c.name
			var categories = _context.Categories
				.Join(
					_context.Products,
					c => c.Id,
					p => p.CategoryId,
					(c, p) => new { Category = c, Product = p }
				)
				.GroupBy(cp => new { cp.Category.Id, cp.Category.Name })
				.Select(g => new
				{
					Id = g.Key.Id,
					Name = g.Key.Name
				})
				.ToList();
			return Ok(categories);
		}
	}
}
