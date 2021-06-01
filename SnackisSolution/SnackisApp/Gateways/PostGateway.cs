using Microsoft.Extensions.Configuration;
using SnackisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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

        public async Task<Post> GetPost(int id)
        {
            var response = await _client.GetAsync(_configuration["PostsAPILocal"] + "/" + id);
            Post returnValue = await response.Content.ReadFromJsonAsync<Post>();

            return returnValue;
        }

        public async Task<Post> DeletePost(int deleteId)
        {
            var respons = await _client.DeleteAsync(_configuration["PostsAPILocal"] + "/" + deleteId);
            Post post = await respons.Content.ReadFromJsonAsync<Post>();

            return post;
        }


        public async Task<Post> PostPost(Post post)
        {
            var response = await _client.PostAsJsonAsync(_configuration["PostsAPILocal"], post);
            Post returnValue = await response.Content.ReadFromJsonAsync<Post>();

            return returnValue;
        }

        public async Task<Post> PutPost(int editId, Post post)
        {
            throw new NotImplementedException();
        }
    }
}
