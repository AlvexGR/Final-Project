using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for VocabularyList.xaml
    /// </summary>
    public partial class VocabularyList : BasePage<VocabularyListViewModel>
    {

        private MainDb db;

        public VocabularyList()
        {
            InitializeComponent();
            db = new MainDb();
            List<Theme> themes = new List<Theme>() { new Theme { Id = 0, Name = " Tất cả" } };
            themes.AddRange(db.Themes.ToList());
            cbxTheme.ItemsSource = themes;
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

        private void imgBackButton_MouseEnter(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button_on.png", UriKind.Relative));
        }

        private void imgBackButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button.png", UriKind.Relative));
        }

        private void cbxTheme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (Theme)cbxTheme.SelectedItem;

            if (selectedItem.Id == 0)
            {
                lbxVocabularies.ItemsSource = db.Words.OrderBy(x => x.EnglishWord).ToList();
            }
            else
            {
                lbxVocabularies.ItemsSource = db.Words.Where(x => x.Theme.Id == selectedItem.Id).OrderBy(x => x.EnglishWord).ToList();
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
                }
                else
                {
                    lbxVocabularies.ItemsSource = db.Words.Where(x => x.Theme.Id == selectedItem.Id).OrderBy(x => x.EnglishWord).ToList();
                }
            }
            else
            {
                if (selectedItem.Id == 0)
                {
                    lbxVocabularies.ItemsSource = db.Words.Where(x => x.EnglishWord.StartsWith(txtSearch.Text.ToLower().ToString())).OrderBy(x => x.EnglishWord).ToList();
                }
                else
                {
                    lbxVocabularies.ItemsSource = db.Words.Where(x => x.Theme.Id == selectedItem.Id && x.EnglishWord.StartsWith(txtSearch.Text.ToLower().ToString())).OrderBy(x => x.EnglishWord).ToList();
                }
            }
        }
    }
}
