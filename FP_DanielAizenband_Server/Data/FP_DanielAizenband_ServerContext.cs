using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FP_DanielAizenband_Server.Model;

namespace FP_DanielAizenband_Server.Data
{
    public class FP_DanielAizenband_ServerContext : DbContext
    {
        public FP_DanielAizenband_ServerContext (DbContextOptions<FP_DanielAizenband_ServerContext> options)
            : base(options)
        {
        }

        public DbSet<FP_DanielAizenband_Server.Model.TblPlayers> TblPlayers { get; set; }

        public DbSet<FP_DanielAizenband_Server.Model.TblGames> TblGames { get; set; }
    }
}
