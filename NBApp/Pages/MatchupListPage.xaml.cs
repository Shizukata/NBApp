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
            LvMatchup.ItemsSource = App.DB.Matchup.ToList();
            DtSort.SelectedDate = DateTime.Now;
            App.TitlePage = "Machup List";
        }

        private void LeftBtn_Click(object sender, RoutedEventArgs e)
        {
            DtSort.SelectedDate -= TimeSpan.FromDays(1);
        }

        private void RightBtn_Click(object sender, RoutedEventArgs e)
        {
            DtSort.SelectedDate += TimeSpan.FromDays(1);
        }

        private void MatchupSearch()
        {
            IEnumerable<Matchup> matchups = App.DB.Matchup.OrderBy(x => x.Starttime).Where(x => x.Status == -1);
            if(DtSort.SelectedDate != null)
            {
                matchups = matchups.Where(x => x.Starttime >= DtSort.SelectedDate);
            }

            var leftTeam = App.DB.Team.FirstOrDefault(x => x.Id == matchups.FirstOrDefault().Team1.Id);
            ImgTeamName.Source = ConvertImage(leftTeam.MainImage);
            TbTeamName.Text = leftTeam.TeamName;
        }

        private BitmapImage ConvertImage(byte[] Image)
        {
            var empImage = new BitmapImage();
            using (var mem = new MemoryStream(Image))
            {
                mem.Position = 0;
                BeginInit();
                empImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                empImage.CacheOption = BitmapCacheOption.OnLoad;
                empImage.UriSource = null;
                empImage.StreamSource = mem;
                empImage.EndInit();
            }
            empImage.Freeze();
            return empImage;
        }
    }
}
