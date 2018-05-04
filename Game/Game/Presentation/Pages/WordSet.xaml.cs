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
using Game.UserControls;
using Game.Model;
using System.ComponentModel;

namespace Game.Presentation.Pages
{
    /// <summary>
    /// Interaction logic for WordSet.xaml
    /// </summary>
    public partial class WordSet : BasePage<WordSetViewModel>
    {
        private MainDb db = new MainDb();
        private List<Set> sets = new List<Set>();
        private List<Vocabulary> vocabularies = new List<Vocabulary>();
        private int idx = 0;
        private bool isDeleted = false;
        public WordSet()
        {
            InitializeComponent();
            if(GetData.isTheme)
            {
                var rnd = new Random();
                GetData.wordListTotal = db.Words.Where(x => x.Theme.Id == GetData.curTheme && !x.IsLearned).ToList().OrderBy(item => rnd.Next()).ToList();
                if (GetData.wordListTotal.Count == 0)
                {
                    btnNew.IsEnabled = false;
                }
            }
            UpdateSets();
            UpdateArrowButton();
        }
        
        private void UpdateArrowButton()
        {
            if (sets.Count <= 1)
            {
                btnGoLeft.Visibility = btnGoRight.Visibility = Visibility.Hidden;
            }
            else
            {
                if(idx == 0)
                {
                    btnGoRight.Visibility = Visibility.Visible;
                    btnGoLeft.Visibility = Visibility.Hidden;
                }
                else if(idx == sets.Count-1)
                {
                    btnGoRight.Visibility = Visibility.Hidden;
                    btnGoLeft.Visibility = Visibility.Visible;
                }
                else
                {
                    btnGoLeft.Visibility = Visibility.Visible;
                    btnGoRight.Visibility = Visibility.Visible;
                }
            }
        }

        private void UpdateSets()
        {
            if (GetData.isTheme)
            {
                sets = db.Sets.Where(x => x.UserId == GetData.currentUser.Id && x.IsCreatedByTheme && x.ThemeId == GetData.curTheme).ToList();
                if(!isDeleted)
                {
                    idx = sets.Count - 1;
                }
                AddWord();
            }
            else
            {

            }
        }

        private void AddWord()
        {
            if (sets.Count == 0) 
            {
                displayWord.Children.Clear();
                btnDelete.IsEnabled = false;
                btnReview.IsEnabled = false;
                return;
            }
            var curSet = sets[idx];
            vocabularies = (from wordSet in db.WordSets
                            join word in db.Words on wordSet.WordId equals word.Id
                            where wordSet.SetId == curSet.Id
                            select word).Distinct().ToList();
            displayWord.Children.Clear();
            GetData.wordList.Clear();
            foreach (var word in vocabularies)
            {
                TextBlock tbx = new TextBlock();
                tbx.Text = word.EnglishWord;
                tbx.FontFamily = new FontFamily("Arial");
                tbx.FontSize = 30;
                displayWord.Children.Add(tbx);
                GetData.wordList.Add(word);
            }
            btnDelete.IsEnabled = true;
            btnReview.IsEnabled = true;
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

        private void btnGoLeft_Click(object sender, RoutedEventArgs e)
        {
            idx--;
            UpdateArrowButton();
            AddWord();
        }

        private void btnGoRight_Click(object sender, RoutedEventArgs e)
        {
            idx++;
            UpdateArrowButton();
            AddWord();
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

        private void btnReview_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
            GetData.wordList = vocabularies;
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;

            Set set = new Set()
            {
                IsCreatedByTheme = true,
                ThemeId = GetData.curTheme,
                UserId = GetData.currentUser.Id
            };

            db.Sets.Add(set);
            db.SaveChanges();
            
            var rnd = new Random();
            GetData.wordListTotal = db.Words.Where(x => x.Theme.Id == GetData.curTheme && !x.IsLearned).ToList().OrderBy(item => rnd.Next()).ToList();
            GetData.wordList.Clear();

            List<Model.WordSet> wordSets = new List<Model.WordSet>();

            for (int i = 0; i < 5; i++)
            {
                GetData.wordList.Add(GetData.wordListTotal[i]);
                Model.WordSet wordSet = new Model.WordSet()
                {
                    SetId = set.Id,
                    WordId = GetData.wordList[i].Id
                };
                var word = db.Words.Find(GetData.wordList[i].Id);
                word.IsLearned = true;
                db.SaveChanges();
                wordSets.Add(wordSet);
            }
            if (db.Words.Where(x => x.Theme.Id == GetData.curTheme && !x.IsLearned).ToList().OrderBy(item => rnd.Next()).ToList().Count == 0)
            {
                btnNew.IsEnabled = false;
            }
            db.WordSets.AddRange(wordSets);
            db.SaveChanges();
            UpdateSets();
            UpdateArrowButton();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var curSet = sets[idx];
            foreach (var i in GetData.wordList)
            {
                var word = db.Words.Find(i.Id);
                word.IsLearned = false;
                db.SaveChanges();
            }
            if(idx>0)
            {
                idx--;
            }
            db.WordSets.RemoveRange(db.WordSets.Where(x => x.SetId == curSet.Id).ToList());
            db.Sets.Remove(db.Sets.Find(curSet.Id));
            db.SaveChanges();
            isDeleted = true;
            UpdateSets();
            UpdateArrowButton();
            isDeleted = false;
            btnNew.IsEnabled = true;
        }
    }
}
