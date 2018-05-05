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
using Game.UserControls;

namespace Game.Presentation.Pages
{
    /// <summary>
    /// Interaction logic for Result.xaml
    /// </summary>
    public partial class Result : BasePage<ResultViewModel>
    {
        private MainDb db;
        private List<Vocabulary> vocabularies;
        public Result()
        {
            InitializeComponent();
            db = new MainDb();
            int total = 0;
            vocabularies = (from wordSet in db.WordSets
                            join word in db.Words on wordSet.WordId equals word.Id
                            where wordSet.SetId == GetData.curSet
                            select word).Distinct().ToList();
            for (int i = 0; i <vocabularies.Count; i++)
            {
                StackPanel sp = new StackPanel();
                sp.Orientation = Orientation.Horizontal;
                Grid grid = new Grid();
                ColumnDefinition imgArea = new ColumnDefinition();
                ColumnDefinition textArea = new ColumnDefinition();
                imgArea.Width = new GridLength(50);
                textArea.Width = new GridLength(150);
                grid.ColumnDefinitions.Add(imgArea);
                grid.ColumnDefinitions.Add(textArea);
                Image img = new Image();
                TextBlock tbx = new TextBlock();
                img.Width = 30;
                img.Height = 30;
                tbx.FontFamily = new FontFamily("Comic Sans MS");
                tbx.Text = vocabularies[i].EnglishWord;
                tbx.FontSize = 20;
                tbx.VerticalAlignment = VerticalAlignment.Center;
                tbx.TextAlignment = TextAlignment.Left;
                tbx.Padding = new Thickness(5, 0, 0, 0);
                sp.Margin = new Thickness(0, 0, 0, 10);
                if ((GetData.correctAnswer & (1 << i)) > 0) 
                {
                    total++;
                    img.Source = new BitmapImage(new Uri("/Images/Other/correct.png", UriKind.Relative));
                    grid.Children.Add(img);
                    grid.Children.Add(tbx);
                    Grid.SetColumn(img, 0);
                    Grid.SetColumn(tbx, 1);
                    sp.Children.Add(grid);
                    correctWords.Children.Add(sp);
                    int wordId = vocabularies[i].Id;
                    Model.WordSet wordSet = db.WordSets.Where(x => x.SetId == GetData.curSet && x.WordId == wordId).Single();
                    wordSet.Star |= (1 << GetData.medal);
                    db.SaveChanges();
                }
                else
                {
                    img.Source = new BitmapImage(new Uri("/Images/Other/wrong.png", UriKind.Relative));
                    grid.Children.Add(img);
                    grid.Children.Add(tbx);
                    Grid.SetColumn(img, 0);
                    Grid.SetColumn(tbx, 1);
                    sp.Children.Add(grid);
                    wrongWords.Children.Add(sp);
                }
            }
            for (int i = 0; i < total; i++)
            {
                (starArea.Children[i] as Image).Source = new BitmapImage(new Uri("/Images/Other/star_on.png", UriKind.Relative));
            }
            tbxScore.Text = total.ToString() + "/" + vocabularies.Count.ToString();
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
    }
}
