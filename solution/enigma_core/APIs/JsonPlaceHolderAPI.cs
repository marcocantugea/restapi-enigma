using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using enigma_apis.JsonPlaceHolderAPI;
using enigma_apis.JsonPlaceHolderAPI.schemas;

namespace enigma_core.APIs
{
    public class JsonPlaceHolderAPI
    {

        public async Task<TodosSchema> getTodosResourceAsync()
        {
            TodosSchema response = null;
            JsonPlaceHolderAPICaller apicaller = new JsonPlaceHolderAPICaller();
            try
            {
                await apicaller.getTodosResourceAsyc();
                response = JsonSerializer.Deserialize<TodosSchema>(apicaller.response);
            }
            catch (Exception)
            {

                throw;
            }

            return response;
        }

        public async Task<List<Post>> getPosts(int id = -1)
        {

            JsonPlaceHolderAPICaller apicaller = new JsonPlaceHolderAPICaller();

            var respuesta="";

            if (id > 0)
            {
                respuesta = await apicaller.getPostsAsync(id);
            }
            else
            {
                respuesta = await apicaller.getPostsAsync();
            }

            List<Post> posts = JsonSerializer.Deserialize<List<Post>>(respuesta);

            return posts;
            
        }

    }
}
