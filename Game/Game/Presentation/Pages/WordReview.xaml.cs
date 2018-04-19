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
            Vocabulary vc = GetData.wordList[idx];
            tbxDefinition.Text = vc.Definition;
            tbxEnglishWord.Text = vc.EnglishWord;
            tbxSpelling.Text = vc.Spelling;
            //wordImage.Source = new BitmapImage(new Uri(vc.Image, UriKind.Relative));
            //mePronoun.Source = new Uri(vc.Pronunciation);
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
            mePronoun.Play();
        }
    }
}
