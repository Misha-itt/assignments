using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Project.Services.Class;
using Project.Repository.Interface;
using Project.Services.Interface;

namespace ORMS.Tests.Test
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<ProductService>> _mockLogger;
        private readonly ProductService _service;

        public ProductServiceTests()
        {
            _mockRepo = new Mock<IProductRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<ProductService>>();

            _service = new ProductService(
                _mockRepo.Object,
                _mockMapper.Object,
                _mockLogger.Object
            );
        }

        [Fact]
        public void Get_ShouldReturnProduct()
        {
            var query = new ProductQueryParams();
            var products = new List<Product>
            {
                new Product {Id = 1, Pname ="Laptop"}
            };

            var mappedProduct = new List<ProductResponseDTO>
            {
                new ProductResponseDTO {Id = 1  , Pname = "Laptop"}
            };

            _mockRepo.Setup(repo => repo.Get(query)).Returns(products);
            _mockMapper.Setup(mapped => mapped.Map<List<ProductResponseDTO>>(products)).Returns(mappedProduct);

            var result = _service.Get(query);

            Assert.NotNull(result);
            Assert.Equal("laptop", result[0].Pname);

        }

        [Fact]
        public void GetProductSalesSummary_ShouldReturnSummary()
        {
            
            var summary = new List<ProductSalesDTO>
             {
                 new ProductSalesDTO { ProductName = "Laptop", TotalRevenue = 10 }
             };

            _mockRepo.Setup(repo => repo.GetProductSalesSummary()).Returns(summary);

         
            var result = _service.GetProductSalesSummary();

            
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Laptop", result[0].ProductName);
        }

        [Fact]
        public void Update_ShouldReturnUpdatedProduct()
        {
            var id = 1;
          var dto = new ProductDTO { Pname = "Phone" };
            var product = new Product { Id = id, Pname = "Phone" };
            _mockMapper.Setup (mapper =>mapper.Map<Product>(dto)).Returns(product);
            _mockRepo.Setup(repo => repo.Update(id, product)).Returns(product);

            var result = _service.Update(id, dto); 
            Assert.NotNull(result);
            Assert.Equal("Phone", result.Pname);
        }

        [Fact]
        public void Delete_ShouldReturnTrue()
        {
            _mockRepo.Setup(repo => repo.Delete(1)).Returns(true);

            var result = _service.Delete(1);

            Assert.True(result);
        }

        [Fact]
        public void Delete_ShouldReturnFalse_WhenNotDeleted()
        {
            int id = 2;

            _mockRepo.Setup(repo => repo.Delete(id)).Returns(false);

            var result = _service.Delete(id);

            Assert.False(result);
        }
    }
}
