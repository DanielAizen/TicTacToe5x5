using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_DanielAizenband_Client
{
    class Recording
    {
        public int Id { get; set; }
        public int NumOfTurns { get; set; }
        
        public string[] playerMoves = new string[25];
        public string PlayerMoves { get; set; }
        public int PlayerId { get; set; }
        public string Winner { get; set; }
        
    }
}
