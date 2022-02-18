using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Text.Json;
using System.Threading.Tasks;
using enigma_apis.Entities;
using enigma_apis.interfaces;
using RestSharp;
using enigma_apis.JsonPlaceHolderAPI.schemas;


namespace enigma_apis.JsonPlaceHolderAPI
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
            //TODO: get uri from config json file
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
                returnMockResponses();
                return;
            }

            var resp = client.ExecuteAsync(request).GetAwaiter().GetResult();

            this._response = resp.get_Content();
        }

        public async Task<string> getTodosResourceAsyc()
        {
            if (string.IsNullOrEmpty(this.getRootEndPoint())) return "";

            string resource = this.getRootEndPoint() + "todos/1";

            RestClient client = new RestClient();
            RestRequest request = new RestRequest(resource, Method.Get);
            request.RequestFormat = DataFormat.Json;

            if (this._mockResponse)
            {
                returnMockResponses();
                return this._mockResponseValue;
            }

            var resp = await client.ExecuteAsync(request);

            this._response = resp.get_Content();

            return this._response;
        }

        public void getPosts(int id=0)
        {
            if (string.IsNullOrEmpty(this.getRootEndPoint())) return;

            string resource = this.getRootEndPoint() + "posts";

            if(id>0) resource +="/" +id.ToString();

            RestClient client = new RestClient();
            RestRequest request = new RestRequest(resource, Method.Get);
            request.RequestFormat = DataFormat.Json;

            if (this._mockResponse)
            {
                returnMockResponses();
                return;
            }

            var resp = client.ExecuteAsync(request).GetAwaiter().GetResult();

            this._response = resp.get_Content();
        }

        public async Task<string> getPostsAsync(int id = 0)
        {
            if (string.IsNullOrEmpty(this.getRootEndPoint())) return "";

            string resource = this.getRootEndPoint() + "posts";

            if (id > 0) resource += "/" + id.ToString();

            RestClient client = new RestClient();
            RestRequest request = new RestRequest(resource, Method.Get);
            request.RequestFormat = DataFormat.Json;

            if (this._mockResponse)
            {
                returnMockResponses();
                return this._mockResponseValue;
            }

            var resp = await client.ExecuteAsync(request);

            this._response = resp.get_Content();

            return this._response;
        }

        public void addPost(Post Jsonbody)
        {
            if (string.IsNullOrEmpty(this.getRootEndPoint())) return;

            string resource = this.getRootEndPoint() + "posts";
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(resource, Method.Post);
            //request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            //request.AddParameter("application/json", Jsonbody, ParameterType.RequestBody);
            request.AddJsonBody(Jsonbody);

            //request.AddJsonBody(Jsonbody);

            if (this._mockResponse)
            {
                returnMockResponses();
                return;
            }

            var res = client.ExecutePostAsync(request).GetAwaiter().GetResult();

            _response = res.get_Content();

        }

        public async Task<string> addPostAsync(Post JsonBody)
        {
            if (string.IsNullOrEmpty(this.getRootEndPoint())) return "";
            string resource = this.getRootEndPoint() + "posts";
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(resource, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(JsonBody);
            if (this._mockResponse)
            {
                returnMockResponses();
                return _mockResponseValue;
            }

            var resp = await client.ExecuteAsync(request);

            this._response = resp.get_Content();

            return this._response;

        }

        protected void returnMockResponses()
        {
            this._response = this._mockResponseValue;
            if (this._mockResponseException != null) throw this._mockResponseException;
            this._httpResponse = this._mockHttpResponse;
            
        }
    }
}
