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

namespace Game.Presentation.Pages
{
    /// <summary>
    /// Interaction logic for WordSet.xaml
    /// </summary>
    public partial class WordSet : BasePage<WordSetViewModel>
    {
        MainDb db;
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
                //var query = from wordSet in db.WordSets
                //            join sets in db.Sets on wordSet.Set.Id equals sets.Id
                //            where wordSet.User.Id == curentUser.Id
                //            orderby sets.CreatedDate
                //            select wordSet;

            }
            else
            {
                btnCustom1.Content = "Học";
                btnCustom2.Content = "Tạo bộ từ";
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
                CreatedDate = DateTime.Now.Date,
                IsCreatedByTheme = false
            };

            if (GetData.isTheme)
            {
                var selectedThemeId = GetData.curTheme;
                GetData.wordList = GetData.wordListTotal.Where(x => x.Theme.Id == selectedThemeId && x.IsLearned == false).Take(5).ToList();
                set.IsCreatedByTheme = true;
            }
            //db.Sets.Add(set);
            //db.SaveChanges();

            //List<Model.WordSet> wordSetList = new List<Model.WordSet>();
            //foreach (var item in GetData.wordList)
            //{
            //    Model.WordSet wordSet = new Model.WordSet()
            //    {
            //        User = user,
            //        Set = set,
            //        Word = item
            //    };
            //    wordSetList.Add(wordSet);
            //}
            //db.WordSets.AddRange(wordSetList);
            //db.SaveChanges();

        }
    }
}
