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
    /// Логика взаимодействия для PlayersMain.xaml
    /// </summary>
    public partial class PlayersMain : Page
    {
        int maxPage = 0;
        int numberPage = 0;
        int count = 10;
        int fakePage = 1;
        public PlayersMain()
        {
            InitializeComponent();
            App.TitlePage = "Players Main";
            CbSeason.ItemsSource = App.DB.Season.ToList();
            CbTeam.ItemsSource = App.DB.Team.ToList();
            AllRB.IsChecked = true;
            Refresh();
        }
        

        private void BtnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            numberPage = 0;
            fakePage = 1;
            Refresh();
            
        }

        private void BtnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            numberPage--;
            fakePage--;
            if (numberPage < 0)
                numberPage = 0;
            if (fakePage < 1)
                fakePage = 1;
            Refresh();
        }

        private void BtnNextPage_Click(object sender, RoutedEventArgs e)
        {
            numberPage++;
            fakePage++;
            if (numberPage == maxPage)
            {
                numberPage = maxPage - 1;
                fakePage--;
            }

            if (fakePage < maxPage + 1)
            {
                Refresh();
            }
        }

        private void BtnLastPage_Click(object sender, RoutedEventArgs e)
        {
            numberPage = maxPage - 1;
            fakePage = maxPage;
            Refresh();
        }
        private void Refresh()
        {
            IEnumerable<PlayerInTeam> filterCase = App.DB.PlayerInTeam;

            if (CbSeason.SelectedItem != null)
            {
                filterCase = filterCase.Where(x => x.Season == CbSeason.SelectedItem);
            }
            if (CbTeam.SelectedItem != null)
            {
                filterCase = filterCase.Where(x => x.Team == CbTeam.SelectedItem);
            }

            foreach (var item in SortLettersSt.Children)
            {
                var RadioButton = item as RadioButton;
                if (RadioButton.IsChecked == true)
                {
                    filterCase = filterCase.Where(x => x.Player.Name.StartsWith($"{RadioButton.Content}"));
                }
            }

            if (filterCase.Count() > count)
            {
                if (filterCase.Count() % count > 0)
                {
                    maxPage = (filterCase.Count() / count) + 1;
                }
                else
                {
                    maxPage = filterCase.Count() / count;
                }
            }
            else
            {
                maxPage = 1;
            }
            if (fakePage > maxPage)
            {
                fakePage = maxPage;
            }

            if (TbPlayername.Text.Length > 0)
            {
                filterCase = filterCase.Where(x => x.Player.Name.ToLower().Contains(TbPlayername.Text.ToLower()));
            }
            filterCase = filterCase.Skip(count * numberPage).Take(count).ToList();
            DtPlayers.ItemsSource = filterCase.ToList();

            MaxPage.Text = $"of {maxPage}";
            CurrentPage.Text = fakePage.ToString();

            RecordText.Text = $"Total {maxPage * count} records, {count} in one page";
        }

        private void TbPlayername_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void CbTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void CbSeason_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void CurrentPage_TextChanged(object sender, TextChangedEventArgs e)
        {
            fakePage = int.Parse(CurrentPage.Text);
            numberPage = fakePage - 1;
            Refresh();
        }

        private void AllRB_Checked(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainVisitorPage());
        }

        private void ImageBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var selectedPlayer = (sender as Image).DataContext as PlayerInTeam;
            NavigationService.Navigate(new PlayerDetails(selectedPlayer));
        }
    }
}
