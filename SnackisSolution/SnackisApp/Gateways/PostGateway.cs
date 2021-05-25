using Microsoft.Extensions.Configuration;
using SnackisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SnackisApp.Gateways
{
    public class PostGateway : IPostGateway
    {

        private readonly IConfiguration _configuration;
        private readonly HttpClient _client;

        public PostGateway(IConfiguration configuration, HttpClient client)
        {
            _configuration = configuration;
            _client = client;
        }

        public async Task<List<Post>> GetPosts()
        {
            var response = await _client.GetAsync(_configuration["PostsAPILocal"]);
            string apiResponse = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<Post>>(apiResponse);
        }

        public async Task<Post> DeletePost(int deleteId)
        {
            throw new NotImplementedException();
        }


        public async Task<Post> PostPost(Post post)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> PutPost(int editId, Post post)
        {
            throw new NotImplementedException();
        }
    }
}
