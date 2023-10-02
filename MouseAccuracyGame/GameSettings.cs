using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAccuracyGame
{
    public class GameSettings
    {
        public string CurrentSize { get; set; } = "Tiny";
        public int CurrentTime { get; set; } = 15;
        public string CurrentCursor { get; set; } = "Plus";
        public string CurrentDifficulty { get; set; } = "Easy";
        public string CurrentColor { get; set; } = "darkPink";
        public bool IsSoundOn { get; set; } = true;
    }
}
