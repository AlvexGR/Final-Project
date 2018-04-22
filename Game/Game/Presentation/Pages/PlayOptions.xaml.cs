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
        private MainDb db = new MainDb();
        public PlayOptions()
        {
            InitializeComponent();
            if(!GetData.isTheme)
            {
                btnSelectingWordOnTheme.Visibility = Visibility.Hidden;
                GetData.wordListTotal = db.Words.ToList();
            }
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

        private void randomizeListOfWord()
        {
            var rnd = new Random();
            int d=0;
            GetData.wordListTotal = GetData.wordListTotal.OrderBy(item => d = rnd.Next()).ToList();
            if (GetData.isTheme) GetData.wordListTotal = GetData.wordListTotal.Where(x => x.Theme.Id == GetData.curTheme).ToList();
            GetData.wordList.Clear();
            for (int i = 0; i < 5; i++)
            {
                GetData.wordList.Add(GetData.wordListTotal[i]);
            }
        }

        private void btnWordReview_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
        }

        private void btnRandom_Click(object sender, RoutedEventArgs e)
        {
            randomizeListOfWord();
        }

        private void btnSelectingWordOnListening_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
        }

        private void imgBackButton_MouseEnter(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button_on.png", UriKind.Relative));
        }

        private void imgBackButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button.png", UriKind.Relative));
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
    }
}
