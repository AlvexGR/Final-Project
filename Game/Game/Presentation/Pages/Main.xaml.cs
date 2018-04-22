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
    }
}
