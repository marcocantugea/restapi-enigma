using System;
using System.Collections.Generic;
using System.Text;

namespace enigma_apis.JsonPlaceHolderAPI.schemas
{
    public class Post
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
}
