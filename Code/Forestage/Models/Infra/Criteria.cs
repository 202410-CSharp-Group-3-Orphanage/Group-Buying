using Forestage.Models.Dtos.Products;
using System.Web;

namespace Forestage.Models.Infra
{
    public class Criteria
    {
        public int? CaregoryId { get; set; }
        public string? CategoryName { get; set; }
        public int ProductCount { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string? SearchKeyword { get; set; }

        public IQueryable<ProductBlockDto> ApplyCriteria(IQueryable<ProductBlockDto> query)
        {
            if (!string.IsNullOrWhiteSpace(CategoryName))
            {
                query = query.Where(t => t.CategoryName == CategoryName);
            }

            query = query.Where(p => (!MinPrice.HasValue || p.ProductPrice >= MinPrice.Value) &&
                (!MaxPrice.HasValue || p.ProductPrice <= MaxPrice.Value));

            if (!string.IsNullOrWhiteSpace(SearchKeyword))
            {
                query = query.Where(t => t.ProductName.Contains(SearchKeyword));
            }

            return query;
        }
    }
}
