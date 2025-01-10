﻿using Backstage.Common;
using Backstage.Models.Dtos;
using Backstage.Models.Dtos.Products;
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
using System.Data.Entity; 


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

        public Product GetProductById(int id)
        {
            return _context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefault(p => p.Id == id);
        }


        public void UpdateProduct(UpdateProductDTO productDto)
        {
            // 從資料庫查找商品
            var product = _context.Products.Include(p => p.ProductImages).FirstOrDefault(p => p.Id == productDto.Id);
            if (product == null)
            {
                throw new Exception("商品不存在");
            }

            // 更新商品基本資料
            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.Info = productDto.Description;
            product.CategoryId = productDto.CategoryId;
            product.UpdatedAt = DateTime.Now;

            // 更新商品圖片（假設刪除舊圖片並新增新圖片）
            if (productDto.ImagePaths != null && productDto.ImagePaths.Any())
            {
                // 刪除舊圖片
                _context.ProductImages.RemoveRange(product.ProductImages);

                // 新增新圖片
                var newImages = productDto.ImagePaths.Select(path => new ProductImage
                {
                    Path = path,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }).ToList();

                product.ProductImages = newImages;
            }

            // 保存更改
            _context.SaveChanges();
        }


        public object CheckStartGroupBuyingAuthorizeByAccount(int id, string loggedInUserAccount)
        {
            var account_id = _context.Shops
                .Where(m => m.Account == loggedInUserAccount)
                .Select(m => m.Id)
                .FirstOrDefault();

            return _context.Products.Where(m => m.Id == id).Where(n => n.ShopId == account_id).FirstOrDefault();
            
        }

        public Product GetProductByIdForGroupBuying(int id, string loggedInUserAccount)
        {
            return _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);
        }

        public void CreateGroupBuying(StartGroupBuyingDTO groupBuyingDto)
        {
            var groupBuying = new GroupBuying
            {
                ProductId = groupBuyingDto.ProductId,
                MinimumGroupSize = groupBuyingDto.MinimumGroupSize,
                Price = groupBuyingDto.Price,
                Description = groupBuyingDto.Description,
                StartDate = DateTime.Now,
                EndDate = groupBuyingDto.EndDate,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Enabled = true
            };
            Console.WriteLine($"Inserting GroupBuying with ProductId: {groupBuyingDto.ProductId}");
            _context.GroupBuyings.Add(groupBuying);
            _context.SaveChanges();
        }
    }
}