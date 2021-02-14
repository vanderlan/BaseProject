﻿using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using VBaseProject.Api.AutoMapper.Output;
using VBaseProject.Api.Controllers;
using VBaseProject.Entities.Domain;
using VBaseProject.Entities.Filter;
using VBaseProject.Entities.ValueObjects.Pagination;
using VBaseProject.Service.Interfaces;
using VBaseProject.Test.Controllers.BaseController;
using VBaseProject.Test.MotherObjects;
using Xunit;

namespace VBaseProject.Test.Controllers
{
    public class UsersControllerTestTest : BaseControllerTest
    {
        private UsersController usersController;

        public UsersControllerTestTest()
        {
            SetupServiceMock();
        }

        [Fact]
        public async Task GetUserValidTest()
        {
            var result = await usersController.Get(UserMotherObject.ValidAdminUser().PublicId);

            var contentResult = (OkObjectResult) result;
            var user = (UserOutput) contentResult.Value;

            Assert.IsType<OkObjectResult>(contentResult);
            Assert.Equal(200, contentResult.StatusCode);

            Assert.IsType<UserOutput>(contentResult.Value);
            Assert.Equal(UserMotherObject.ValidAdminUser().Email, user.Email);
            Assert.Equal(UserMotherObject.ValidAdminUser().FirstName, user.FirstName);
        }

        [Fact]
        public async Task CreateUserValidTest()
        {
            var result = await usersController.Post(UserMotherObject.ValidAdminUserInput());

            var contentResult = (CreatedResult) result;

            Assert.IsType<CreatedResult>(contentResult);
            Assert.Equal(201, contentResult.StatusCode);
        }


        [Fact]
        public async Task EditUserValidTest()
        {
            var result = await usersController.Put(UserMotherObject.ValidAdminUser().PublicId, UserMotherObject.ValidAdminUserInput());

            var contentResult = (AcceptedResult) result;

            Assert.IsType<AcceptedResult>(contentResult);
            Assert.Equal(202, contentResult.StatusCode);
        }

        [Fact]
        public async Task DeleteUserValidTest()
        {
            var result = await usersController.Delete(UserMotherObject.ValidAdminUser().PublicId);

            var contentResult = (NoContentResult)result;

            Assert.IsType<NoContentResult>(contentResult);
            Assert.Equal(204, contentResult.StatusCode);
        }

        [Fact]
        public async Task ListUsersTest()
        {
            var result = await usersController.Get(new UserFilter());

            var contentResult = (OkObjectResult) result;
            var userPagedList = (PagedList<UserOutput>) contentResult.Value;

            Assert.Equal(4, userPagedList.Count);
            Assert.Equal(200, contentResult.StatusCode);
        }


        private void SetupServiceMock()
        {
            var userServiceMock = new Mock<IUserService>();
            var userList = new List<User>
            {
                UserMotherObject.ValidAdminUser(),
                UserMotherObject.ValidAdminUser(),
                UserMotherObject.ValidAdminUser(),
                UserMotherObject.ValidAdminUser()
            };

            var userListPaginated = new PagedList<User>(userList, 4);

            userServiceMock.Setup(x => x.FindByIdAsync(UserMotherObject.ValidAdminUser().PublicId)).ReturnsAsync(UserMotherObject.ValidAdminUser());
            userServiceMock.Setup(x => x.AddAsync(UserMotherObject.ValidAdminUser())).ReturnsAsync(UserMotherObject.ValidAdminUser());
            userServiceMock.Setup(x => x.UpdateAsync(It.IsAny<User>())).Verifiable();
            userServiceMock.Setup(x => x.DeleteAsync(UserMotherObject.ValidAdminUser().PublicId)).Verifiable();
            userServiceMock.Setup(x => x.ListPaginate(It.IsAny<UserFilter>())).
                ReturnsAsync(userListPaginated);

            usersController = new UsersController(userServiceMock.Object, _mapper);
        }
    }
}
