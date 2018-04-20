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
    /// Interaction logic for WordReview.xaml
    /// </summary>
    public partial class WordReview : BasePage<WordReviewViewModel>
    {
        private int idx = 0;
        private Vocabulary vc;
        public WordReview()
        {
            InitializeComponent();
            UpdateData();
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

        private void UpdateData()
        {
            vc = GetData.wordList[idx];
            tbxDefinition.Text = vc.Definition;
            tbxEnglishWord.Text = vc.EnglishWord;
            tbxSpelling.Text = vc.Spelling;
            wordImage.Source = new BitmapImage(new Uri(vc.Image, UriKind.Relative));
            mePronoun.Source = null;
        }

        private void btnGoRight_Click(object sender, RoutedEventArgs e)
        {
            idx++;
            if (idx == GetData.wordList.Count)
            {
                idx = 0;
            }
            UpdateData();
        }

        private void btnGoLeft_Click(object sender, RoutedEventArgs e)
        {
            idx--;
            if (idx == -1)
            {
                idx = GetData.wordList.Count - 1;
            }
            UpdateData();
        }

        private void btnPronoun_Click(object sender, RoutedEventArgs e)
        {
            mePronoun.Source = new Uri("../.." + vc.Pronunciation, UriKind.Relative);
            mePronoun.Play();
        }

        private void imgArrowRight_MouseEnter(object sender, MouseEventArgs e)
        {
            imgArrowRight.Source = new BitmapImage(new Uri("/Images/Button/arrow_right_on.png", UriKind.Relative));
        }

        private void imgArrowRight_MouseLeave(object sender, MouseEventArgs e)
        {
            imgArrowRight.Source = new BitmapImage(new Uri("/Images/Button/arrow_right.png", UriKind.Relative));
        }

        private void imgArrowLeft_MouseEnter(object sender, MouseEventArgs e)
        {
            imgArrowLeft.Source = new BitmapImage(new Uri("/Images/Button/arrow_left_on.png", UriKind.Relative));
        }

        private void imgArrowLeft_MouseLeave(object sender, MouseEventArgs e)
        {
            imgArrowLeft.Source = new BitmapImage(new Uri("/Images/Button/arrow_left.png", UriKind.Relative));
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
