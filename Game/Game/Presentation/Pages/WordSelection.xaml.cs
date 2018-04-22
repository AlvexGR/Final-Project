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
    /// Interaction logic for WordSelection.xaml
    /// </summary>
    public partial class WordSelection : BasePage<WordSelectionViewModel>
    {
        public List<Vocabulary> SelectedWords { get; set; }
        public WordSelection()
        {
            InitializeComponent();
            lbxWordList.ItemsSource = GetData.wordListTotal;
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

        private void btnNext_Click(object sender, RoutedEventArgs e)
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

        private void lbxWordList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedWord = ((Vocabulary)lbxWordList.SelectedItem);
            if (GetData.wordList.Contains(selectedWord)) return;
            GetData.wordList.Add(selectedWord);
            lbxSelectedWordList.Items.Add(selectedWord);
            if(GetData.wordList.Count > 4)
            {
                btnNext.Visibility = Visibility.Visible;
            }
            else
            {
                btnNext.Visibility = Visibility.Hidden;
            }
        }

        private void lbxSelectedWordList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedWord = ((Vocabulary)lbxSelectedWordList.SelectedItem);
            GetData.wordList.Remove(selectedWord);
            lbxSelectedWordList.Items.Remove(selectedWord);
            if (GetData.wordList.Count > 4)
            {
                btnNext.Visibility = Visibility.Visible;
            }
            else
            {
                btnNext.Visibility = Visibility.Hidden;
            }
        }

        private void imgNextButton_MouseEnter(object sender, MouseEventArgs e)
        {
            imgNextButton.Source = new BitmapImage(new Uri("/Images/Button/next_button_on.png", UriKind.Relative));
        }

        private void imgNextButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgNextButton.Source = new BitmapImage(new Uri("/Images/Button/next_button.png", UriKind.Relative));
        }
    }
}
