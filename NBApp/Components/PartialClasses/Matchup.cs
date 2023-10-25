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
                return $"{Team_Away_Score} - {Team_Home_Score}";
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
        public string StatusColor
        {
            get
            {
                if (Status == 1)
                {
                    return "Gray";
                }
                if (Status == -1)
                {
                    return "#FF009CFF";
                }
                else
                    return "Red";
            }
        }
    }
}
