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
using NBApp.Components;

namespace NBApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для TeamsPage.xaml
    /// </summary>
    public partial class TeamsPage : Page
    {
        public TeamsPage()
        {
            InitializeComponent();
            App.TitlePage = "Teams Main";
            TeamsFrame.Navigate(new EasternTeamPage());

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainVisitorPage());
        }

        private void EasternButton_Click(object sender, RoutedEventArgs e)
        {
            TeamsFrame.Navigate(new EasternTeamPage());
        }

        private void WesternButton_Click(object sender, RoutedEventArgs e)
        {
            TeamsFrame.Navigate(new WesternTeamPage());
        }
    }
}
