using NBApp.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NBApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для WesternTeamPage.xaml
    /// </summary>
    public partial class WesternTeamPage : Page
    {
        public WesternTeamPage()
        {
            InitializeComponent();
            IEnumerable<Team> filterTeam = App.DB.Team.Where(x => x.Division.ConferenceId == 2).ToList();
            filterTeam = filterTeam.OrderBy(x => x.Division.Name);
            filterTeam = filterTeam.OrderBy(x => x.TeamName);
            LvEastern.ItemsSource = filterTeam;
        }
    }
}
