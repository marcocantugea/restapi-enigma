using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using enigma_apis.Entities;
using enigma_apis.interfaces;
using RestSharp;

namespace enigma_apis
{
    public class JsonPlaceHolderAPICaller : iAPICaller
    {

        private string _response=null;
        private int _httpResponse;
        private bool _mockResponse;
        private string _mockResponseValue;
        private Exception _mockResponseException;
        private int _mockHttpResponse;

        private string _rootEndpoint = "";

        public string rootEndPoint { get => this.getRootEndPoint(); set => _rootEndpoint = value; }
        public string response => _response;
        public int httpResponse { get => _httpResponse; set => _httpResponse = value; }
        public bool mockResponse { get => _mockResponse; set => _mockResponse = value; }
        public string mockResponseValue { get => _mockResponseValue; set => _mockResponseValue=value; }
        public Exception mockResponseException { get => _mockResponseException; set => _mockResponseException=value; }
        public int mockHttpResponse { get => _mockHttpResponse; set => _mockHttpResponse = value; }

        public APIToken getToken()
        {
            throw new NotImplementedException();
        }

        public APIToken loadToken()
        {
            throw new NotImplementedException();
        }

        public void loadRootEndPoint()
        {
            this._rootEndpoint = "https://jsonplaceholder.typicode.com/";
        }

        private string getRootEndPoint()
        {
            this.loadRootEndPoint();
            return this._rootEndpoint;
        }

        public void  getTodosResource()
        {

            if (string.IsNullOrEmpty(this.getRootEndPoint())) return;

            string resource = this.getRootEndPoint() + "todos/1";

            RestClient client = new RestClient();
            RestRequest request = new RestRequest(resource,Method.Get);
            request.RequestFormat = DataFormat.Json;

            if (this._mockResponse)
            {
                this._response = this._mockResponseValue;
                if (this._mockResponseException != null) throw this._mockResponseException;
                this._httpResponse = this._mockHttpResponse;
                return;
            }

            var resp = client.ExecuteAsync(request).GetAwaiter().GetResult();

            this._response = resp.get_Content();
        }
    }
}
