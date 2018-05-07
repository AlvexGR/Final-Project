using Game.Model;
using Game.UserControls;
using System;
using System.Collections.Generic;
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
        #region Properties
        private int idx = 0;
        private Vocabulary rightAnswer;
        private bool firstChoice = true;
        private MainDb db;
        private List<Vocabulary> vocabularies;
        #endregion

        #region Constructor
        public SelectingWordOnListening()
        {
            InitializeComponent();
            db = new MainDb();
            GetData.correctAnswer = 0;
            vocabularies = (from wordSet in db.WordSets
                            join word in db.Words on wordSet.WordId equals word.Id
                            where wordSet.SetId == GetData.curSet
                            select word).Distinct().ToList();
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
            ResetButton();
            Random rd = new Random();
            rightAnswer = vocabularies[idx];
            var otherWords = db.Words.ToList().Where(x => x.Id != rightAnswer.Id).OrderBy(x => rd.Next()).ToList();

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
            mePronoun.Source = new Uri("../.." + rightAnswer.Pronunciation, UriKind.Relative);
            mePronoun.Play();
        }

        private void CheckAnswer(object sender, RoutedEventArgs e)
        {
            var btnRealAnswer = (Button)sender;
            var realAnswer = btnRealAnswer.Content;

            if (realAnswer.ToString() == rightAnswer.EnglishWord)
            {
                btnRealAnswer.BorderBrush = new SolidColorBrush(Colors.Green);
                btnRealAnswer.BorderThickness = new Thickness(3);
                if (firstChoice)
                {
                    GetData.correctAnswer |= (1 << idx);
                }
                idx++;
                if(idx == vocabularies.Count)
                {
                    ResetAnimationStatus();
                    isUnloadToLeft = true;
                    mePronoun.Source = null;
                    GetData.medal = 1;
                    (DataContext as SelectingWordOnListeningViewModel).ResultCommand.Execute(null);
                }
                else
                {
                    UpdateData();
                    firstChoice = true;
                }
            }
            else
            {
                btnRealAnswer.BorderThickness = new Thickness(3);
                btnRealAnswer.BorderBrush = new SolidColorBrush(Colors.Red);
                firstChoice = false;
            }
        }

        public void ResetButton()
        {
            btnA.BorderThickness = btnB.BorderThickness = btnC.BorderThickness = btnD.BorderThickness = new Thickness(0);
            btnA.BorderBrush = btnB.BorderBrush = btnC.BorderBrush = btnD.BorderBrush = new SolidColorBrush(Colors.White);
        }
        #endregion

        #region Click Methods
        private void btnPronoun_Click(object sender, RoutedEventArgs e)
        {
            mePronoun.Source = new Uri("../.." + rightAnswer.Pronunciation, UriKind.Relative);
            mePronoun.Play();
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToRight = true;
            mePronoun.Source = null;
        }
        #endregion

        #region MouseEnter and MouseLeave Methods
        private void imgBackButton_MouseEnter(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button_on.png", UriKind.Relative));
        }

        private void imgBackButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button.png", UriKind.Relative));
        }
        #endregion
    }
}
