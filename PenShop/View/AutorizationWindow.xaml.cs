using PenShop.db;
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
        private static bool isAutorization = true;
        public AutorizationWindow()
        {
            InitializeComponent();
            //string str = "/K echo fr > a.txt";
            //Process.Start("cmd", str);
            //string arguments = 
        }

        private void AutorizationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isAutorization)
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
                return;
            }

            var user = new User();
            user.Login = LoginTB.Text;  
            user.Password = PassPB.Password;
            user.Fio = FioTB.Text;
            user.IdRole = 2;
            App.db.User.Add(user);
            App.db.SaveChanges();
            MessageBox.Show("Регистрация прошла успешно!");
        }

        private void RegistrationBtn_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (isAutorization)
            {
                CaptionLbl.Content = "Регистрация";
                AutorizationBtn.Content = "Зарегистрироваться";
                RegistrationNavigateBtn.Text = "Вход";
                FioPnl.Visibility = Visibility.Visible;
            }
            else
            {
                CaptionLbl.Content = "Авторизация";
                AutorizationBtn.Content = "Войти";
                RegistrationNavigateBtn.Text = "Регистрация";
                FioPnl.Visibility = Visibility.Collapsed;
            }

            isAutorization = !isAutorization;
        }
    }
}
