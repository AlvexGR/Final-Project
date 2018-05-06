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
        #region Properties
        private int idx = 0;
        private Vocabulary vc;
        private MainDb db;
        private List<Vocabulary> vocabularies;
        #endregion

        #region Constructor
        public WordReview()
        {
            InitializeComponent();
            db = new MainDb();
            btnGoLeft.Visibility = Visibility.Hidden;
            btnFinish.Visibility = Visibility.Hidden;
            if(!GetData.isLearned)
            {
                var rnd = new Random();
                vocabularies = new List<Vocabulary>();
                GetData.wordListTotal = db.Words.Where(x => x.Theme.Id == GetData.curTheme && !x.IsLearned).ToList().OrderBy(item => rnd.Next()).ToList();
                for (int i = 0; i < 5; i++)
                {
                    vocabularies.Add(GetData.wordListTotal[i]);
                }
            }
            else
            {
                vocabularies = (from wordSet in db.WordSets
                                join word in db.Words on wordSet.WordId equals word.Id
                                where wordSet.SetId == GetData.curSet
                                select word).Distinct().ToList();
            }
            UpdateData();
        }
        #endregion

        #region Other Methods
        private void ResetAnimationStatus()
        {
            isUnloadToLeft = isUnloadToRight = isLoadBack = isLoadFromRight = firstTime = false;
        }

        private void UpdateData()
        {
            vc = vocabularies[idx];
            tbxDefinition.Text = vc.Definition;
            tbxEnglishWord.Text = vc.EnglishWord;
            if (tbxEnglishWord.Text.Length >= 20)
            {
                tbxEnglishWord.FontSize = 30;
            }
            else
            {
                tbxEnglishWord.FontSize = 40;
            }
            if (tbxDefinition.Text.Length >= 20)
            {
                tbxDefinition.FontSize = 30;
            }
            else
            {
                tbxDefinition.FontSize = 40;
            }
            tbxSpelling.Text = vc.Spelling;
            wordImage.Source = new BitmapImage(new Uri(vc.Image, UriKind.Relative));
            mePronoun.Source = new Uri("../.." + vc.Pronunciation, UriKind.Relative);
            mePronoun.Play();
        }
        #endregion

        #region Click Methods
        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToRight = true;
            mePronoun.Source = null;
        }
        
        private void btnGoRight_Click(object sender, RoutedEventArgs e)
        {
            idx++;
            if (idx == vocabularies.Count - 1)
            {
                btnGoRight.Visibility = Visibility.Hidden;
                if (GetData.isTheme && !GetData.isLearned)
                {
                    btnFinish.Visibility = Visibility.Visible;
                }
            }
            else
            {
                btnGoLeft.Visibility = Visibility.Visible;
                btnGoRight.Visibility = Visibility.Visible;
                btnFinish.Visibility = Visibility.Hidden;
            }
            UpdateData();
        }

        private void btnGoLeft_Click(object sender, RoutedEventArgs e)
        {
            idx--;
            if (idx == 0)
            {
                btnGoLeft.Visibility = Visibility.Hidden;
            }
            else
            {
                btnGoLeft.Visibility = Visibility.Visible;
                btnGoRight.Visibility = Visibility.Visible;
            }
            btnFinish.Visibility = Visibility.Hidden;
            UpdateData();
        }

        private void btnPronoun_Click(object sender, RoutedEventArgs e)
        {
            mePronoun.Source = new Uri("../.." + vc.Pronunciation, UriKind.Relative);
            mePronoun.Play();
        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToRight = true;
            mePronoun.Source = null;
            GetData.isLearned = true;
            Set set = new Set()
            {
                IsCreatedByTheme = true,
                ThemeId = GetData.curTheme,
                UserId = GetData.currentUser.Id
            };
            db.Sets.Add(set);
            db.SaveChanges();
            GetData.curSet = set.Id;

            List<Model.WordSet> wordSets = new List<Model.WordSet>();

            for (int i = 0; i < 5; i++)
            {
                Model.WordSet wordSet = new Model.WordSet()
                {
                    SetId = set.Id,
                    WordId = vocabularies[i].Id,
                    Star = 0
                };
                var word = db.Words.Find(vocabularies[i].Id);
                word.IsLearned = true;
                db.SaveChanges();
                wordSets.Add(wordSet);
            }
            db.WordSets.AddRange(wordSets);
            db.SaveChanges();

        }
        #endregion

        #region MouseEnter and MouseLeave Methods
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

        private void imgFinishButton_MouseEnter(object sender, MouseEventArgs e)
        {
            imgFinishButton.Source = new BitmapImage(new Uri("/Images/Button/finishStudy_on.png", UriKind.Relative));
        }

        private void imgFinishButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgFinishButton.Source = new BitmapImage(new Uri("/Images/Button/finishStudy.png", UriKind.Relative));
        }
        #endregion
    }
}
