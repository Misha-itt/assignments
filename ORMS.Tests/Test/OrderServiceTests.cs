//using System;
//using System.Collections.Generic;
//using System.Text;
//using AutoMapper;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Logging;
//using Moq;
//using Project.Models;
//using Project.Repository.Interface;
//using Project.Services.Class;

//namespace ORMS.Tests.Test
//{
//    public class OrderServiceTests
//    {
//        private readonly Mock<IOrderRepository> _mockRepo;
//        private readonly Mock<IMapper> _mockMapper;
//        private readonly Mock<ILogger<OrderService>> _mockLogger;
//        private readonly OrderService _service;

//        public OrderServiceTests()
//        {
//            _mockRepo = new Mock<IOrderRepository>();
//            _mockMapper = new Mock<IMapper>();
//            _mockLogger = new Mock<ILogger<OrderService>>();

//            _service = new OrderService(
//                _mockRepo.Object,
//                _mockMapper.Object,
//                _mockLogger.Object
//            );
//        }


//        [Fact]
//        public void GetOrders_ShouldReturnMappedOrders()
//        {
            
//            var query = new OrderQueryParams();

//            var orders = new List<Orders>
//            {
//                new Orders { Id = 1 }
//            };

//            var mappedOrders = new List<OrderResponseDTO>
//            {
//                new OrderResponseDTO { Id = 1 }
//            };

//            _mockRepo.Setup(repo => repo.GetOrders(query)).Returns(orders);
//            _mockMapper.Setup(mapped => mapped.Map<List<OrderResponseDTO>>(orders))
//                       .Returns(mappedOrders);

//            var result = _service.GetOrders(query);

//            Assert.NotNull(result);
//            Assert.Single(result);
//            Assert.Equal(1, result[0].Id);
//        }

//        [Fact]
//        public void GetOrderSummary_ShouldReturnSummaryList()
//        {
           
//            var summary = new List<OrderSummaryDTO>
//            {
//                new OrderSummaryDTO()
//            };

//            _mockRepo.Setup(repo => repo.GetOrderSummary()).Returns(summary);

           
//            var result = _service.GetOrderSummary();

          
//            Assert.NotNull(result);
//            Assert.Single(result);
//        }

//        [Fact]
//        public void Update_ShouldReturnUpdatedOrder()
//        {
            
//            int id = 1;
//            var dto = new OrdersDTO();

//            var order = new Orders();
//            var updatedOrder = new Orders { Id = id };
//            var response = new OrderResponseDTO { Id = id };

//            _mockMapper.Setup(mapped => mapped.Map<Orders>(dto)).Returns(order);
//            _mockRepo.Setup(repo => repo.Update(id, order)).Returns(updatedOrder);
//            _mockMapper.Setup(mapped => mapped.Map<OrderResponseDTO>(updatedOrder))
//                       .Returns(response);

//            var result = _service.Update(id, dto);

//            Assert.NotNull(result);
//            Assert.Equal(id, result.Id);
//        }

//        [Fact]
//        public void Update_ShouldReturnNull_WhenOrderNotFound()
//        {
            
//            int id = 1;
//            var dto = new OrdersDTO();
//            var order = new Orders();

//            _mockMapper.Setup(mapped => mapped.Map<Orders>(dto)).Returns(order);
//            _mockRepo.Setup(repo => repo.Update(id, order)).Returns((Orders)null);

            
//            var result = _service.Update(id, dto);

            
//            Assert.Null(result);
//        }

//        [Fact]
//        public void Delete_ShouldReturnTrue_WhenDeleted()
//        {
           
//            int id = 1;
//            _mockRepo.Setup(repo => repo.Delete(id)).Returns(true);

        
//            var result = _service.Delete(id);

           
//            Assert.True(result);
//        }

//        [Fact]
//        public void Delete_ShouldReturnFalse_WhenNotDeleted()
//        {

//            int id = 2;
//            _mockRepo.Setup(repo => repo.Delete(id)).Returns(false);


//            var result = _service.Delete(id);


//            Assert.False(result);
//        }

//    }
//}
