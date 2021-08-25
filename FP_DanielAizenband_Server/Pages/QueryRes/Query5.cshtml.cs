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
    public class Query5Model : PageModel
    {
        private readonly FP_DanielAizenband_ServerContext _context;
        public Query5Model(FP_DanielAizenband_ServerContext context)
        {
            _context = context;
        }

        public IList<TblPlayers> TblPlayers { get; set; }
        public IList<TblGames> TblGames { get; set; }
        public IList<PlayerGamesTable> PlayerGameTbl { get; set; }


        public class PlayerGamesTable
        {
            public TblPlayers TblP { get; set; }
            public int? NumOfGames { get; set; }
        }

        public async Task OnGetAsync()
        {
            TblPlayers = await _context.TblPlayers.ToListAsync();
            TblGames = await _context.TblGames.ToListAsync();
        }

        public async Task OnPostAsync(int query)
        {
            TblGames = await _context.TblGames.Select(g => g).ToListAsync();
            List<TblPlayers> Tbl_player = await _context.TblPlayers.Select(p => p).ToListAsync();
            Dictionary<int, int> games_count_and_index = new Dictionary<int, int>();

            foreach (var Player in Tbl_player)
            {
                int games_count = TblGames.Count(game => game.PlayerId == Player.Id);
                games_count_and_index.Add(Player.Id, games_count);
            }
            PlayerGameTbl = await _context.TblPlayers.Select(player => new PlayerGamesTable
            {
                TblP = player,
                NumOfGames = games_count_and_index[player.Id]
            }).ToListAsync();

            PlayerGameTbl = PlayerGameTbl.OrderByDescending(row => row.NumOfGames).ToList();

        }
    }
}
