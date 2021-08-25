using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FP_DanielAizenband_Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FP_DanielAizenband_Server.Model;
using Microsoft.EntityFrameworkCore;

namespace FP_DanielAizenband_Server.Pages.Players
{
    public class QuireisModel : PageModel
    {
        private readonly FP_DanielAizenband_ServerContext _context;
        public QuireisModel(FP_DanielAizenband_ServerContext context)
        {
            _context = context;
        }

        public IList<TblPlayers> TblPlayers { get; set; }
        public IList<TblGames> TblGames { get; set; }

        public async Task OnGetAsync()
        {
            TblPlayers = await _context.TblPlayers.ToListAsync();
            TblGames = await _context.TblGames.ToListAsync();
        }

    }
}
