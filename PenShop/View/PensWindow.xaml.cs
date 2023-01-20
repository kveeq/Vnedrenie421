using System.Linq;
using System.Windows.Controls;

namespace PenShop.View
{
    /// <summary>
    /// Логика взаимодействия для PensWindow.xaml
    /// </summary>
    public partial class PensWindow : Page
    {
        public PensWindow()
        {
            InitializeComponent();
            PensLstVIew.ItemsSource = App.db.Pen.ToList();
            var pen = App.db.Pen.Take(2);
        }
    }
}