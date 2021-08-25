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
    public class IndexModel : PageModel
    {
        private readonly FP_DanielAizenband_Server.Data.FP_DanielAizenband_ServerContext _context;

        public IndexModel(FP_DanielAizenband_Server.Data.FP_DanielAizenband_ServerContext context)
        {
            _context = context;
        }

        public IList<TblGames> TblGames { get;set; }

        public async Task OnGetAsync()
        {
            TblGames = await _context.TblGames.ToListAsync();
        }
    }
}
