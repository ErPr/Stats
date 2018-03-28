using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stats
{
    public class GameResult
    {
        //GameDate,TeamName,HomeOrAway,Goals,GoalAttempts,ShotsOnGoal,ShotsOffGoal,PosessionPercent
        public DateTime GameDate { get; set; }
        public string TeamName { get; set; }
        //public string HomeOrAway { get; set; }
        public HomeOrAway HomeOrAway { get; set; }
        public int Goals { get; set; }
        public int GoalAttempts { get; set; }
        public int ShotsOnGoal { get; set; }
        public int ShotsOffGoal { get; set; }
        public double PocessionPercent { get; set; }
    }

    public enum HomeOrAway
    {
            Home,
            Away
    }
}
