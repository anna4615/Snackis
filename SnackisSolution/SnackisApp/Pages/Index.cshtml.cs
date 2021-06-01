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
        private readonly IForumGateway _forumGateway;
        private readonly ISubjectGateway _subjectGateway;
        private readonly IPostGateway _postGateway;

        public IndexModel(UserManager<SnackisUser> userManager,
            IForumGateway forumGateway, ISubjectGateway subjectGateway, IPostGateway postGateway)
        {
            _userManager = userManager;
            _forumGateway = forumGateway;
            _subjectGateway = subjectGateway;
            _postGateway = postGateway; ;
        }


        public async Task<IActionResult> OnGetAsync()
        {
            List<Forum> forums = await _forumGateway.GetForums();
            Forum forum = forums.FirstOrDefault();

            List<SnackisUser> users = _userManager.Users.ToList();

            List<Subject> subjects = await _subjectGateway.GetSubjects();

            if (subjects.Count() == 0)
            {
                subjects = HelpMethods.Content.CreateSubjectList(forum);

                foreach (var subject in subjects)
                {
                    await _subjectGateway.PostSubject(subject);
                }

                List<Subject> createdSubjects = await _subjectGateway.GetSubjects();

                List<Post> parentPosts = HelpMethods.Content.CreateParentPostsList(users, createdSubjects);

                foreach (var post in parentPosts)
                {
                    await _postGateway.PostPost(post);
                }

                List<Post> createdParentPosts = await _postGateway.GetPosts();

                List<Post> answers = HelpMethods.Content.CreateAnswers(users, createdParentPosts);

                foreach (var post in answers)
                {
                    await _postGateway.PostPost(post);
                }
            }

            return Page();
        }
    }
}
