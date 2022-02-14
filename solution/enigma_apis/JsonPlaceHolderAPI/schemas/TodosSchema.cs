using System;
using System.Collections.Generic;
using System.Text;

namespace enigma_apis.JsonPlaceHolderAPI.schemas
{
    public class TodosSchema
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
    }
}
