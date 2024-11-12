using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewSchool.Data;
using NewSchool.Models;

namespace NewSchool.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly NewSchool.Data.SchoolContext _context;

        public IndexModel(NewSchool.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Student = await _context.Students.ToListAsync();
        }
    }
}
