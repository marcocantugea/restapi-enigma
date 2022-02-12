using System;
using System.Collections.Generic;
using System.Text;

namespace enigma_apis.Entities
{
    public class APIToken
    {

        private string token;
        private DateTime timeacquired;
        private Int16 expireInSeconds;
        private DateTime expireInTime;

        public string Token { get => token; set => token = value; }
        public DateTime TimeAcquired { get => timeacquired; set => timeacquired = value; }
        public Int16 ExpireInSeconds { get => expireInSeconds; set => expireInSeconds = value; }
        public DateTime ExpireInTime { get => expireInTime; set => expireInTime = value; }


    }
}
