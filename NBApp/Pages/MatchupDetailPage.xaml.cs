﻿using NBApp.Components;
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
    /// Логика взаимодействия для MatchupDetailPage.xaml
    /// </summary>
    public partial class MatchupDetailPage : Page
    {
        Matchup contextMatchup;
        public MatchupDetailPage(Matchup matchup)
        {
            InitializeComponent();
            contextMatchup = matchup;
            DataContext = contextMatchup;
            App.TitlePage = "Matchup Detail";
        }
    }
}
