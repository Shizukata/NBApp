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
    /// Логика взаимодействия для AdditionPage.xaml
    /// </summary>
    public partial class AdditionPage : Page
    {
        Team contextTeam;
        int numberTabGlobal;
        public AdditionPage(Team team, int numberTab)
        {
            InitializeComponent();
            contextTeam = team;
            DataContext = contextTeam;
            App.TitlePage = "Team Detail";
            numberTabGlobal = numberTab;
            DtMatchup.ItemsSource = App.DB.Matchup.Where(x => x.Team_Home == contextTeam.Id).ToList();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            IEnumerable<PlayerInTeam> playerInTeams = App.DB.PlayerInTeam.Where(x => x.TeamId == contextTeam.Id).ToList();
            if(CbSort.SelectedIndex == 0)
            {
                playerInTeams = playerInTeams.Where(x => x.SeasonId == 1);
            }
            if (CbSort.SelectedIndex == 1)
            {
                playerInTeams = playerInTeams.Where(x => x.SeasonId == 2);
            }
            if (CbSort.SelectedIndex == 2)
            {
                playerInTeams = playerInTeams.Where(x => x.SeasonId == 3);
            }
            DtPlayers.ItemsSource = playerInTeams;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
            if(numberTabGlobal == 1)
            {
                TabRoster.IsSelected = true;
            }
            if (numberTabGlobal == 2)
            {
                TabMatchup.IsSelected = true;
            }
            if (numberTabGlobal == 3)
            {
                TabLineup.IsSelected = true;
            }
        }
    }
}
