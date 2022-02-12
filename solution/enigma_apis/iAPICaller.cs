using System;
using System.Collections.Generic;
using System.Text;
using enigma_apis.Entities;

namespace enigma_apis.interfaces
{
    interface iAPICaller
    {
        string rootEndPoint { get; set; }
        string response { get;}
        int httpResponse { get; set; }
        bool mockResponse { get; set; }
        string mockResponseValue { get; set; }
        int mockHttpResponse { get; set; }
        Exception mockResponseException { get; set; }

        APIToken loadToken();
        APIToken getToken();
        void loadRootEndPoint();
    }
}
