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
        #region Properties
        private MainDb db;
        private List<Set> sets = new List<Set>();
        private List<Vocabulary> vocabularies = new List<Vocabulary>();
        private int idx = 0;
        private bool isDeleted = false;
        #endregion

        #region Constructor
        public WordSet()
        {
            InitializeComponent();
            db = new MainDb();
            LoadData();
        }
        #endregion

        #region Other Methods
        public void LoadData()
        {
            if (GetData.isTheme)
            {
                var rnd = new Random();
                GetData.wordListTotal = db.Words.Where(x => x.Theme.Id == GetData.curTheme && !x.IsLearned).ToList().OrderBy(item => rnd.Next()).ToList();
                if (GetData.wordListTotal.Count == 0)
                {
                    btnNew.IsEnabled = false;
                    imgNew.Opacity = 0.5;
                }
                tbxNew.Text = "Học bộ từ mới";
                tbxReview.Text = "Ôn lại bộ từ";
                imgReview.Source = new BitmapImage(new Uri("/Images/Button/review.png", UriKind.Relative));
            }
            else
            {
                tbxNew.Text = "Tạo bộ từ mới";
                tbxReview.Text = "Học bộ từ";
                imgReview.Source = new BitmapImage(new Uri("/Images/Button/learn.png", UriKind.Relative));
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
                if (idx == 0)
                {
                    btnGoRight.Visibility = Visibility.Visible;
                    btnGoLeft.Visibility = Visibility.Hidden;
                }
                else if (idx == sets.Count - 1)
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
            }
            else
            {
                sets = db.Sets.Where(x => x.UserId == GetData.currentUser.Id && !x.IsCreatedByTheme).ToList();
            }
            if (!isDeleted)
            {
                idx = sets.Count - 1;
            }
            AddWord();
        }

        private void AddWord()
        {
            if (sets.Count == 0)
            {
                displayWord.Children.Clear();
                btnDelete.IsEnabled = false;
                btnReview.IsEnabled = false;
                imgDelete.Opacity = 0.5;
                imgReview.Opacity = 0.5;
                return;
            }
            db = new MainDb();
            var curSet = sets[idx];
            vocabularies = (from wordSet in db.WordSets
                            join word in db.Words on wordSet.WordId equals word.Id
                            where wordSet.SetId == curSet.Id
                            select word).Distinct().ToList();
            displayWord.Children.Clear();
            foreach (var word in vocabularies)
            {
                // Text block to display Word
                TextBlock tbx = new TextBlock();
                tbx.Text = word.EnglishWord;
                tbx.FontFamily = new FontFamily("Comic Sans MS");
                tbx.FontSize = 25;
                tbx.VerticalAlignment = VerticalAlignment.Center;
                tbx.HorizontalAlignment = HorizontalAlignment.Left;
                tbx.TextAlignment = TextAlignment.Left;
                tbx.Padding = new Thickness(10, 0, 0, 0);

                StackPanel sp = new StackPanel();
                sp.Orientation = Orientation.Horizontal;
                Grid grid = new Grid();
                ColumnDefinition imgArea = new ColumnDefinition();
                ColumnDefinition textArea = new ColumnDefinition();
                imgArea.Width = new GridLength(95);
                textArea.Width = new GridLength(180);
                grid.ColumnDefinitions.Add(imgArea);
                grid.ColumnDefinitions.Add(textArea);

                int stars = db.WordSets.Where(x => x.SetId == curSet.Id && x.WordId == word.Id).Single().Star;

                // Image for stars
                Image img_pict = new Image();
                img_pict.Width = 30;
                img_pict.Height = 30;
                if ((stars & (1 << 2)) > 0)
                {
                    img_pict.Source = new BitmapImage(new Uri("/Images/Other/bronze_medal.png", UriKind.Relative));
                }
                else
                {
                    img_pict.Source = new BitmapImage(new Uri("/Images/Other/medal.png", UriKind.Relative));
                }

                Image img_word = new Image();
                img_word.Width = 30;
                img_word.Height = 30;
                if ((stars & (1 << 1)) > 0)
                {
                    img_word.Source = new BitmapImage(new Uri("/Images/Other/silver_medal.png", UriKind.Relative));
                }
                else
                {
                    img_word.Source = new BitmapImage(new Uri("/Images/Other/medal.png", UriKind.Relative));
                }

                Image img_type = new Image();
                img_type.Width = 30;
                img_type.Height = 30;
                if ((stars & 1) > 0)
                {
                    img_type.Source = new BitmapImage(new Uri("/Images/Other/gold_medal.png", UriKind.Relative));
                }
                else
                {
                    img_type.Source = new BitmapImage(new Uri("/Images/Other/medal.png", UriKind.Relative));
                }

                img_pict.HorizontalAlignment = img_word.HorizontalAlignment = img_type.HorizontalAlignment = HorizontalAlignment.Left;

                Grid starArea = new Grid();
                ColumnDefinition cdPict = new ColumnDefinition();
                ColumnDefinition cdWord = new ColumnDefinition();
                ColumnDefinition cdType = new ColumnDefinition();
                cdPict.Width = new GridLength(1, GridUnitType.Star);
                cdWord.Width = new GridLength(1, GridUnitType.Star);
                cdType.Width = new GridLength(1, GridUnitType.Star);
                starArea.ColumnDefinitions.Add(cdPict);
                starArea.ColumnDefinitions.Add(cdWord);
                starArea.ColumnDefinitions.Add(cdType);
                starArea.Children.Add(img_pict);
                starArea.Children.Add(img_word);
                starArea.Children.Add(img_type);
                Grid.SetColumn(img_pict, 0);
                Grid.SetColumn(img_word, 1);
                Grid.SetColumn(img_type, 2);

                grid.Children.Add(starArea);
                grid.Children.Add(tbx);
                Grid.SetColumn(starArea, 0);
                Grid.SetColumn(tbx, 1);
                sp.Margin = new Thickness(0, 0, 0, 10);
                sp.Children.Add(grid);
                displayWord.Children.Add(sp);
            }
            btnDelete.IsEnabled = true;
            btnReview.IsEnabled = true;
            imgDelete.Opacity = 1;
            imgReview.Opacity = 1;
        }

        private void ResetAnimationStatus()
        {
            isUnloadToLeft = isUnloadToRight = isLoadFromLeft = isLoadFromRight = firstTime = false;
        }
        #endregion

        #region Click Methods
        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToRight = true;
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

        private void btnReview_Click(object sender, RoutedEventArgs e)
        {
            db = new MainDb();
            ResetAnimationStatus();
            isUnloadToLeft = true;
            GetData.isLearned = true;
            GetData.curSet = sets[idx].Id;
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            db = new MainDb();
            ResetAnimationStatus();
            isUnloadToLeft = true;
            if (GetData.isTheme)
            {
                GetData.isLearned = false;
                (DataContext as WordSetViewModel).PlayOptionsCommand.Execute(null);
            }
            else
            {
                (DataContext as WordSetViewModel).WordSelectionCommand.Execute(null);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Bạn muốn xoá bộ từ này?", "Xoá bộ từ?", MessageBoxButton.YesNo,MessageBoxImage.Question,MessageBoxResult.No);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                db = new MainDb();
                var curSet = sets[idx];
                foreach (var i in vocabularies)
                {
                    var word = db.Words.Find(i.Id);
                    word.IsLearned = false;
                    db.SaveChanges();
                }
                if (idx > 0)
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
                imgNew.Opacity = 1;
            }

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

        private void imgBackButton_MouseEnter(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button_on.png", UriKind.Relative));
        }

        private void imgBackButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button.png", UriKind.Relative));
        }

        private void imgArrowLeft_MouseEnter(object sender, MouseEventArgs e)
        {
            imgArrowLeft.Source = new BitmapImage(new Uri("/Images/Button/arrow_left_on.png", UriKind.Relative));
        }

        private void imgArrowLeft_MouseLeave(object sender, MouseEventArgs e)
        {
            imgArrowLeft.Source = new BitmapImage(new Uri("/Images/Button/arrow_left.png", UriKind.Relative));
        }
        #endregion
    }
}
