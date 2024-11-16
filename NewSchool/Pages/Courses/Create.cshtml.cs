using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewSchool.Data;
using NewSchool.Models;

namespace NewSchool.Pages.Courses
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
            return Page();
        }

        [BindProperty]//תגית המבטיחה שהעמוד יעלה עבור מחלקה שקשורה אליו
        //Cources במקרה שלנו
        public Course Course { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
