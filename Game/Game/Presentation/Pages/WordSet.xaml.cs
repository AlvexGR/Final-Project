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
        public WordSet()
        {
            InitializeComponent();
            UpdateSets();
            UpdateArrowButton();
        }
        
        private void UpdateArrowButton()
        {
            if (sets.Count <= 1)
            {
                btnGoLeft.Visibility = btnGoRight.Visibility = Visibility.Hidden;
            }
        }

        private void UpdateSets()
        {
            if (GetData.isTheme)
            {
                sets = db.Sets.Where(x => x.UserId == GetData.currentUser.Id && x.IsCreatedByTheme && x.ThemeId == GetData.curTheme).ToList();
                if (sets.Count > 0)
                {
                    AddWord();
                }
            }
            else
            {

            }
        }

        private void AddWord()
        {
            var curSet = sets[idx];
            vocabularies = (from wordSet in db.WordSets
                            join word in db.Words on wordSet.WordId equals word.Id
                            where wordSet.SetId == curSet.Id
                            select word).Distinct().ToList();
            displayWord.DataContext = vocabularies;
            displayWord.Children.Clear();
            foreach (var word in vocabularies)
            {
                TextBlock tbx = new TextBlock();
                tbx.Text = word.EnglishWord;
                tbx.FontFamily = new FontFamily("Arial");
                tbx.FontSize = 40;
                displayWord.Children.Add(tbx);
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
           
        }

        private void btnGoRight_Click(object sender, RoutedEventArgs e)
        {
            
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
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var curSet = sets[idx];
            db.WordSets.RemoveRange(db.WordSets.Where(x => x.SetId == curSet.Id).ToList());
            db.Sets.Remove(db.Sets.Find(curSet.Id));
            db.SaveChanges();
            UpdateSets();
        }
    }
}
