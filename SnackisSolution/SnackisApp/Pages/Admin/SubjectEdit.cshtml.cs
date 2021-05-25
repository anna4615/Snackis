using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SnackisApp.Gateways;
using SnackisApp.Models;

namespace SnackisApp.Pages.Admin
{
    public class SubjectEditModel : PageModel
    {
        private readonly ISubjectGateway _subjectGateway;

        public SubjectEditModel(ISubjectGateway subjectGateway)
        {
            _subjectGateway = subjectGateway;
        }

        [BindProperty(SupportsGet = true)]
        public int SubjectEditId { get; set; }

        public Subject Subject { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            var subjects = await _subjectGateway.GetSubjects();
            Subject = subjects.ToList().FirstOrDefault(s => s.Id == SubjectEditId);

            if (Subject == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
