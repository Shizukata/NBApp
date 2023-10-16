﻿using NBApp.Components;
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

            IEnumerable<Team> filterTeam = App.DB.Team.Where(x => x.Division.ConferenceId == 1).ToList();
            filterTeam = filterTeam.OrderBy(x => x.TeamName);
            LvEastern.ItemsSource = filterTeam;

        }
    }
}
