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
    }
}
