using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using System.Threading.Tasks;
using enigma_core.Database;


namespace XUnitTests.enigma_core_tests.Database
{
    public class ClientMysql_unitTest : ClientMysql
    {

        private readonly ITestOutputHelper output;

        public ClientMysql_unitTest(ITestOutputHelper output)
        {
            this.output = output;
            this.server = "localhost";
            this.db = "cunimed";
            this.user = "root";
            this.password = "root";
            createConnection();

        }

        [Fact]
        public void test_OpenAndCloseConnection_locahost()
        {

            try
            {
                openConnection();
                closeConnection();
                Assert.True(true);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
