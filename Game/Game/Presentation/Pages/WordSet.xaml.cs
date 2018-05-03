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
    public partial class WordSet : BasePage<WordSetViewModel>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        MainDb db;
        int indexOfWordset = 0;
        public Set CurrentSet { get; set; }
        public List<Set> SetsOfUser { get; set; }

        List<Vocabulary> _wordsOfCurrentSet;
        public List<Vocabulary> WordsOfCurrentSet
        {
            get
            {
                return _wordsOfCurrentSet;
            }
            set
            {
                _wordsOfCurrentSet = value;
                OnPropertyChanged("WordsOfCurrentSet");
            }
        }
        public WordSet()
        {
            InitializeComponent();
            db = new MainDb();
            //default user
            var curentUser = db.Users.FirstOrDefault();

            if (GetData.isTheme)
            {
                btnCustom1.Content = "Ôn";
                btnCustom2.Content = "Học mới";
                SetsOfUser = db.Sets.Where(x => x.UserId == curentUser.Id && x.IsCreatedByTheme).ToList();
            }
            else
            {
                btnCustom1.Content = "Học";
                btnCustom2.Content = "Tạo bộ từ";
                SetsOfUser = db.Sets.Where(x => x.UserId == curentUser.Id && !x.IsCreatedByTheme).ToList();
            }
            if (SetsOfUser.Count != 0)
            {
                CurrentSet = SetsOfUser[indexOfWordset];
                WordsOfCurrentSet = (from wordSet in db.WordSets
                                     join word in db.Words on wordSet.WordId equals word.Id
                                     where wordSet.SetId == CurrentSet.Id
                                     select word).Distinct().ToList();
            }
            else
            {
                btnCustom1.IsEnabled = false;
            }

            DataContext = this;
            btnGoLeft.Visibility = Visibility.Hidden;
            if(SetsOfUser.Count <= 1)
            {
                btnGoRight.Visibility = Visibility.Hidden;
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
            indexOfWordset--;
            btnGoRight.Visibility = Visibility.Visible;
            if (indexOfWordset == 0)
            {
                btnGoLeft.Visibility = Visibility.Hidden;
            }
            CurrentSet = SetsOfUser[indexOfWordset];
            WordsOfCurrentSet = (from wordSet in db.WordSets
                                 join word in db.Words on wordSet.WordId equals word.Id
                                 where wordSet.SetId == CurrentSet.Id
                                 select word).ToList();
        }

        private void btnGoRight_Click(object sender, RoutedEventArgs e)
        {
            indexOfWordset++;
            btnGoLeft.Visibility = Visibility.Visible;
            if (indexOfWordset == SetsOfUser.Count - 1)
            {
                btnGoRight.Visibility = Visibility.Hidden;
            }
            CurrentSet = SetsOfUser[indexOfWordset];
            WordsOfCurrentSet = (from wordSet in db.WordSets
                                 join word in db.Words on wordSet.WordId equals word.Id
                                 where wordSet.SetId == CurrentSet.Id
                                 select word).ToList();
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
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
        }

        private void btnCustom1_Click(object sender, RoutedEventArgs e)
        {


            ResetAnimationStatus();
            isUnloadToLeft = true;
        }

        private void btnCustom2_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;

            //user default
            User user = db.Users.FirstOrDefault();

            Set set = new Set()
            {
                IsCreatedByTheme = false,
                UserId = user.Id
            };

            if (GetData.isTheme)
            {
                //random five words from current theme
                GetData.wordList = GetData.wordListTotal.Where(x => x.Theme.Id == GetData.curTheme && x.IsLearned == false).Take(5).ToList();

                //set to true if these words have the same theme
                set.IsCreatedByTheme = true;
            }
            db.Sets.Add(set);
            db.SaveChanges();

            List<Model.WordSet> wordSetList = new List<Model.WordSet>();
            foreach (var item in GetData.wordList)
            {
                Model.WordSet wordSet = new Model.WordSet()
                {
                    SetId = set.Id,
                    WordId = item.Id
                };

                if (GetData.isTheme)
                {
                    var word = db.Words.Find(item.Id);
                    word.IsLearned = true;
                }

                wordSetList.Add(wordSet);
            }
            db.WordSets.AddRange(wordSetList);
            db.SaveChanges();

        }
    }
}
