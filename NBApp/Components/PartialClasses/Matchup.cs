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

        public string AwayQ1
        {
            get
            {
                var detail = App.DB.MatchupDetail.FirstOrDefault(x => x.MatchupId == Id && x.Quarter == 1);
                if (detail != null)
                {
                    return detail.Team_Away_Score.ToString();
                }
                else
                    return null;
            }
        }
        public string AwayQ2
        {
            get
            {
                var detail = App.DB.MatchupDetail.FirstOrDefault(x => x.MatchupId == Id && x.Quarter == 2);
                if (detail != null)
                {
                    return detail.Team_Away_Score.ToString();
                }
                else
                    return null;
            }
        }
        public string AwayQ3
        {
            get
            {
                var detail = App.DB.MatchupDetail.FirstOrDefault(x => x.MatchupId == Id && x.Quarter == 3);
                if (detail != null)
                {
                    return detail.Team_Away_Score.ToString();
                }
                else
                    return null;
            }
        }
        public string AwayQ4
        {
            get
            {
                var detail = App.DB.MatchupDetail.FirstOrDefault(x => x.MatchupId == Id && x.Quarter == 4);
                if (detail != null)
                {
                    return detail.Team_Away_Score.ToString();
                }
                else
                    return null;
            }
        }

        public string HomeQ1
        {
            get
            {
                var detail = App.DB.MatchupDetail.FirstOrDefault(x => x.MatchupId == Id && x.Quarter == 1);
                if (detail != null)
                {
                    return detail.Team_Home_Score.ToString();
                }
                else
                    return null;
            }
        }
        public string HomeQ2
        {
            get
            {
                var detail = App.DB.MatchupDetail.FirstOrDefault(x => x.MatchupId == Id && x.Quarter == 2);
                if (detail != null)
                {
                    return detail.Team_Home_Score.ToString();
                }
                else
                    return null;
            }
        }
        public string HomeQ3
        {
            get
            {
                var detail = App.DB.MatchupDetail.FirstOrDefault(x => x.MatchupId == Id && x.Quarter == 3);
                if (detail != null)
                {
                    return detail.Team_Home_Score.ToString();
                }
                else
                    return null;
            }
        }
        public string HomeQ4
        {
            get
            {
                var detail = App.DB.MatchupDetail.FirstOrDefault(x => x.MatchupId == Id && x.Quarter == 4);
                if (detail != null)
                {
                    return detail.Team_Home_Score.ToString();
                }
                else
                    return null;
            }
        }

        //Фиксить, нет подбора по командам
        public string FGAway
        {
            get
            {
                var Goal = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 3 && x.Team == Team);
                var Miss = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 4);
                return $"{Goal - Miss}";
            }
        }
        public string FG3Away
        {
            get
            {
                var Goal = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 5);
                var Miss = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 6);
                return $"{Goal - Miss}";
            }
        }
    }
}
