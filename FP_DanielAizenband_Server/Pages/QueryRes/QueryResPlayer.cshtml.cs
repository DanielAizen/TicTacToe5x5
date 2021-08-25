using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FP_DanielAizenband_Server.Data;
using FP_DanielAizenband_Server.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FP_DanielAizenband_Server.Pages.QueryRes
{
    public class QueryResPlayerModel : PageModel
    {
        private readonly FP_DanielAizenband_ServerContext _context;
        public QueryResPlayerModel(FP_DanielAizenband_ServerContext context)
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

        public async Task OnPostAsync(int query)
        {
            TblPlayers = await _context.TblPlayers.Select(player => player).ToListAsync();
            
        }
    }
}
