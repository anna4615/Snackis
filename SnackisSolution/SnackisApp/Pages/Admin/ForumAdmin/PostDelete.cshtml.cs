using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SnackisApp.Gateways;
using SnackisApp.Models;

namespace SnackisApp.Pages.Admin.ForumAdmin
{
    public class PostDeleteModel : PageModel
    {
        private readonly IPostGateway _postGateway;

        public PostDeleteModel(IPostGateway postGateway)
        {
            _postGateway = postGateway;
        }

        [BindProperty(SupportsGet = true)]
        public int PostId { get; set; }

        //[BindProperty(SupportsGet = true)]
        //public int DeletePostId { get; set; }


        public Post Post { get; set; }

        public async Task<IActionResult> OnGet()
        {
            if (PostId != 0)
            {
                Post = await _postGateway.GetPost(PostId);
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var post = await _postGateway.DeletePost(PostId);

            return Redirect($"./PostsView?SubjectId={post.SubjectId}");
        }
    }
}
