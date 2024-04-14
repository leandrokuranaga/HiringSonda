using HiringSonda.Application.Person.Models.Response;
using HiringSonda.Application.Person.Services;
using HiringSonda.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace HiringSonda.Test.Api_Layer
{
    public class UserControllerTests
    {
        private readonly Mock<ILogger<UserController>> _mockLogger;
        private readonly Mock<IPersonService> _service;
        private readonly UserController _controller;

        public UserControllerTests()
        {
            _mockLogger = new Mock<ILogger<UserController>>();
            _service = new Mock<IPersonService>();
            _controller = new UserController(_mockLogger.Object, _service.Object);            
        }

        [Fact]
        public async Task Index()
        {
            #region Arrange
            var mockUserResponse = new List<UserResponse> 
            { 
                new() {Id = 1, FullName = "Leandro Kuranaga"}
            };

            _service
                .Setup(x => x.GetAllUsers())
                .ReturnsAsync(mockUserResponse);
            #endregion

            #region Act
            var result = _controller.Index();
            #endregion

            #region Assert
            var viewResult = Assert.IsType<ViewResult>(result.Result);
            Assert.Equal("~/Views/User/Index.cshtml", viewResult.ViewName);

            var model = Assert.IsAssignableFrom<IEnumerable<UserResponse>>(viewResult.Model);
            Assert.NotEmpty(model);
            #endregion
        }

        //[Fact]
        //public async Task RegisterPage()
        //{
        //    #region Arrange
        //    #endregion

        //    #region Act
        //    var result = _controller.RegisterPage();
        //    #endregion

        //    #region Assert
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //    Assert.Null(viewResult.ViewName);
        //    #endregion

        //}

        [Fact]
        public async Task RegisterUser()
        {
            #region Arrange


            #endregion
        }

    }
}
