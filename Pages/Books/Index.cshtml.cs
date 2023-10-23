using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Aron_Simina_Lab2.Data;
using Aron_Simina_Lab2.Models;

namespace Aron_Simina_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Aron_Simina_Lab2.Data.Aron_Simina_Lab2Context _context;

        public IndexModel(Aron_Simina_Lab2.Data.Aron_Simina_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Book != null)
            {
                Book = await _context.Book
                    .Include(b => b.Publisher)
                    .ToListAsync();
            }
        }
    }
}
