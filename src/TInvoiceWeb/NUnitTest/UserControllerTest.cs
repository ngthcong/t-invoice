using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using TInvoiceWeb.Controllers;
using TInvoiceWeb.Data;
using TInvoiceWeb.Helpers;
using TInvoiceWeb.Interfaces;
using TInvoiceWeb.Models;
using TInvoiceWeb.Services;

namespace NUnitTest
{
    public class Tests
    {
        private Mock<IUserService> userServiceMock;
        private Mock<IRoleService> roleServiceMock;
        private Mock<IUserRepository> repositoryMock;
        private Mock<IOptions<AppSettings>> appSettingsMock;
        private Mock<IWebHostEnvironment> webHosting;
        private Mock<AuthenticateRequest> authenticateMock;
        private UserController userController;
        private UserService userService;
        [SetUp]
        public void Setup()
        {
            userServiceMock = new Mock<IUserService>();
            roleServiceMock = new Mock<IRoleService>();

            authenticateMock = new Mock<AuthenticateRequest>();
            repositoryMock = new Mock<IUserRepository>();
            appSettingsMock = new Mock<IOptions<AppSettings>>();
            webHosting = new Mock<IWebHostEnvironment>();
            userController = new UserController( userServiceMock.Object, roleServiceMock.Object);
            userService = new UserService(repositoryMock.Object, appSettingsMock.Object);
        }

        [Test]
        public void CreateUserReturnOkTest()
        {


            Employee UserIn = new Employee()
            {
                
                Email = "something@gmail.com",
                Password = "123123",
                Contact = "1231231231",
                FullName = "Someone Name",
                Note = ""
            };
            Employee UserOut = new Employee()
            {
                EmpId = 1,
                Email = "something@gmail.com",
                Contact = "1231231231",
                FullName = "Someone Name",
                Note = ""
            };


            userServiceMock.Setup(p => p.CreateUser(UserIn)).Returns(UserOut);
            var result = userController.CreateUser(UserIn);
            var ReturnResult = result as ObjectResult;
            userServiceMock.Verify(s => s.CreateUser(UserIn), Times.Once());
            Assert.AreEqual(200, ReturnResult.StatusCode);
        }
        [Test]
        public void CreateUserReturnConflictTest()
        {
            Employee UserIn = new Employee()
            {

                Email = "something@gmail.com",
                Password = "123123",
                Contact = "1231231231",
                FullName = "Someone Name",
                Note = ""
            };
            Employee UserOut = null;

            userServiceMock.Setup(p => p.CreateUser(UserIn)).Returns(UserOut);
            var result = userController.CreateUser(UserIn);
            var ReturnResult = result as ObjectResult;
            userServiceMock.Verify(s => s.CreateUser(UserIn), Times.Once());
            Assert.AreEqual(409, ReturnResult.StatusCode);
        }
        [Test]
        public void LoginUserOkTest()
        {
           
            bool remenber = true;
        
            Employee User = new Employee()
            {
                EmpId = 1,
                Email = "something@gmail.com",
                Password = "123123",
                Contact = "1231231231",
                FullName = "Someone Name",
                Note = "",
                Salt= "SALT"
            };
            AuthenticateRequest authen = new AuthenticateRequest()
            {
                Email = "something@gmail.com",
                Password = "123123"
            };
            string res = "asdasd" ;

            userServiceMock.Setup(p => p.GetUserByEmail(authen.Email)).Returns(User);
            userServiceMock.Setup(p => p.CheckPassword(User.Password, authen.Password, User.Salt)).Returns(true);
            userServiceMock.Setup(s => s.Authenticate(User.EmpId, User.Level, remenber)).Returns(res);

            userServiceMock.Verify(p => p.GetUserByEmail(authen.Email), Times.Once());
            userServiceMock.Verify(p => p.CheckPassword(User.Password, authen.Password, User.Salt),Times.Once());
            userServiceMock.Verify(s => s.Authenticate(User.EmpId,User.Level,remenber), Times.Once());
            var result = userController.Authenticate(authen);
            var ReturnResult = result as ObjectResult;
            

            Assert.AreEqual(200, ReturnResult.StatusCode);
        }

        [Test]
        public void LoginUserFailTest()
        {
            Employee User = new Employee()
            {
                EmpId = 1,
                Email = "something@gmail.com",
                Password = "123123",
                Contact = "1231231231",
                FullName = "Someone Name",
                Note = "",
                Salt = "SALT"
            };
            Employee UserNull = null;

            AuthenticateRequest authen = new AuthenticateRequest()
            {
                Email = "something@gmail.com",
                Password = "123123"
            };

            userServiceMock.Setup(p => p.GetUserByEmail(authen.Email)).Returns(UserNull);
            userServiceMock.Verify(p => p.GetUserByEmail(authen.Email), Times.Once());
     
            var result = userController.Authenticate(authen);
            var ReturnResult = result as StatusCodeResult;

            Assert.AreEqual(409, ReturnResult.StatusCode);
        }
        [Test]
        public void UpdateUserOkTest()
        {
            Employee NewUser = new Employee()
            {
                EmpId = 1,
                Email = "something@gmail.com",
                Contact = "1231231231",
                Password = "password",
                Level = 1,
                FullName = "Someone Name",
                Note = ""
            };
            Employee OldUser = new Employee()
            {
                EmpId = 1,
                Email = "something@gmail.com",
                Contact = "1231231231",
                Password = "password",
                Level = 1,
                FullName = "Someone Name",
                Note = ""
            };

            userServiceMock.Setup(p => p.GetUser(NewUser.EmpId)).Returns(OldUser);
            userServiceMock.Setup(p => p.CheckUserEmail(NewUser.Email,NewUser.EmpId)).Returns(false);

            var result = userController.UpdateUser(NewUser);
            var ReturnResult = result as ObjectResult;
            userServiceMock.Verify(s => s.UpdateUser(NewUser,OldUser), Times.Once());

            Assert.AreEqual(200, ReturnResult.StatusCode);
        }

        [Test]
        public void UpdateUserFailTest()
        {
            Employee UserIn = new Employee()
            {
                EmpId = 1,
                Email = "something@gmail.com",
                Contact = "1231231231",
                FullName = "Someone Name",
                Note = ""
            };
            Employee UserOut = null;

            userServiceMock.Setup(p => p.GetUser(UserIn.EmpId)).Returns(UserOut);
            var result = userController.UpdateUser(UserIn);
            var ReturnResult = result as BadRequestResult;
            userServiceMock.Verify(s => s.UpdateUser(UserIn,UserOut), Times.Once());

            Assert.AreEqual(400, ReturnResult.StatusCode);
        }

      


       
    }
}