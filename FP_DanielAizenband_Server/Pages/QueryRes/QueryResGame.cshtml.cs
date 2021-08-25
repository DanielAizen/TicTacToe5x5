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
    public class QueryResGameModel : PageModel
    {
        private readonly FP_DanielAizenband_ServerContext _context;
        public QueryResGameModel(FP_DanielAizenband_ServerContext context)
        {
            _context = context;
        }

        public IList<TblPlayers> TblPlayers { get; set; }
        public IList<TblGames> TblGames { get; set; }
        
        [BindProperty]
        public string Selected_Pid { get; set; }

        public async Task OnGetAsync()
        {
            TblPlayers = await _context.TblPlayers.ToListAsync();
            TblGames = await _context.TblGames.ToListAsync();
        }

        public async Task OnPostAsync(int query)
        {
            if (query == 2)
                TblGames = await _context.TblGames.Select(game => game).ToListAsync();
            else if (query == 3)
            {
                Selected_Pid = Selected_Pid.Split(" ")[0];
                
                TblGames = await (from g in _context.TblGames
                                  where Int32.Parse(Selected_Pid) == g.PlayerId
                                  select g).ToListAsync();
            }
        }
    }
}
