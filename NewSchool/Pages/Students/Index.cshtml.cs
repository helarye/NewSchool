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
        
        public IndexModel(NewSchool.Data.SchoolContext context, IConfiguration configuration)//2-מוסיפים ירושה מהממשק
        //public IndexModel(NewSchool.Data.SchoolContext context)
        {
            _context = context;
        }
        
        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync(string searchString)//4-הוספת ארגומנט ערך משדה חיפוש
        {

            IQueryable<Student> StudentsIQ = from s in _context.Students
                                             select s;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                StudentsIQ = StudentsIQ.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstMidName.Contains(searchString));
            }
            //Student = await _context.Students.ToListAsync();
            Student = await StudentsIQ.ToListAsync();
        }
    }
}
