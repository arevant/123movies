using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Movies.Core.Service;
using Movies.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace Movies.Test
{
    [TestFixture]
    public class UserServiceTests
    {
        private IConfiguration _config;
        private Mock<IUserService> _mockUserService = new Mock<IUserService>();
        private Mock<ILogger<UserService>> _logger = new Mock<ILogger<UserService>>();

        [SetUp]
        public void Setup()
        {
            var myConfiguration = new Dictionary<string, string>
                                    {
                                        {"Jwt:Key", "C428A377979E395725A6A1A13A0CE0D25F1B30B7DAE0EFB06F26F79EDC149472"},
                                        {"Jwt:Issuer", "Movies.com"},
                                        {"Jwt:TokenLifetimeInMinutes", "10"}
                                    };

            _config = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();
        }

        [Test]
        public void GetTokenTest()
        {
            IdentityUser user = new IdentityUser
            {
                Id = "mov001",
                UserName = "movtest"
            };

            string token = "valid token";
            _mockUserService.Setup(m => m.GetToken(user))
                .Returns(token).Verifiable();

            var userService = new UserService(_config, _logger.Object);
            Assert.IsNotNull(userService);

            var response = userService.GetToken(user);
            Assert.IsNotNull(response);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void GetTokenTest_NullUserRequest()
        {
            try
            {
                string token = "valid token";
                _mockUserService.Setup(m => m.GetToken(null))
                    .Returns(token).Verifiable();

                var userService = new UserService(_config, _logger.Object);
                Assert.IsNotNull(userService);

                userService.GetToken(null);
                userService.GetToken(null);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("IdentityUser object can't be null"));
            }
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void GetTokenTest_EmptyUserId()
        {
            try
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "mov"
                };
                string token = "valid token";
                _mockUserService.Setup(m => m.GetToken(user))
                    .Returns(token).Verifiable();

                var userService = new UserService(_config, _logger.Object);
                Assert.IsNotNull(userService);

                userService.GetToken(user);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Empty UserId"));
            }
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void GetTokenTest_EmptyUserName()
        {
            try
            {
                IdentityUser user = new IdentityUser
                {
                    Id = "mov001"
                };
                string token = "valid token";
                _mockUserService.Setup(m => m.GetToken(user))
                    .Returns(token).Verifiable();

                var userService = new UserService(_config, _logger.Object);
                Assert.IsNotNull(userService);

                userService.GetToken(user);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Empty UserName"));
            }
        }
    }
}
