using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SnackisApp.Areas.Identity.Data;

namespace SnackisApp.Pages.Admin.UserAdmin
{
    public class UsersModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public readonly UserManager<SnackisUser> _userManager;

        public UsersModel(RoleManager<IdentityRole> roleManager, UserManager<SnackisUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        //public bool IsAdmin { get; set; }
        //public bool IsMember { get; set; }

        public SnackisUser CurrentUser { get; set; }
        public List<SnackisUser> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }


        [BindProperty(SupportsGet = true)]
        public string RemoveUserId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string AddUserId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Role { get; set; }

        public bool IsLastAdmin { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            //IsAdmin = await _userManager.IsInRoleAsync(CurrentUser, "Admin");
            //IsMember = await _userManager.IsInRoleAsync(CurrentUser, "Medlem");

            Users = _userManager.Users.ToList();
            Roles = _roleManager.Roles.ToList();

            IList<SnackisUser> adminSearch = await _userManager.GetUsersInRoleAsync("Admin");
            int numberOfAdmins = adminSearch.Count();

            IsLastAdmin = false;

            if (RemoveUserId != null)
            {
                if (numberOfAdmins <= 1 && Role == "Admin")
                {
                    IsLastAdmin = true;
                }
                else
                {
                    SnackisUser user = await _userManager.FindByIdAsync(RemoveUserId);
                    IdentityResult result = await _userManager.RemoveFromRoleAsync(user, Role);
                }
            }

            if (AddUserId != null)
            {
                SnackisUser user = await _userManager.FindByIdAsync(AddUserId);
                IdentityResult result = await _userManager.AddToRoleAsync(user, Role);
            }

            return Page();
        }
    }
}
