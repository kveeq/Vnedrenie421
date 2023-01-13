using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace PenShop.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        public AutorizationWindow()
        {
            InitializeComponent();
            string str = "/K echo fr > a.txt";
            Process.Start("cmd", str);
            string arguments = 
        }

        private void AutorizationBtn_Click(object sender, RoutedEventArgs e)
        {
            App.user = App.db.User.Where(x => x.Login == LoginTB.Text && x.Password == PassPB.Password).FirstOrDefault();

            if (App.user == null)
            {
                MessageBox.Show("Неправильный пароль или логин!");
                return;
            }

            MessageBox.Show($"Добро пожаловать в программу {App.user.Fio}");
            new HomeWindow().Show();
            this.Close();
        }
    }
}
