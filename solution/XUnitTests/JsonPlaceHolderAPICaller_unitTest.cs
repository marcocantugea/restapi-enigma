using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using enigma_apis;

namespace apiCallers.JsonPlaceHolder
{
    public class JsonPlaceHolderAPICaller_unitTest
    {
        [Fact]
        public void testTest1()
        {
            JsonPlaceHolderAPICaller jsonPlaceHolder = new JsonPlaceHolderAPICaller();
        }

        [Fact]
        public void test_getTodosResource_emptyEndPoint()
        {
            JsonPlaceHolderAPICaller jsonPlaceHolder = new JsonPlaceHolderAPICaller();
            jsonPlaceHolder.rootEndPoint = "";

            jsonPlaceHolder.getTodosResource();
            bool response = (string.IsNullOrEmpty(jsonPlaceHolder.response))? false : true;

            Assert.True(response);
        }

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
    }
}
