using Game.Model;
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

namespace Game.Presentation.Pages
{
    /// <summary>
    /// Interaction logic for ThemeSelection.xaml
    /// </summary>
    public partial class ThemeSelection : BasePage<ThemeSelectionViewModel>
    {
        private MainDb db = new MainDb();
        public ThemeSelection()
        {
            InitializeComponent();
            lbxTheme.ItemsSource = db.Themes.Where(x=>x.Id!=11).ToList();
        }

        private void ResetAnimationStatus()
        {
            isUnloadToLeft = isUnloadToRight = isLoadBack = isLoadFromRight = firstTime = false;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToRight = true;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
            GetData.curTheme = ((Theme)lbxTheme.SelectedItem).Id;
            GetData.wordListTotal = db.Words.Where(x => x.Theme.Id == GetData.curTheme).ToList();
        }

        private void imgBackButton_MouseEnter(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button_on.png", UriKind.Relative));
        }

        private void imgBackButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button.png", UriKind.Relative));
        }

        private void imgNextButton_MouseEnter(object sender, MouseEventArgs e)
        {
            imgNextButton.Source = new BitmapImage(new Uri("/Images/Button/correct_on.png", UriKind.Relative));
        }

        private void imgNextButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgNextButton.Source = new BitmapImage(new Uri("/Images/Button/correct.png", UriKind.Relative));
        }
    }
}
