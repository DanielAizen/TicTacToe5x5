using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FP_DanielAizenband_Server.Data;
using FP_DanielAizenband_Server.Model;

namespace FP_DanielAizenband_Server.Pages.Players
{
    public class DetailsModel : PageModel
    {
        private readonly FP_DanielAizenband_Server.Data.FP_DanielAizenband_ServerContext _context;

        public DetailsModel(FP_DanielAizenband_Server.Data.FP_DanielAizenband_ServerContext context)
        {
            _context = context;
        }

        public TblPlayers TblPlayers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblPlayers = await _context.TblPlayers.FirstOrDefaultAsync(m => m.Id == id);

            if (TblPlayers == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
