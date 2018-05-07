using System.Linq;
using System.Windows;
using Game.Model;
using Game.Presentation;

namespace Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Properties
        private MainDb db;
        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
            db = new MainDb();
            DataContext = new WindowViewModel(this);
            var justForLoading = db.Themes.ToList(); // nothing to do with the main function
        }
        #endregion
    }
}
