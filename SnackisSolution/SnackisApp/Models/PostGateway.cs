using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SnackisApp.Models
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


        public Task<Post> DeletePost(int deleteId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetPosts()
        {
            throw new NotImplementedException();
        }

        public Task<Post> PostPost(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<Post> PutPost(int editId, Post post)
        {
            throw new NotImplementedException();
        }
    }
}
