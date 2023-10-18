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
    }
}
