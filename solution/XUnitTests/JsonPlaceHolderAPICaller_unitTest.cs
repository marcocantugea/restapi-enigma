using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using enigma_apis.JsonPlaceHolderAPI;
using Xunit.Abstractions;

namespace apiCallers.JsonPlaceHolder
{
    public class JsonPlaceHolderAPICaller_unitTest
    {
        private readonly ITestOutputHelper output;

        public JsonPlaceHolderAPICaller_unitTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void testTest1()
        {
            JsonPlaceHolderAPICaller jsonPlaceHolder = new JsonPlaceHolderAPICaller();
        }

        //[Fact]
        //public void test_getTodosResource_emptyEndPoint()
        //{
        //    JsonPlaceHolderAPICaller jsonPlaceHolder = new JsonPlaceHolderAPICaller();
        //    jsonPlaceHolder.rootEndPoint = "";

        //    jsonPlaceHolder.getTodosResource();
        //    bool response = (string.IsNullOrEmpty(jsonPlaceHolder.response))? false : true;

        //    Assert.True(response);
        //}

        [Fact]
        public void test_getTodosResource_getMockResponseException()
        {
            JsonPlaceHolderAPICaller jsonPlaceHolder = new JsonPlaceHolderAPICaller();
            jsonPlaceHolder.mockResponse = true;
            jsonPlaceHolder.mockResponseException = new Exception("esta es una excepcion");


            try
            {
                jsonPlaceHolder.getTodosResource();
            }
            catch (Exception)
            {
                //throw;
                Assert.True(true);
            }           
        }

        [Fact]
        public void test_getTodosResource_getMockResponse()
        {
            JsonPlaceHolderAPICaller jsonPlaceHolder = new JsonPlaceHolderAPICaller();
            jsonPlaceHolder.mockResponse = true;
            jsonPlaceHolder.mockResponseValue = "{\"userId\": 1,\"id\": 1,\"title\": \"delectus aut autem\",\"completed\": false}";
            jsonPlaceHolder.mockHttpResponse = 200;
            
            try
            {
                jsonPlaceHolder.getTodosResource();
                var respuesta = jsonPlaceHolder.response;
                bool valido = (string.IsNullOrEmpty(respuesta)) ? false : true;
                Assert.True(valido);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Fact]
        public void test_getTodosResource_getRealResponse()
        {
            JsonPlaceHolderAPICaller jsonPlaceHolder = new JsonPlaceHolderAPICaller();
            try
            {
                jsonPlaceHolder.getTodosResource();
                var respuesta = jsonPlaceHolder.response;
                bool valido = (string.IsNullOrEmpty(respuesta)) ? false : true;
                Assert.True(valido);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Fact]
        public async void test_getRodosResourceAsync()
        {
            JsonPlaceHolderAPICaller jsonPlaceHolder = new JsonPlaceHolderAPICaller();
            try
            {
                await jsonPlaceHolder.getTodosResourceAsyc();
                var respuesta = jsonPlaceHolder.response;
                bool valido = (string.IsNullOrEmpty(respuesta)) ? false : true;
                Assert.True(valido);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Fact]
        public void test_getPosts_noId()
        {
            JsonPlaceHolderAPICaller jsonPlaceHolder = new JsonPlaceHolderAPICaller();
            jsonPlaceHolder.mockResponse = true;
            jsonPlaceHolder.mockResponseValue = getMockReponsePosts();
            try
            {
                jsonPlaceHolder.getPosts();
                var respuesta = jsonPlaceHolder.response;
                Assert.Contains("doloremque ex facilis sit sint culpa", respuesta);
                this.output.WriteLine(respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Fact]
        public void test_getPosts_getId()
        {
            JsonPlaceHolderAPICaller jsonPlaceHolder = new JsonPlaceHolderAPICaller();
            try
            {
                jsonPlaceHolder.getPosts(98);
                var respuesta = jsonPlaceHolder.response;
                Assert.Contains("doloremque ex facilis sit sint culpa", respuesta);
                this.output.WriteLine(respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [Fact]
        public async void test_getPostsAsync_getId()
        {
            JsonPlaceHolderAPICaller jsonPlaceHolder = new JsonPlaceHolderAPICaller();
            try
            {
                await jsonPlaceHolder.getPostsAsync(98);
                var respuesta = jsonPlaceHolder.response;
                Assert.Contains("doloremque ex facilis sit sint culpa", respuesta);
                this.output.WriteLine(respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected string getMockReponsePosts()
        {
            string response = 
                             @"[
                              {
                                ""userId"": 10,
                                ""id"": 98,
                                ""title"": ""laboriosam dolor voluptates"",
                                ""body"": ""doloremque ex facilis sit sint culpa\nsoluta assumenda eligendi non ut eius\nsequi ducimus vel quasi\nveritatis est dolores""
                              },
                              {
                                ""userId"": 10,
                                ""id"": 99,
                                ""title"": ""temporibus sit alias delectus eligendi possimus magni"",
                                ""body"": ""quo deleniti praesentium dicta non quod\naut est molestias\nmolestias et officia quis nihil\nitaque dolorem quia""
                              },
                              {
                                ""userId"": 10,
                                ""id"": 100,
                                ""title"": ""at nam consequatur ea labore ea harum"",
                                ""body"": ""cupiditate quo est a modi nesciunt soluta\nipsa voluptas error itaque dicta in\nautem qui minus magnam et distinctio eum\naccusamus ratione error aut""
                              }
                            ]
                            ";
            return response;
        }
    }
}
