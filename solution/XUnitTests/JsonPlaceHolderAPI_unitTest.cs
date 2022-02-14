using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using enigma_core.APIs;
using enigma_apis.JsonPlaceHolderAPI.schemas;

namespace XUnitTests.core.JsonPlaceHolderAPI_tests
{
    public class JsonPlaceHolderAPI_unitTest
    {
        private readonly ITestOutputHelper output;

        public JsonPlaceHolderAPI_unitTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void test_GetClass()
        {
            JsonPlaceHolderAPI jsonPlaceHolderAPI = new JsonPlaceHolderAPI();
        }

        [Fact]
        public async void test_getTodosResourceAsync() {

            JsonPlaceHolderAPI jsonPlaceHolderAPI = new JsonPlaceHolderAPI();
            TodosSchema response = await jsonPlaceHolderAPI.getTodosResourceAsync();

            Assert.IsType<TodosSchema>(response);
            Assert.Equal(response.id, 1);
            Assert.False(response.completed);

            output.WriteLine("userid: " + response.userId);
            output.WriteLine("id: " + response.id);
            output.WriteLine("title: " + response.title);
            output.WriteLine("completed: " + response.completed);

        }
    }
}
