using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using enigma_core.Models;
using enigma_core.Repository;
using enigma_core.Models;

namespace XUnitTests.Repositories.enigma_core_tests.Repositories
{
   
    public class UserRepository_unitTest
    {
        private readonly ITestOutputHelper output;

        public UserRepository_unitTest(ITestOutputHelper output)
        {
            this.output = output;

        }

        [Fact]
        public void test_GetItemById_getUser()
        {
            UserRepository repo = new UserRepository();

            User userfound = repo.GetItemById(1);

            Assert.Equal("marco", userfound.userlogin);
        }

        [Fact]
        public async void test_getAllUsers_getusers()
        {
            UserRepository repo = new UserRepository();

            List<User> users = await repo.GetAllAsync(10);

            Assert.True(users.Count > 0);

        }

        [Fact]
        public async void test_loginUserAsync_loginFail()
        {
            UserRepository repo = new UserRepository();

            User loginSettings = new User();
            loginSettings.userlogin = "marcocantugea";
            loginSettings.password = "thisisthepassword";

            User userlogin = await repo.loginUserAsync(loginSettings);

            Assert.Null(userlogin);

        }

        [Fact]
        public async void test_loginUserAsync_loginSuccess()
        {
            UserRepository repo = new UserRepository();

            User loginSettings = new User();
            loginSettings.userlogin = "marco";
            loginSettings.password = "koko";

            User userlogin = await repo.loginUserAsync(loginSettings);

            Assert.NotNull(userlogin);

        }
    }
    
}
