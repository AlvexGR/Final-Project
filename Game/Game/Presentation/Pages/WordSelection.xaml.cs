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
        private MainDb db;
        public WordSelection()
        {
            InitializeComponent();
            db = new MainDb();
            List<Theme> themes = new List<Theme>() { new Theme { Id = 0, Name = "Tất cả" } };
            themes.AddRange(db.Themes.ToList());
            cbxTheme.ItemsSource = themes;
            lbxVocabularies.ItemsSource = GetData.wordListTotal;
        }

        private void ResetAnimationStatus()
        {
            isUnloadToLeft = isUnloadToRight = isLoadBack = isLoadFromRight = firstTime = false;
        }


        private void cbxTheme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (Theme)cbxTheme.SelectedItem;

            if (selectedItem.Id == 0)
            {
                lbxVocabularies.ItemsSource = db.Words.OrderBy(x => x.EnglishWord).ToList();
                lbxVocabularies.SelectedIndex = 0;
            }
            else
            {
                lbxVocabularies.ItemsSource = db.Words.Where(x => x.Theme.Id == selectedItem.Id).OrderBy(x => x.EnglishWord).ToList();
                lbxVocabularies.SelectedIndex = 0;
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var selectedItem = (Theme)cbxTheme.SelectedItem;

            if (String.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                if (selectedItem.Id == 0)
                {
                    lbxVocabularies.ItemsSource = db.Words.OrderBy(x => x.EnglishWord).ToList();
                    lbxVocabularies.SelectedIndex = 0;
                }
                else
                {
                    lbxVocabularies.ItemsSource = db.Words.Where(x => x.Theme.Id == selectedItem.Id).OrderBy(x => x.EnglishWord).ToList();
                    lbxVocabularies.SelectedIndex = 0;
                }
            }
            else
            {
                if (selectedItem.Id == 0)
                {
                    lbxVocabularies.ItemsSource = db.Words.Where(x => x.EnglishWord.StartsWith(txtSearch.Text.ToLower().ToString())).OrderBy(x => x.EnglishWord).ToList();
                    lbxVocabularies.SelectedIndex = 0;
                }
                else
                {
                    lbxVocabularies.ItemsSource = db.Words.Where(x => x.Theme.Id == selectedItem.Id && x.EnglishWord.StartsWith(txtSearch.Text.ToLower().ToString())).OrderBy(x => x.EnglishWord).ToList();
                    lbxVocabularies.SelectedIndex = 0;
                }
            }
        }

        private void lbxVocabularies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedWord = ((Vocabulary)lbxVocabularies.SelectedItem);
            if (SelectedWords.Contains(selectedWord)) return;
            SelectedWords.Add(selectedWord);
            lbxSelectedVocabularies.Items.Add(selectedWord);

           

            if (SelectedWords.Count == 5)
            {
                btnNext.Visibility = Visibility.Visible;
            }
            else
            {
                btnNext.Visibility = Visibility.Hidden;
            }
        }

        private void lbxSelectedVocabularies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedWord = ((Vocabulary)lbxVocabularies.SelectedItem);

            SelectedWords.Remove(selectedWord);
            lbxSelectedVocabularies.Items.Remove(selectedWord);

        }

        private void imgNextButton_MouseEnter(object sender, MouseEventArgs e)
        {
            imgNextButton.Source = new BitmapImage(new Uri("/Images/Button/next_button_on.png", UriKind.Relative));
        }

        private void imgNextButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgNextButton.Source = new BitmapImage(new Uri("/Images/Button/next_button.png", UriKind.Relative));
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


    }
}
