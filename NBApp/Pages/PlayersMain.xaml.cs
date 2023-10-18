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
    /// Логика взаимодействия для PlayersMain.xaml
    /// </summary>
    public partial class PlayersMain : Page
    {
        public PlayersMain()
        {
            InitializeComponent();
            CbSeason.ItemsSource = App.DB.Season.ToList();
            CbTeam.ItemsSource = App.DB.Team.ToList();
            DtPlayers.ItemsSource = App.DB.PlayerInTeam.ToList();
        }
    }
}
