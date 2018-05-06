﻿using Game.UserControls;
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
        private List<Theme> themes;
        private List<Vocabulary> selectedWords;
        private MainDb db;

        public WordSelection()
        {
            InitializeComponent();
            db = new MainDb();
            selectedWords = new List<Vocabulary>();
            themes = new List<Theme>() { new Theme { Id = 0, Name = "Tất cả" } };
            themes.AddRange(db.Themes.ToList());
            cbxTheme.ItemsSource = themes;
            lbxVocabularies.ItemsSource = db.Words.ToList();
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
            }
            else
            {
                lbxVocabularies.ItemsSource = db.Words.Where(x => x.Theme.Id == selectedItem.Id).OrderBy(x => x.EnglishWord).ToList();
            }

            lbxVocabularies.SelectedIndex = 0;
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
        private void UpdateData(int type)
        {
            if (type == 1) 
            {
                ListBoxItem lbi = new ListBoxItem();
                lbi.BorderBrush = new SolidColorBrush(Colors.Black);
                lbi.BorderThickness = new Thickness(1, 1, 1, 1);
                lbi.Margin = new Thickness(0, 0, 0, 10);
                TextBlock tbxWord = new TextBlock();
                tbxWord.FontFamily = new FontFamily("Comic Sans MS");
                tbxWord.FontSize = 20;
                tbxWord.Text = (lbxSelectedVocabularies.Items.Count + 1).ToString() + ". " + selectedWords.Last().EnglishWord;
                lbi.Content = tbxWord;
                lbxSelectedVocabularies.Items.Add(lbi);
            }
            else
            {
                var selectedWord = selectedWords[lbxSelectedVocabularies.SelectedIndex];

                selectedWords.Remove(selectedWord);

                lbxSelectedVocabularies.Items.Clear();

                for (int i = 0; i< selectedWords.Count;i++ )
                {
                    ListBoxItem lbi = new ListBoxItem();
                    lbi.BorderBrush = new SolidColorBrush(Colors.Black);
                    lbi.BorderThickness = new Thickness(1, 1, 1, 1);
                    lbi.Margin = new Thickness(0, 0, 0, 10);
                    TextBlock tbxWord = new TextBlock();
                    tbxWord.FontFamily = new FontFamily("Comic Sans MS");
                    tbxWord.FontSize = 20;
                    tbxWord.Text = (lbxSelectedVocabularies.Items.Count + 1).ToString() + ". " + selectedWords[i].EnglishWord;
                    lbi.Content = tbxWord;
                    lbxSelectedVocabularies.Items.Add(lbi);
                }
            }
            if (lbxSelectedVocabularies.Items.Count > 0) 
            {
                lbxSelectedVocabularies.SelectedIndex = 0;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            btnRemove.IsEnabled = true;
            var selectedWord = ((Vocabulary)lbxVocabularies.SelectedItem);
            if (selectedWords.Contains(selectedWord)) return;
            selectedWords.Add(selectedWord);
            UpdateData(1);
            if (selectedWords.Count == 5)
            {
                btnNext.Visibility = Visibility.Visible;
                btnAdd.IsEnabled = false;
                return;
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            btnAdd.IsEnabled = true;
            UpdateData(2);
            if(selectedWords.Count == 0)
            {
                btnRemove.IsEnabled = false;
            }
            btnNext.Visibility = Visibility.Hidden;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToRight = true;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            GetData.created = true;
            ResetAnimationStatus();
            isUnloadToRight = true;
            Set set = new Set()
            {
                IsCreatedByTheme = false,
                ThemeId = 11,
                UserId = GetData.currentUser.Id
            };
            db.Sets.Add(set);
            db.SaveChanges();

            List<Model.WordSet> wordSets = new List<Model.WordSet>();

            foreach(var word in selectedWords)
            {
                Model.WordSet ws = new Model.WordSet()
                {
                    SetId = set.Id,
                    Star = 0,
                    WordId = word.Id
                };
                wordSets.Add(ws);
            }
            db.WordSets.AddRange(wordSets);
            db.SaveChanges();
        }

        private void imgBackButton_MouseEnter(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button_on.png", UriKind.Relative));
        }

        private void imgBackButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button.png", UriKind.Relative));
        }

        private void imgNextButton_MouseEnter(object sender, MouseEventArgs e)
        {
            imgNextButton.Source = new BitmapImage(new Uri("/Images/Button/correct_on.png", UriKind.Relative));
        }

        private void imgNextButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgNextButton.Source = new BitmapImage(new Uri("/Images/Button/correct.png", UriKind.Relative));
        }
    }
}
