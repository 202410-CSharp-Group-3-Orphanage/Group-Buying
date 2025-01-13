using System.ComponentModel.DataAnnotations;
using Forestage.Models.Dtos.Products;
using Forestage.Models.Infra;

namespace Forestage.Models.ViewModels.Products
{
    public class ProductSearchVm
    {
        public int? CategoryId { get; set; }
        public int ProductCount { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string? SearchKeyword { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
    }
}
