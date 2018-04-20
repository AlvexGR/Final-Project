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
using Game.Model;
using Game.Presentation;
namespace Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainDb db = new MainDb();
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new WindowViewModel(this);
            var justForLoading = db.Themes.ToList(); // nothing to do with the main function
        }
    }
}
