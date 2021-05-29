using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SnackisApp.Areas.Identity.Data;
using SnackisApp.Gateways;
using SnackisApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackisApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<SnackisUser> _userManager;
        private readonly ISubjectGateway _subjectGateway;
        private readonly IPostGateway _postGateway;

        public IndexModel(UserManager<SnackisUser> userManager,
            ISubjectGateway subjectGateway, IPostGateway postGateway)
        {
            _userManager = userManager;
            _subjectGateway = subjectGateway;
            _postGateway = postGateway;
        }

        public Forum Forum { get; set; }

        public List<Post> Posts { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SubjectId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PostId { get; set; }

        [BindProperty]
        public Post Post { get; set; }



        public async Task<IActionResult> OnGetAsync()
        {

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            Post.UserId = user.Id;
            Post.SubjectId = 10;
            if (PostId != 0)
            {
                Post.PostId = PostId;
            }
            Post.Date = DateTime.UtcNow;
            Post.IsOffensiv = false;

            await _postGateway.PostPost(Post);

            return RedirectToPage("./Index");
        }
    }
}
