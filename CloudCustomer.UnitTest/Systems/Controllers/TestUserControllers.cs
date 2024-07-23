using CloudCustomer.API.Controllers;
using CloudCustomer.API.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CloudCustomer.UnitTest.Systems.Controllers;

public class TestUserControllers
{
    [Fact]
    public async Task Get_OnSuccess_ReturnStatusCode200()
    {
        //Arrange
        var mockUserService = new Mock<IUsersService>();
        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());
        var sut = new UserControllers(mockUserService.Object);
        //Act
        var result =(OkObjectResult)await sut.GetResult();

        //Assert

        result.StatusCode.Should().Be(200);
        
    }

    [Fact]
    public async Task Get_OnSuccess_InvokesUserServiceExactlyOnce()
    {

        var mockUserService = new Mock<IUsersService>();
        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());

        var sut = new UserControllers(mockUserService.Object);


        var result = await sut.GetResult();

        mockUserService.Verify(service => service.GetAllUsers(), Times.Once());
    }

 
}