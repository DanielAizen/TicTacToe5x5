using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FP_DanielAizenband_Server.Data;
using FP_DanielAizenband_Server.Model;

namespace FP_DanielAizenband_Server.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblPlayersController : ControllerBase
    {
        private readonly FP_DanielAizenband_ServerContext _context;
        Random int_rnd = new Random();
       
        public TblPlayersController(FP_DanielAizenband_ServerContext context)
        {
            _context = context;
        }

        // GET: api/TblPlayers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPlayers>>> GetTblPlayers()
        {
            return await _context.TblPlayers.ToListAsync();
            
        }

        //GET: api/TblPlayers/rnd/15
        [HttpGet("rnd/{remain}")]
        public Task<int> GetRandomNumber(int remain)
        {
            int btn = int_rnd.Next(0, remain);

            return Task.FromResult(btn);

        }

        // GET: api/TblPlayers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPlayers>> GetTblPlayers(int id)
        {
            var tblPlayers = await _context.TblPlayers.FindAsync(id);

            if (tblPlayers == null)
            {
                return NotFound();
            }

            return tblPlayers;
        }

        // GET: api/TblPlayers/{username}/{password}
        [HttpGet("{username}/{password}")]
        public async Task<ActionResult<TblPlayers>> GetUsernameAndPassword(string username, string password)
        {
            var tblPlayers = await _context.TblPlayers.Select(p => p).ToListAsync();
            var is_username = tblPlayers.Where(p => p.Username.Trim().Equals(username)).ToList();
            if (is_username.Any())
            {
                var is_password = tblPlayers.Where(p => p.Username.Equals(is_username[0].Username) && p.Password.Trim().Equals(password)).ToList();
                if (is_password.Any())
                {
                    return is_password[0];
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }

        

        // POST: api/TblPlayers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblPlayers>> PostTblPlayers(TblPlayers tblPlayers)
        {
            _context.TblPlayers.Add(tblPlayers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPlayers", new { id = tblPlayers.Id }, tblPlayers);
        }

        // POST: api/TblGames
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblGames>> PostTblGames(TblGames tblGames)
        {
            _context.TblGames.Add(tblGames);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPlayers", new { id = tblGames.Id }, tblGames);
        }

        // DELETE: api/TblPlayers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblPlayers>> DeleteTblPlayers(int id)
        {
            var tblPlayers = await _context.TblPlayers.FindAsync(id);
            if (tblPlayers == null)
            {
                return NotFound();
            }

            _context.TblPlayers.Remove(tblPlayers);
            await _context.SaveChangesAsync();

            return tblPlayers;
        }

        private bool TblPlayersExists(int id)
        {
            return _context.TblPlayers.Any(e => e.Id == id);
        }
    }
}
