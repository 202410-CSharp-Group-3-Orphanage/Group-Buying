using Backstage.Common;
using Backstage.Models.Dtos;
using Backstage.Models.Dtos.Products;
using Backstage.Models.EFModels;
using Backstage.Models.Repositories;
using Backstage.Models.ViewModels;
using Backstage.Models.ViewModels.Products;
using MT.Utilities.UploadFile;
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
        FilePathHelper _filePathHelper = new FilePathHelper();
        UploadFileHelper _uploadFileHelper = new UploadFileHelper();
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

        public EditProductVm GetProductById(int id)
        {
            var product = _productRepo.GetProductById(id);
            if (product == null) return null;

            return new EditProductVm
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Name = product.Name,
                Description = product.Info,
                Price = product.Price,
                ImageUrls = product.ProductImages.Select(img => img.Path).ToList()
            };
        }


        public void UpdateProduct(int id, EditProductVm model)
        {
            var imagePaths = model.Images?.Select(image =>
            {
                string relativePath = _filePathHelper.GetWritePath("Products");
                return _uploadFileHelper.SaveAs(relativePath, (MT.Utilities.UploadFile.Interfaces.IMyFile)image);
            }).ToList();

            var productDto = new UpdateProductDTO
            {
                Id = id,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                CategoryId = model.CategoryId,
                ImagePaths = imagePaths
            };

            _productRepo.UpdateProduct(productDto);
        }

        // 取得商品資訊以顯示在開團頁面
        public StartGroupBuyingVm GetProductByIdForGroupBuying(int id, string loggedInUserAccount)
        {
            object authorize = _productRepo.CheckStartGroupBuyingAuthorizeByAccount(id, loggedInUserAccount);
            if (authorize == null) throw new Exception("您無權限開團");
            var product = _productRepo.GetProductByIdForGroupBuying(id, loggedInUserAccount);

            if (product == null) return null;

            return new StartGroupBuyingVm
            {
                ProductId = product.Id,
                ProductName = product.Name,
                OriginalPrice = product.Price,
                ProductDescription = product.Info,
                CategoryName = product.Category.Name,
                ExistingImages = product.ProductImages.Select(img => img.Path).ToList()
            };
        }

        // 開始團購
        public void StartGroupBuying(StartGroupBuyingVm model)
        {
            var groupBuyingDto = new StartGroupBuyingDTO
            {
                ProductId = model.ProductId,
                MinimumGroupSize = model.MinimumGroupSize,
                Price = model.Price,
                Description = model.Description,
                StartDate = DateTime.Now,
                EndDate = model.EndDate
                
            };

            _productRepo.CreateGroupBuying(groupBuyingDto);
        }

        public List<GroupBuyingStatusViewModel> GetShopGroupBuyingStatus(int id)
        {
            return _productRepo.GetShopGroupBuyingStatus(id);
        }

        public int GetIdByAccount(string loggedInUserAccount)
        {
            return _productRepo.GetIdByAccount(loggedInUserAccount);
        }
    }
}