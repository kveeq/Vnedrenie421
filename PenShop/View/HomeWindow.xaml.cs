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
using System.Windows.Shapes;

namespace PenShop.View
{
    /// <summary>
    /// Логика взаимодействия для HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        bool isOpen = true;
        public HomeWindow()
        {
            InitializeComponent();
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
            while (pnl.Width > 50 && pnl.Width < 151)
            {
                pnl.Width += resizeValue;
                await Task.Run(() => Thread.Sleep(duration));
            }
        }
    }
}
