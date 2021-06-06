using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using SnackisApp.Areas.Identity.Data;
using SnackisApp.Gateways;
using SnackisApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SnackisApp.Data;

namespace SnackisApp.Pages
{
    public class PrivateMessageModel : PageModel
    {
        private readonly UserManager<SnackisUser> _userManager;
        private readonly SnackisContext _context;

        public PrivateMessageModel(
            UserManager<SnackisUser> userManager,
            SnackisContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public PrivateMessage Message { get; set; }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            Message.UserId = currentUser.Id;
            Message.Date = DateTime.UtcNow;

            _context.Add(Message);
            _context.SaveChanges();

            return Page();
        }
    }
}
