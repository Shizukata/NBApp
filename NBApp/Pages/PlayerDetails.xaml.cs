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
    /// Логика взаимодействия для PlayerDetails.xaml
    /// </summary>
    public partial class PlayerDetails : Page
    {
        PlayerInTeam contextPlayersInTeam;
        public PlayerDetails(PlayerInTeam playerInTeam)
        {
            InitializeComponent();
            App.TitlePage = "Player Detail";
            contextPlayersInTeam = playerInTeam;
            DataContext = contextPlayersInTeam;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainVisitorPage());
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
