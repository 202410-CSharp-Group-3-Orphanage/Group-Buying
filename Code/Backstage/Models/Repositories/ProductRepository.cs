using Backstage.Models.Dtos;
using Backstage.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Backstage.Models.Repositories
{
    public class ProductRepository
    {
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
    }
}