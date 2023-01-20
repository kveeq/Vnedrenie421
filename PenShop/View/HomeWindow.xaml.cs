using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using MaterialDesignThemes;

namespace PenShop.View
{
    /// <summary>
    /// Логика взаимодействия для HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        bool isOpen = true;
        public NavigationService service;

        public HomeWindow()
        {
            InitializeComponent();
            service = frma.NavigationService;
            //HomePnl.Width = HomePnl.ActualWidth;
        }

        private async void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isOpen)
            {
                await ResizePnl(HomePnl, -1, 10);
                HomePnl.Width++;
            }
            else
            {
                await ResizePnl(HomePnl, 1, 10);
                HomePnl.Width--;
            }

            isOpen = !isOpen;
        }

        private async Task ResizePnl(Grid pnl, int resizeValue, int duration)
        {
            var vs1 = Visibility.Collapsed;
            var vs2 = Visibility.Visible; 
            while (pnl.Width > 50 && pnl.Width < 151)
            {
                pnl.Width += resizeValue;
                await Task.Run(() => Thread.Sleep(duration));
            }

                
            if(resizeValue > 0)
            {
                vs1 = Visibility.Collapsed;
                vs2 = Visibility.Visible;
            }
            if(resizeValue < 0)
            {
                vs1 = Visibility.Visible;
                vs2 = Visibility.Collapsed;
            }

            HomeNavigateBtn.Visibility = vs1;
            HomeNavigateTxt.Visibility = vs2;
            PensNavigateBtn.Visibility = vs1;
            PensNavigateTxt.Visibility = vs2;
            ClientsNavigateBtn.Visibility = vs1;
            ClientsNavigateTxt.Visibility = vs2;
        }

        private void PensBtn_Click(object sender, RoutedEventArgs e)
        {
            var a = new PensWindow();
            service.Navigate(a);
            var items = App.db.Pen.ToList();
        }
    }
}
