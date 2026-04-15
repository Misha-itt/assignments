//using System;
//using System.Collections.Generic;
//using System.Text;
//using AutoMapper;
//using Microsoft.Extensions.Logging;
//using Moq;
//using Project.Models;
//using Project.Services.Class;
//using Project.Services.Interface;

//namespace ORMS.Tests.Test
//{
//    public class UserServiceTests
//    {

//        private readonly Mock<IUserRepository> _mockRepo;
//       private readonly Mock<IJWTService> _mockJwt;
//        private readonly Mock<IMapper> _mockMapper;
//        private readonly Mock<ILogger<UserService>> _mockLogger;
//        private readonly UserService _service;

//        public UserServiceTests()
//        {
//            _mockRepo = new Mock<IUserRepository>();
//            _mockJwt = new Mock<IJWTService>();
//            _mockMapper = new Mock<IMapper>();
//            _mockLogger = new Mock<ILogger<UserService>>();

//            _service = new UserService(
//                _mockRepo.Object,
//                _mockJwt.Object,
//                _mockMapper.Object,
//                _mockLogger.Object
//            );
//        }

//        [Fact]
//        public async Task RegisterAsync_ShouldCreateUser_WhenEmailNotExists()
//        {
            
//            string email = "misha123@gmail.com";

//            _mockRepo.Setup(repo => repo.GetByEmailAsync(email))
//                     .ReturnsAsync((User)null);

//            _mockRepo.Setup(repo => repo.AddUserAsync(It.IsAny<User>()))
//                     .ReturnsAsync((User user) => user);

           
//            var result = await _service.RegisterAsync(
//                "Misha", email, "password123", "9876543212"
//            );

         
//            Assert.NotNull(result);
//            Assert.Equal(email, result.Email);
//        }

//        [Fact]
//        public async Task RegisterAsync_ShouldReturnNull_WhenEmailExists()
//        {
            
//            string email = "misha123@gmail.com";

//            _mockRepo.Setup(repo => repo.GetByEmailAsync(email))
//                     .ReturnsAsync(new User());

           
//            var result = await _service.RegisterAsync(
//                "Misha", email, "password123", "9876543212"
//            );

           
//            Assert.Null(result);
//        }

//        public async Task LoginAsync_ShouldReturnToken_WhenCredentialIsValid()

//        {
//            string email = "misha123@gmail.com";
//            string password 
//        }
//    }
//}
