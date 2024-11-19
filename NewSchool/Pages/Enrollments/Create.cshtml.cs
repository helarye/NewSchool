using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewSchool.Data;
using NewSchool.Models;

namespace NewSchool.Pages.Enrollments
{
    public class CreateModel : PageModel
    {
        private readonly NewSchool.Data.SchoolContext _context;

        public CreateModel(NewSchool.Data.SchoolContext context)
        {
            _context = context;
        }


        public IActionResult OnGet()
        {
        ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Title");
        ViewData["StudentID"] = new SelectList(_context.Students, "ID", "LastName");
            return Page();
        }
        //LastName
        //Title

        [BindProperty]
        public Enrollment Enrollment { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Enrollments.Add(Enrollment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
