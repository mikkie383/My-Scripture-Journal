using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.MyScriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string BookSearch { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from b in _context.Scripture
                                            orderby b.Book
                                            select b.Book;

            var scripts = from n in _context.Scripture
                         select n;
            if (!string.IsNullOrEmpty(SearchString))
            {
                scripts = scripts.Where(s => s.Note.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(BookSearch))
            {
                scripts = scripts.Where(x => x.Book == BookSearch);
            }
            Books = new SelectList(await genreQuery.Distinct().ToListAsync());
            Scripture = await scripts
                                .OrderBy(b => b.Book)
                                .OrderBy(d => d.CreatedDate)
                                .ToListAsync();
        }
    }
}
