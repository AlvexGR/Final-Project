using Game.Model;
using Game.UserControls;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

                btnB.Content = otherWords[1].EnglishWord;
                btnC.Content = otherWords[2].EnglishWord;
                btnD.Content = otherWords[3].EnglishWord;
            }
            else if(indexOfRightAnswer == 2)
            {
                btnB.Content = rightAnswer.EnglishWord;

                btnA.Content = otherWords[1].EnglishWord;
                btnC.Content = otherWords[2].EnglishWord;
                btnD.Content = otherWords[3].EnglishWord;
            }
            else if(indexOfRightAnswer == 3)
            {
                btnC.Content = rightAnswer.EnglishWord;

                btnB.Content = otherWords[1].EnglishWord;
                btnA.Content = otherWords[2].EnglishWord;
                btnD.Content = otherWords[3].EnglishWord;
            }
            else
            {
                btnD.Content = rightAnswer.EnglishWord;

                btnB.Content = otherWords[1].EnglishWord;
                btnC.Content = otherWords[2].EnglishWord;
                btnA.Content = otherWords[3].EnglishWord;
            }
            btnNext.Visibility = Visibility.Hidden;
            mePronoun.Source = new Uri("../.." + rightAnswer.Pronunciation, UriKind.Relative);
            mePronoun.Play();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
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
                    btnNext.Visibility = Visibility.Visible;
                }
            }
            else
            {
                btnRealAnswer.IsEnabled = false;
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
        }

        public void ResetButton()
        {
            btnA.BorderThickness = btnB.BorderThickness = btnC.BorderThickness = btnD.BorderThickness = new Thickness(0);
            btnA.BorderBrush = btnB.BorderBrush = btnC.BorderBrush = btnD.BorderBrush = new SolidColorBrush(Colors.White);
            btnA.IsEnabled = btnB.IsEnabled = btnC.IsEnabled = btnD.IsEnabled = true;
        }
    }
}
