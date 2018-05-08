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
    /// Interaction logic for PlayOptions.xaml
    /// </summary>
    public partial class PlayOptions : BasePage<PlayOptionsViewModel>
    {
        #region Properties
        private MainDb db;
        #endregion

        #region Constructor
        public PlayOptions()
        {
            InitializeComponent();
            db = new MainDb();
            if (GetData.isTheme && !GetData.isLearned)
            {
                ChangeStudyStatus(false);
            }
        }
        #endregion

        #region Other Methods
        public void ChangeStudyStatus(bool status)
        {
            btnSelectingPictureOnListening.IsEnabled = btnSelectingWordOnListening.IsEnabled = btnTypingWord.IsEnabled = status;
            if(!status)
            {
                imgSelectingPictureOnListening.Opacity = imgTypingWord.Opacity = imgSelectingWordOnListening.Opacity = 0.5;
            }
            else
            {
                imgSelectingPictureOnListening.Opacity = imgTypingWord.Opacity = imgSelectingWordOnListening.Opacity = 1;
            }
        }

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

        private void btnWordReview_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
        }

        private void btnSelectingWordOnListening_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
        }

        private void btnSelectingPictureOnListening_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
        }

        private void btnTypingWord_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
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
    }
}
