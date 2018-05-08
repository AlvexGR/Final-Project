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
        #region Properties
        private MainDb db;
        #endregion

        #region Constructor
        public ThemeSelection()
        {
            InitializeComponent();
            db = new MainDb();
            lbxTheme.ItemsSource = db.Themes.Where(x=>x.Id!=11).ToList();
        }
        #endregion

        #region Other Methods
        private void ResetAnimationStatus()
        {
            isUnloadToLeft = isUnloadToRight = isLoadFromLeft = isLoadFromRight = firstTime = false;
        }
        #endregion

        #region Click Methods
        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToRight = true;
        }
        #endregion

        #region MouseEnter and MouseLeave Methods
        private void imgBackButton_MouseEnter(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button_on.png", UriKind.Relative));
        }

        private void imgBackButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button.png", UriKind.Relative));
        }
        #endregion

        #region SelectionChanged Methods
        private void lbxTheme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxTheme.SelectedItem is null)
            {
                return;
            }
            ResetAnimationStatus();
            isUnloadToLeft = true;
            GetData.curTheme = ((Theme)lbxTheme.SelectedItem).Id;
            GetData.wordListTotal = db.Words.Where(x => x.Theme.Id == GetData.curTheme).ToList();
            (DataContext as ThemeSelectionViewModel).WordSetCommand.Execute(null);
        }
        #endregion

    }
}
