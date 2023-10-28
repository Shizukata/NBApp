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
    /// Логика взаимодействия для MatchupListPage.xaml
    /// </summary>
    public partial class MatchupListPage : Page
    {
        public MatchupListPage()
        {
            InitializeComponent();
            DtSort.SelectedDate = DateTime.Now;
            App.TitlePage = "Machup List";
            MatchupSearch();
        }

        private void LeftBtn_Click(object sender, RoutedEventArgs e)
        {
            DtSort.SelectedDate -= TimeSpan.FromDays(1);
            MatchupSearch();
        }

        private void RightBtn_Click(object sender, RoutedEventArgs e)
        {
            DtSort.SelectedDate += TimeSpan.FromDays(1);
            MatchupSearch();
        }

        private void MatchupSearch()
        {
            IEnumerable<Matchup> matchups = App.DB.Matchup.OrderBy(x => x.Starttime);
            if(DtSort.SelectedDate != null)
            {
                matchups = matchups.Where(x => x.Starttime.Date == DtSort.SelectedDate);
            }
            LvMatchup.ItemsSource = matchups.ToList();
            var ShowMatch = matchups.FirstOrDefault();
            if (ShowMatch != null)
            {
                ImgTeamName.Source = ConvertImage(ShowMatch.Team.MainImage);
                TbTeamName.Text = $"{ShowMatch.Team.TeamName} (Away)";

                ImgTeam1Name.Source = ConvertImage(ShowMatch.Team1.MainImage);
                TbTeam1Name.Text = $"{ShowMatch.Team1.TeamName} (Home)";
                TbMatchTime.Text = ShowMatch.Starttime.ToString("hh:mm") + " Start";
                StCurrentMatch.Visibility = Visibility.Visible;
            }
            else
            {
                StCurrentMatch.Visibility = Visibility.Collapsed;
            }
            
        }

        private BitmapImage ConvertImage(byte[] Image)
        {
            var empImage = new BitmapImage();
            using (var mem = new MemoryStream(Image))
            {
                mem.Position = 0;
                empImage.BeginInit();
                empImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                empImage.CacheOption = BitmapCacheOption.OnLoad;
                empImage.UriSource = null;
                empImage.StreamSource = mem;
                empImage.EndInit();
            }
            empImage.Freeze();
            return empImage;
        }

        private void DtSort_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            MatchupSearch();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedMatch = (sender as Button).DataContext as Matchup;
            NavigationService.Navigate(new MatchupDetailPage(selectedMatch));
        }
    }
}
