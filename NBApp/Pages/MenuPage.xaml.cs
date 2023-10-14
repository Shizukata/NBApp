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
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        int numberPage = 0;
        int count = 3;
        public MenuPage()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {
            IEnumerable<Pictures> pictures = App.DB.Pictures.ToList();
            pictures = pictures.Skip(count * numberPage).Take(count);
            LvPictures.ItemsSource = pictures;
        }

        private void LeftBtn_Click(object sender, RoutedEventArgs e)
        {
            numberPage--;
            if (numberPage < 0)
                numberPage = 0;
            Refresh();
        }

        private void RightBtn_Click(object sender, RoutedEventArgs e)
        {
            numberPage++;
            if (LvPictures.Items.Count < 3)
                numberPage--;
            Refresh();
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainVisitorPage());
        }
    }
}
