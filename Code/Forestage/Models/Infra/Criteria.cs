using Forestage.Models.Dtos.Products;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Mono.TextTemplating;
using System.Web;

namespace Forestage.Models.Infra
{
    public class Criteria
    {
        public int? CategoryId { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string? SearchKeyword { get; set; }

        public Criteria(int? categoryId, int? minPrice, int? maxPrice, string? searchKeyword)
        {
            CategoryId = categoryId;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            SearchKeyword = searchKeyword;
        }

        public IQueryable<ProductBlockDto> ApplyCriteria(IQueryable<ProductBlockDto> query)
        {
            if (CategoryId > 0)
            {
                query = query.Where(t => t.CategoryId == CategoryId);
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
