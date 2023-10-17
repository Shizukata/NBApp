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

            LvNorth.ItemsSource = App.DB.Team.Where(x => x.DivisionId == 5).OrderBy(x => x.TeamName).ToList();
            LvPacific.ItemsSource = App.DB.Team.Where(x => x.DivisionId == 6).OrderBy(x => x.TeamName).ToList();
            LvSouthwest.ItemsSource = App.DB.Team.Where(x => x.DivisionId == 4).OrderBy(x => x.TeamName).ToList();
        }

        private void RosterBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedTeam = (sender as Button).DataContext as Team;
            NavigationService.Navigate(new AdditionPage(selectedTeam, 1));
        }

        private void MatchupBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedTeam = (sender as Button).DataContext as Team;
            NavigationService.Navigate(new AdditionPage(selectedTeam, 2));
        }

        private void LineUpbtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedTeam = (sender as Button).DataContext as Team;
            NavigationService.Navigate(new AdditionPage(selectedTeam, 3));
        }
    }
}
