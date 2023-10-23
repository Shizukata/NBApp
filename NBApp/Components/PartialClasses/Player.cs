using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBApp.Components
{
    public partial class Player
    {
        public int Experience
        {
            get
            {
                return DateTime.Now.Year - JoinYear.Year;
            }
        }
        public string CurrentTeam
        {
            get
            {
                var team = App.DB.PlayerInTeam.FirstOrDefault(x => x.PlayerId == Id);
                return team.Team.TeamName;
            }
        }
        public byte[] MainImage
        {
            get
            {
                if (Img == null)
                    return File.ReadAllBytes("../../Resources//person.png");
                else
                    return Img;
            }
        }
        public double PPG
        {
            get
            {
                var stat = App.DB.PlayerStatistics.Where(x => x.PlayerId == Id && x.Matchup.Season.Name == cSeason);
                return Math.Round(stat.Average(x => x.Point), 2);
            }
        }
        public double APG
        {
            get
            {
                var stat = App.DB.PlayerStatistics.Where(x => x.PlayerId == Id && x.Matchup.Season.Name == cSeason);
                return Math.Round(stat.Average(x => x.Assist), 2);
            }
        }
        public double RPG
        {
            get
            {
                var stat = App.DB.PlayerStatistics.Where(x => x.PlayerId == Id && x.Matchup.Season.Name == cSeason);
                return Math.Round(stat.Average(x => x.Rebound), 2);
            }
        }
        public double cPPG
        {
            get
            {
                var stat = App.DB.PlayerStatistics.Where(x => x.PlayerId == Id);
                return Math.Round(stat.Average(x => x.Point), 2);
            }
        }
        public double cAPG
        {
            get
            {
                var stat = App.DB.PlayerStatistics.Where(x => x.PlayerId == Id);
                return Math.Round(stat.Average(x => x.Assist), 2);
            }
        }
        public double cRPG
        {
            get
            {
                var stat = App.DB.PlayerStatistics.Where(x => x.PlayerId == Id);
                return Math.Round(stat.Average(x => x.Rebound), 2);
            }
        }
        public string cSeason
        {
            get
            {
                var season = App.DB.Season.OrderByDescending(x => x.Name).FirstOrDefault();
                return season.Name.ToString();
            }
        }
    }
}
