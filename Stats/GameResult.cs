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
        public double ConversionRate
        {
            // The value will only be calculated when we try to access it. 
            // Uses less memory. 
            // No setter = can't be overwritten by wrong value. 
            // protection from value for goals or shots changing, w/o updating Conversion rate.  
            // A good practice to use a calculation in properties when possible.
            get
            {
                return (double)Goals / GoalAttempts;
            }
        }
    }

    public enum HomeOrAway
    {
            Home,
            Away
    }
}
