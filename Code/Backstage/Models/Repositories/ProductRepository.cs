using Backstage.Common;
using Backstage.Models.Dtos;
using Backstage.Models.EFModels;
using Backstage.Models.ViewModels;
using MT.Utilities.UploadFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Backstage.Models.Repositories
{
    public class ProductRepository
    {
        FilePathHelper _filePathHelper = new FilePathHelper();
        UploadFileHelper _uploadFileHelper = new UploadFileHelper();
        private readonly AppDbContext2 _context;

        public ProductRepository( AppDbContext2 context)
        {            
            _context = context;
        }
        

        public SelectList ShowCategories()
        {
                var categories = _context.Categories
                                   .Select(c => new { c.Id, c.Name })
                                   .ToList();

                return new SelectList(categories, "Id", "Name");
        }

        public void AddProduct(CreateProductDTO productDto)
        {
            var product = new Product
            {
                ShopId = _context.Shops.Where(m => m.Account == productDto.Account).FirstOrDefault().Id,
                Name = productDto.Name,
                Price = productDto.Price,
                Info = productDto.Description,
                CategoryId = productDto.CategoryId,
                ProductImages = productDto.ImagePaths.Select(path => new ProductImage
                {
                    Path = path,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                }).ToList(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public List<ShopProductListVm> ShowShopProductList(string currentMerchant)
        {
            // 獲取當前商家的 ShopId
            var currentUserShopId = _context.Shops
                .Where(m => m.Account == currentMerchant)
                .Select(m => m.Id)
                .FirstOrDefault();

            // 從資料庫提取基本資料
            var products = _context.Products
                .Where(p => p.ShopId == currentUserShopId)
                .Select(p => new
                {
                    p.Id,
                    Category = p.Category.Name,
                    Name = p.Name,
                    Description = p.Info,
                    OriginalPrice = p.Price,
                    ImagePath = p.ProductImages.FirstOrDefault().Path,
                    IsGroupOpen = p.GroupBuyings.Any(m => m.Enabled)
                })
                .ToList();

            // 使用 FilePathHelper 處理資料
            var productList = products.Select(p => new ShopProductListVm
            {
                Id = p.Id,
                Category = p.Category,
                Name = p.Name,
                Description = p.Description,
                OriginalPrice = p.OriginalPrice,
                ImageUrl = p.ImagePath != null ? _filePathHelper.GetReadPath("Products", p.ImagePath) : null,
                IsGroupOpen = p.IsGroupOpen
            }).ToList();

            return productList;
        }
    }
}