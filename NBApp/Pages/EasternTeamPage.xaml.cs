using NBApp.Components;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для EasternTeamPage.xaml
    /// </summary>
    public partial class EasternTeamPage : Page
    {
        public EasternTeamPage()
        {
            InitializeComponent();

            LvAtlantic.ItemsSource = App.DB.Team.Where(x => x.DivisionId == 3).OrderBy(x => x.TeamName).ToList();
            LvCentral.ItemsSource = App.DB.Team.Where(x => x.DivisionId == 2).OrderBy(x => x.TeamName).ToList();
            LvSoutheast.ItemsSource = App.DB.Team.Where(x => x.DivisionId == 1).OrderBy(x => x.TeamName).ToList();
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
