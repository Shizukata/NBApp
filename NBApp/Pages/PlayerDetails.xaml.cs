using LiveCharts;
using LiveCharts.Wpf;
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

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        public PlayerDetails(PlayerInTeam playerInTeam)
        {
            InitializeComponent();
            App.TitlePage = "Player Detail";
            contextPlayersInTeam = playerInTeam;
            DataContext = contextPlayersInTeam;
            RbPoints.IsChecked = true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PlayersMain());
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            GraphRefresh();
        }

        private void RbPoints_Checked(object sender, RoutedEventArgs e)
        {
            GraphRefresh();
        }

        private void RbRebounds_Checked(object sender, RoutedEventArgs e)
        {
            GraphRefresh();
        }

        private void RbAssists_Checked(object sender, RoutedEventArgs e)
        {
            GraphRefresh();
        }

        private void RbSteals_Checked(object sender, RoutedEventArgs e)
        {
            GraphRefresh();
        }

        private void RbBlocks_Checked(object sender, RoutedEventArgs e)
        {
            GraphRefresh();
        }

        private void GraphRefresh()
        {
            IEnumerable<PlayerStatistics> stats = App.DB.PlayerStatistics.Where(x => x.PlayerId == contextPlayersInTeam.PlayerId).OrderBy(x => x.Matchup.Starttime);
            if (DtStartDate.SelectedDate != null)
            {
                stats = stats.Where(x => x.Matchup.Starttime >= DtStartDate.SelectedDate);
            }
            if (DtEndDate.SelectedDate != null && DtEndDate.SelectedDate > DtStartDate.SelectedDate)
            {
                stats = stats.Where(x => x.Matchup.Starttime <= DtEndDate.SelectedDate);
            }
            int buf = 0;
            double[] MyPoints = new double[App.DB.PlayerStatistics.Where(x => x.PlayerId == contextPlayersInTeam.PlayerId).Count()];
            DateTime[] MyDates = new DateTime[App.DB.PlayerStatistics.Where(x => x.PlayerId == contextPlayersInTeam.PlayerId).Count()];
            string[] labels = new string[App.DB.PlayerStatistics.Where(x => x.PlayerId == contextPlayersInTeam.PlayerId).Count()];

            foreach (var pcf in stats)
            {
                if (RbPoints.IsChecked == true)
                {
                    MyPoints[buf] = pcf.Point;
                }
                if (RbRebounds.IsChecked == true)
                {
                    MyPoints[buf] = pcf.Rebound;
                }
                if (RbAssists.IsChecked == true)
                {
                    MyPoints[buf] = pcf.Assist;
                }
                if (RbSteals.IsChecked == true)
                {
                    MyPoints[buf] = pcf.Steal;
                }
                if (RbBlocks.IsChecked == true)
                {
                    MyPoints[buf] = pcf.Block;
                }
                MyDates[buf] = pcf.Matchup.Starttime;
                labels[buf] = pcf.Matchup.Starttime.ToString("d MMMM yyyy", new System.Globalization.CultureInfo("en-EN"));
                buf++;
            }

            PlayerAvgParam.Text = Math.Round(MyPoints.Average(), 2).ToString();
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Points",
                    LineSmoothness = 0,
                    Stroke = new SolidColorBrush(Color.FromRgb(56, 129, 239)),
                    Values = new ChartValues<double> (MyPoints)
                },

            };

            Labels = labels;
            YFormatter = value => value.ToString();

            LvcGraph.Series = SeriesCollection;
            AxisY.LabelFormatter = YFormatter;
            AxisX.Labels = Labels;
        }
    }
}
