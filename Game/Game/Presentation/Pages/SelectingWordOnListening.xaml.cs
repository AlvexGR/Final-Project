using Game.Model;
using Game.UserControls;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game.Presentation.Pages
{
    /// <summary>
    /// Interaction logic for SelectingWordOnListening.xaml
    /// </summary>
    public partial class SelectingWordOnListening : BasePage<SelectingWordOnListeningViewModel>
    {
        private int idx = 0;
        private Vocabulary rightAnswer;
        public SelectingWordOnListening()
        {
            InitializeComponent();
            UpdateData();
        }
        private void ResetAnimationStatus()
        {
            isUnloadToLeft = isUnloadToRight = isLoadBack = isLoadFromRight = firstTime = false;
        }

        private void UpdateData()
        {
            ResetButton();
            Random rd = new Random();
            rightAnswer = GetData.wordList[idx];
            var otherWords = GetData.wordListTotal.Where(x => x.Theme.Id == rightAnswer.Theme.Id && x.Id != rightAnswer.Id).OrderBy(x=>rd.Next()).ToList(); //all words have the same theme with right answer, except right answer

            var indexOfRightAnswer = rd.Next(1,5);
            if(indexOfRightAnswer == 1)
            {
                btnA.Content = rightAnswer.EnglishWord;

                btnB.Content = otherWords[0].EnglishWord;
                btnC.Content = otherWords[1].EnglishWord;
                btnD.Content = otherWords[2].EnglishWord;
            }
            else if(indexOfRightAnswer == 2)
            {
                btnB.Content = rightAnswer.EnglishWord;

                btnA.Content = otherWords[0].EnglishWord;
                btnC.Content = otherWords[1].EnglishWord;
                btnD.Content = otherWords[2].EnglishWord;
            }
            else if(indexOfRightAnswer == 3)
            {
                btnC.Content = rightAnswer.EnglishWord;

                btnB.Content = otherWords[0].EnglishWord;
                btnA.Content = otherWords[1].EnglishWord;
                btnD.Content = otherWords[2].EnglishWord;
            }
            else
            {
                btnD.Content = rightAnswer.EnglishWord;

                btnB.Content = otherWords[0].EnglishWord;
                btnC.Content = otherWords[1].EnglishWord;
                btnA.Content = otherWords[2].EnglishWord;
            }
            btnCorrect.Visibility = Visibility.Hidden;
            mePronoun.Source = new Uri("../.." + rightAnswer.Pronunciation, UriKind.Relative);
            mePronoun.Play();
        }

        private void btnCorrect_Click(object sender, RoutedEventArgs e)
        {
            idx++;
            UpdateData();
        }

        private void CheckAnswer(object sender, RoutedEventArgs e)
        {
            var btnRealAnswer = (Button)sender;
            var realAnswer = btnRealAnswer.Content;

            if(realAnswer.ToString() == rightAnswer.EnglishWord)
            {
                btnRealAnswer.BorderBrush = new SolidColorBrush(Colors.Green);
                btnRealAnswer.BorderThickness = new Thickness(3);
                if(idx == (GetData.wordList.Count-1))
                {
                    btnFinish.Visibility = Visibility.Visible;
                }
                else
                {
                    btnCorrect.Visibility = Visibility.Visible;
                }
            }
            else
            {
                btnRealAnswer.BorderThickness = new Thickness(3);
                btnRealAnswer.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            
        }

        private void btnPronoun_Click(object sender, RoutedEventArgs e)
        {
            mePronoun.Source = new Uri("../.." + rightAnswer.Pronunciation, UriKind.Relative);
            mePronoun.Play();
        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToRight = true;
            mePronoun.Source = null;
        }

        public void ResetButton()
        {
            btnA.BorderThickness = btnB.BorderThickness = btnC.BorderThickness = btnD.BorderThickness = new Thickness(0);
            btnA.BorderBrush = btnB.BorderBrush = btnC.BorderBrush = btnD.BorderBrush = new SolidColorBrush(Colors.White);
            btnA.IsEnabled = btnB.IsEnabled = btnC.IsEnabled = btnD.IsEnabled = true;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
            mePronoun.Source = null;
        }

        private void imgBackButton_MouseEnter(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button_on.png", UriKind.Relative));
        }

        private void imgBackButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button.png", UriKind.Relative));
        }
        private void imgCorrectButton_MouseEnter(object sender, MouseEventArgs e)
        {
            imgCorrectButton.Source = new BitmapImage(new Uri("/Images/Button/next_button_on.png", UriKind.Relative));
        }

        private void imgCorrectButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgCorrectButton.Source = new BitmapImage(new Uri("/Images/Button/correct.png", UriKind.Relative));
        }
    }
}
