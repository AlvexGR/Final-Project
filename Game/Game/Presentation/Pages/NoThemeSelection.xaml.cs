using Game.UserControls;
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

namespace Game.Presentation.Pages
{
    /// <summary>
    /// Interaction logic for Selection.xaml
    /// </summary>
    public partial class NoThemeSelection : BasePage<NoThemeSelectionViewModel>
    {
        MainDb db;
        #region Constructor
        public NoThemeSelection()
        {
            InitializeComponent();
            db = new MainDb();
            GetData.wordListTotal = db.Words.ToList();
        }
        #endregion

        private void ResetAnimationStatus()
        {
            isUnloadToLeft = isUnloadToRight = isLoadBack = isLoadFromRight = firstTime = false;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToRight = true;
        }

        private void btnRandom_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
            GetData.isTheme = false;

            var rnd = new Random();
            GetData.wordList.Clear();
            
            GetData.wordList.AddRange(GetData.wordListTotal.OrderBy(item => rnd.Next()).Take(5).ToList());
        }

        private void btnManual_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
            GetData.isTheme = false;
        }

        private void imgBackButton_MouseEnter(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button_on.png", UriKind.Relative));
        }

        private void imgBackButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button.png", UriKind.Relative));
        }
    }
}
