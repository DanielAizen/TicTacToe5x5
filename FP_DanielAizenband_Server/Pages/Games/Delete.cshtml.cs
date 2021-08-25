using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FP_DanielAizenband_Server.Data;
using FP_DanielAizenband_Server.Model;

namespace FP_DanielAizenband_Server.Pages.Games
{
    public class DeleteModel : PageModel
    {
        private readonly FP_DanielAizenband_Server.Data.FP_DanielAizenband_ServerContext _context;

        public DeleteModel(FP_DanielAizenband_Server.Data.FP_DanielAizenband_ServerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblGames TblGames { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblGames = await _context.TblGames.FirstOrDefaultAsync(m => m.Id == id);

            if (TblGames == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblGames = await _context.TblGames.FindAsync(id);

            if (TblGames != null)
            {
                _context.TblGames.Remove(TblGames);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
