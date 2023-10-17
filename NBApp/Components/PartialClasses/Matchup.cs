using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBApp.Components
{
    public partial class Matchup
    {
        public string Scores
        {
            get
            {
                return $"{Team_Home_Score} - {Team_Away_Score}";
            }
        }

        public string StatusName
        {
            get
            {
                if(Status == 1)
                {
                    return "Finished";
                }
                if (Status == -1)
                {
                    return "Not Start";
                }
                else
                    return null;
            }
        }
    }
}
