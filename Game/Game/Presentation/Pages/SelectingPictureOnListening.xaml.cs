﻿using Game.Model;
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
    /// Interaction logic for SelectingPictureOnListening.xaml
    /// </summary>
    public partial class SelectingPictureOnListening : BasePage<SelectingPictureOnListeningViewModel>
    {
        private int idx = 0;
        private Vocabulary rightAnswer;
        int indexOfRightAnswer = 0;
        private bool firstChoice = true;
        private MainDb db;
        private List<Vocabulary> vocabularies;
        public SelectingPictureOnListening()
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

        private void UpdateData()
        {
            ResetButton();
            Random rd = new Random();
            rightAnswer = vocabularies[idx];
            List<Vocabulary> otherWords = new List<Vocabulary>();
            otherWords = db.Words.ToList().Where(x => x.Id != rightAnswer.Id && x.Theme.Id == rightAnswer.Theme.Id).OrderBy(x => rd.Next()).ToList();

            indexOfRightAnswer = rd.Next(1, 5);
            if (indexOfRightAnswer == 1)
            {
                imgA.Source = new BitmapImage(new Uri(rightAnswer.Image, UriKind.Relative));

                imgB.Source = new BitmapImage(new Uri(otherWords[0].Image, UriKind.Relative));
                imgC.Source = new BitmapImage(new Uri(otherWords[1].Image, UriKind.Relative));
                imgD.Source = new BitmapImage(new Uri(otherWords[2].Image, UriKind.Relative));
            }
            else if (indexOfRightAnswer == 2)
            {
                imgB.Source = new BitmapImage(new Uri(rightAnswer.Image, UriKind.Relative));

                imgA.Source = new BitmapImage(new Uri(otherWords[0].Image, UriKind.Relative));
                imgC.Source = new BitmapImage(new Uri(otherWords[1].Image, UriKind.Relative));
                imgD.Source = new BitmapImage(new Uri(otherWords[2].Image, UriKind.Relative));
            }
            else if (indexOfRightAnswer == 3)
            {
                imgC.Source = new BitmapImage(new Uri(rightAnswer.Image, UriKind.Relative));


                imgB.Source = new BitmapImage(new Uri(otherWords[0].Image, UriKind.Relative));
                imgA.Source = new BitmapImage(new Uri(otherWords[1].Image, UriKind.Relative));
                imgD.Source = new BitmapImage(new Uri(otherWords[2].Image, UriKind.Relative));
            }
            else
            {
                imgD.Source = new BitmapImage(new Uri(rightAnswer.Image, UriKind.Relative));

                imgB.Source = new BitmapImage(new Uri(otherWords[0].Image, UriKind.Relative));
                imgA.Source = new BitmapImage(new Uri(otherWords[1].Image, UriKind.Relative));
                imgC.Source = new BitmapImage(new Uri(otherWords[2].Image, UriKind.Relative));
            }
            btnCorrect.Visibility = Visibility.Hidden;
            mePronoun.Source = new Uri("../.." + rightAnswer.Pronunciation, UriKind.Relative);
            mePronoun.Play();
        }

        private void CheckAnswer(object sender, RoutedEventArgs e)
        {
            var btnRealAnswer = (Button)sender;
            int indexAnswer = 0;
            if(btnRealAnswer.Name == "btnA")
            {
                indexAnswer = 1;
            }
            else if (btnRealAnswer.Name == "btnB")
            {
                indexAnswer = 2;
            }
            else if (btnRealAnswer.Name == "btnC")
            {
                indexAnswer = 3;
            }
            else if (btnRealAnswer.Name == "btnD")
            {
                indexAnswer = 4;
            }

            if (indexAnswer == indexOfRightAnswer)
            {
                if(firstChoice)
                {
                    GetData.correctAnswer |= (1 << idx);
                }
                btnRealAnswer.BorderBrush = new SolidColorBrush(Colors.Green);
                btnRealAnswer.BorderThickness = new Thickness(3);
                if (idx == (vocabularies.Count - 1))
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
                btnRealAnswer.BorderBrush = new SolidColorBrush(Colors.Red);
                btnRealAnswer.BorderThickness = new Thickness(3);
            }
            firstChoice = false;
        }
        public void ResetButton()
        {
            btnA.BorderThickness = btnB.BorderThickness = btnC.BorderThickness = btnD.BorderThickness = new Thickness(0);
            btnA.BorderBrush = btnB.BorderBrush = btnC.BorderBrush = btnD.BorderBrush = new SolidColorBrush(Colors.White);
        }
        private void ResetAnimationStatus()
        {
            isUnloadToLeft = isUnloadToRight = isLoadBack = isLoadFromRight = firstTime = false;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToRight = true;
            mePronoun.Source = null;
        }

        private void btnPronoun_Click(object sender, RoutedEventArgs e)
        {
            mePronoun.Source = new Uri("../.." + rightAnswer.Pronunciation, UriKind.Relative);
            mePronoun.Play();
        }
        private void btnCorrect_Click(object sender, RoutedEventArgs e)
        {
            idx++;
            UpdateData();
            firstChoice = true;
        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
            mePronoun.Source = null;
            //PlayHistory playHistory = new PlayHistory()
            //{
            //    Date = DateTime.Today,
            //    Score = GetData.correctAnswer
            //};
            //db.PlayHistories.Add(playHistory);
            //db.SaveChanges();
            GetData.medal = 2;
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
            imgCorrectButton.Source = new BitmapImage(new Uri("/Images/Button/correct_on.png", UriKind.Relative));
        }

        private void imgCorrectButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgCorrectButton.Source = new BitmapImage(new Uri("/Images/Button/correct.png", UriKind.Relative));
        }

        private void imgFinishButton_MouseEnter(object sender, MouseEventArgs e)
        {
            imgFinishButton.Source = new BitmapImage(new Uri("/Images/Button/correct_on.png", UriKind.Relative));
        }

        private void imgFinishButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgFinishButton.Source = new BitmapImage(new Uri("/Images/Button/correct.png", UriKind.Relative));
        }
    }
}
