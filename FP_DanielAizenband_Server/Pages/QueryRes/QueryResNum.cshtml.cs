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
    public class QueryResNumModel : PageModel
    {
        private readonly FP_DanielAizenband_ServerContext _context;
        public QueryResNumModel(FP_DanielAizenband_ServerContext context)
        {
            _context = context;
        }

        public IList<TblPlayers> TblPlayers { get; set; }
        public IList<TblGames> TblGames { get; set; }
        public IList<PlayerGames> PlayerGame { get; set; }

        [BindProperty]
        public int PlayerId { get; set; }

        public class PlayerGames
        {
            public string Username { get; set; }
            public int NumOfGames { get; set; }
        }

        public async Task OnGetAsync()
        {
            TblPlayers = await _context.TblPlayers.ToListAsync();
            TblGames = await _context.TblGames.ToListAsync();
        }

        public async Task OnPostAsync(int query)
        {
            PlayerGame = await (from p in _context.TblPlayers
                                from g in _context.TblGames
                                where p.Id == g.PlayerId
                                select new PlayerGames
                                {
                                    Username = p.Username,
                                    NumOfGames = _context.TblGames.Count(gameCount => gameCount.PlayerId == p.Id)
                                }).Distinct().ToListAsync();
        }
    }
}

