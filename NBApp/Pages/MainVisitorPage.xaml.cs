﻿using System;
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
    /// Логика взаимодействия для MainVisitorPage.xaml
    /// </summary>
    public partial class MainVisitorPage : Page
    {
        public MainVisitorPage()
        {
            InitializeComponent();
            App.TitlePage = "Visitors Menu";
        }

        private void TeamsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeamsPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PlayersMain());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MatchupListPage());
        }
    }
}
