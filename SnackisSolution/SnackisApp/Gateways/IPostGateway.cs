using SnackisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackisApp.Gateways
{
    public interface IPostGateway
    {
        Task<List<Post>> GetPosts();
        Task<Post> PostPost(Post post);
        Task<Post> PutPost(int editId, Post post);
        Task<Post> DeletePost(int deleteId);
    }
}
