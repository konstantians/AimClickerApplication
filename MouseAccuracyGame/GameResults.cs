using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseAccuracyGame
{
    public class GameResults
    {
        public int TargetsCount{ get; set; }
        public int ClickCount { get; set; }
        public int ClickAccuracy { get; set; }
        public int TargetAccuracy { get; set; }
        public int TargetsHit { get; set; }
        public int Bonus { get; set; }
        public int TotalScore { get; set; }
    }
}
