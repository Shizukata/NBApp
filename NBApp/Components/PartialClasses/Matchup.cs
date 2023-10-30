using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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

        
        public string FGAway
        {
            get
            {
                int Goal = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 3 && x.TeamId == Team_Away);
                int Miss = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 4 && x.TeamId == Team_Away);
                return $"{Goal} - {Miss}";
            }
        }
        public string FG3Away
        {
            get
            {
                var Goal = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 5 && x.TeamId == Team_Away);
                var Miss = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 6 && x.TeamId == Team_Away);
                return $"{Goal} - {Miss}";
            }
        }
        public string FTAway
        {
            get
            {
                var Goal = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 7 && x.TeamId == Team_Away);
                var Miss = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 8 && x.TeamId == Team_Away);
                return $"{Goal}  -  {Miss}";
            }
        }
        
        public string ReboundsAway
        {
            get
            {
                var Goal = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 9 && x.TeamId == Team_Away);
                var Miss = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 10 && x.TeamId == Team_Away);
                return $"{Goal + Miss}";
            }
        }

        public string AssitsAway
        {
            get
            {
                var Goal = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 11 && x.TeamId == Team_Away);
                return $"{Goal}";
            }
        }
        public string StealsAway
        {
            get
            {
                var Goal = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 12 && x.TeamId == Team_Away);
                return $"{Goal}";
            }
        }
        public string BlocksAway
        {
            get
            {
                var Goal = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 13 && x.TeamId == Team_Away);
                return $"{Goal}";
            }
        }

        public string TurnoversAway
        {
            get
            {
                var Goal = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 14 && x.TeamId == Team_Away);
                return $"{Goal}";
            }
        }

        //Home
        public string FGHome
        {
            get
            {
                int Goal = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 3 && x.TeamId == Team_Home);
                int Miss = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 4 && x.TeamId == Team_Home);
                return $"{Goal} - {Miss}";
            }
        }
        public string FG3Home
        {
            get
            {
                var Goal = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 5 && x.TeamId == Team_Home);
                var Miss = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 6 && x.TeamId == Team_Home);
                return $"{Goal} - {Miss}";
            }
        }
        public string FTHome
        {
            get
            {
                var Goal = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 7 && x.TeamId == Team_Home);
                var Miss = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 8 && x.TeamId == Team_Home);
                return $"{Goal}  -  {Miss}";
            }
        }

        public string ReboundsHome
        {
            get
            {
                var Goal = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 9 && x.TeamId == Team_Home);
                var Miss = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 10 && x.TeamId == Team_Home);
                return $"{Goal + Miss}";
            }
        }

        public string AssitsHome
        {
            get
            {
                var Goal = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 11 && x.TeamId == Team_Home);
                return $"{Goal}";
            }
        }
        public string StealsHome
        {
            get
            {
                var Goal = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 12 && x.TeamId == Team_Home);
                return $"{Goal}";
            }
        }
        public string BlocksHome
        {
            get
            {
                var Goal = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 13 && x.TeamId == Team_Home);
                return $"{Goal}";
            }
        }

        public string TurnoversHome
        {
            get
            {
                var Goal = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 14 && x.TeamId == Team_Home);
                return $"{Goal}";
            }
        }

        public double GoalPercentAway
        {
            get
            {
                double Goal = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 3 && x.TeamId == Team_Away);
                double Miss = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 4 && x.TeamId == Team_Away);
                if (Goal >= Miss)
                {
                    return Math.Round((Miss / Goal * 100), 2);
                }
                else
                {
                    return Math.Round((Goal / Miss * 100), 2);
                }
            }
        }
        public double ThreeGoalPercentAway
        {
            get
            {
                double Goal = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 5 && x.TeamId == Team_Away);
                double Miss = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 6 && x.TeamId == Team_Away);
                if (Goal >= Miss)
                {
                    return Math.Round((Miss / Goal * 100), 2);
                }
                else
                {
                    return Math.Round((Goal / Miss * 100), 2);
                }
            }
        }

        public double GoalPercentHome
        {
            get
            {
                double Goal = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 3 && x.TeamId == Team_Home);
                double Miss = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 4 && x.TeamId == Team_Home);
                if (Goal >= Miss)
                {
                    return Math.Round((Miss / Goal * 100), 2);
                }
                else
                {
                    return Math.Round((Goal / Miss * 100), 2);
                }
            }
        }

        public double ThreeGoalPercentHome
        {
            get
            {
                double Goal = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 5 && x.TeamId == Team_Home);
                double Miss = App.DB.MatchupLog.Count(x => x.MatchupId == Id && x.ActionTypeId == 6 && x.TeamId == Team_Home);
                if (Goal >= Miss)
                {
                    return Math.Round((Miss / Goal * 100), 2);
                }
                else
                {
                    return Math.Round((Goal / Miss * 100), 2);
                }
            }
        }
    }
}
