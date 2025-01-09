using Backstage.Models.Dtos;
using Backstage.Models.EFModels;
using Backstage.Models.Repositories;
using Backstage.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Backstage.Models.Services
{
    public class ProductService
    {
            private ProductRepository _productRepo;

        public ProductService(ProductRepository repo)
        {
            _productRepo = repo;
        }
        
        public void CreateProduct(CreateProductDTO productDto)
        {
            _productRepo.AddProduct(productDto);
        }

        public SelectList ShowCategories()
        {
            return _productRepo.ShowCategories();
        }

        public List<ShopProductListVm> ShowShopProductList(string currentMerchant)
        {
            var products = _productRepo.ShowShopProductList(currentMerchant);
            return products;
        }
    }
}