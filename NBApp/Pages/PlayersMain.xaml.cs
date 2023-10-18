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
        public PlayersMain()
        {
            InitializeComponent();
            CbSeason.ItemsSource = App.DB.Season.ToList();
            CbTeam.ItemsSource = App.DB.Team.ToList();
            Refresh();
        }
        int maxPage = 0;
        int numberPage = 0;
        int count = 10;
        int fakePage = 1;

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

            //if(CbSeason.SelectedItem != null)
            //{
            //    filterCase = filterCase.Where(x => x.Season == CbSeason.SelectedItem);
            //}
            //if (CbTeam.SelectedItem != null)
            //{
            //    filterCase = filterCase.Where(x => x.Team == CbTeam.SelectedItem);
            //}
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

            //if(TbPlayername.Text.Length > 0)
            //{
            //    filterCase = filterCase.Where(x => x.Player.Name.ToLower().Contains(TbPlayername.Text.ToLower()));
            //}
            filterCase = filterCase.Skip(count * numberPage).Take(count).ToList();
            DtPlayers.ItemsSource = filterCase.ToList();

            MaxPage.Text = $"of {maxPage}";
            CurrentPage.Text = fakePage.ToString();
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
            //fakePage = int.Parse(CurrentPage.Text);
            //numberPage = fakePage - 1;
            //Refresh();
        }
    }
}
