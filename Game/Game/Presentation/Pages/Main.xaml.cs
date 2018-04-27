using Game.Model;
using Game.Presentation;
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
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : BasePage<MainViewModel>
    {
        public Main()
        {
            InitializeComponent();
        }

        private void ResetAnimationStatus()
        {
            isUnloadToLeft = isUnloadToRight = isLoadBack = isLoadFromRight = firstTime = false;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            Application.Current.Shutdown();
        }

        private void btnNoThemes_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
        }

        private void btnTheme_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
        }

        private void btnVocabularyList_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
        }

        private void imgHistory_MouseEnter(object sender, MouseEventArgs e)
        {
            imgHistory.Source = new BitmapImage(new Uri("/Images/Leaderboard or History/trophy_on.png", UriKind.Relative));
        }

        private void imgHistory_MouseLeave(object sender, MouseEventArgs e)
        {
            imgHistory.Source = new BitmapImage(new Uri("/Images/Leaderboard or History/trophy.png", UriKind.Relative));
        }

        private void imgSetting_MouseEnter(object sender, MouseEventArgs e)
        {
            imgSetting.Source = new BitmapImage(new Uri("/Images/Button/setting_on.png", UriKind.Relative));
        }

        private void imgSetting_MouseLeave(object sender, MouseEventArgs e)
        {
            imgSetting.Source = new BitmapImage(new Uri("/Images/Button/setting.png", UriKind.Relative));
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToRight = true;
        }
        private void imgBackButton_MouseEnter(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button_on.png", UriKind.Relative));
        }

        private void imgBackButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button.png", UriKind.Relative));
        }

        private void btnTheme_MouseEnter(object sender, MouseEventArgs e)
        {
            imgTheme.Source = new BitmapImage(new Uri("/Images/Button/theme_on.png", UriKind.Relative));
        }

        private void btnTheme_MouseLeave(object sender, MouseEventArgs e)
        {
            imgTheme.Source = new BitmapImage(new Uri("/Images/Button/theme_on.png", UriKind.Relative));
        }

        private void btnExit_MouseEnter(object sender, MouseEventArgs e)
        {
            imgExit.Source = new BitmapImage(new Uri("/Images/Button/exit_on.png", UriKind.Relative));
        }

        private void btnExit_MouseLeave(object sender, MouseEventArgs e)
        {
            imgExit.Source = new BitmapImage(new Uri("/Images/Button/exit_on.png", UriKind.Relative));
        }

        private void btnNoThemes_MouseEnter(object sender, MouseEventArgs e)
        {
            imgNoTheme.Source = new BitmapImage(new Uri("/Images/Button/menu.png", UriKind.Relative));
        }

        private void btnNoThemes_MouseLeave(object sender, MouseEventArgs e)
        {
            imgNoTheme.Source = new BitmapImage(new Uri("/Images/Button/menu.png", UriKind.Relative));
        }

        private void btnVocabularyList_MouseEnter(object sender, MouseEventArgs e)
        {
            imgVocabularyList.Source = new BitmapImage(new Uri("/Images/Button/vocabulary.png", UriKind.Relative));
        }

        private void btnVocabularyList_MouseLeave(object sender, MouseEventArgs e)
        {
            imgVocabularyList.Source = new BitmapImage(new Uri("/Images/Button/vocabulary.png", UriKind.Relative));
        }
    }
}
