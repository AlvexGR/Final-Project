using Game.Model;
using Game.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game.Presentation.Pages
{
    /// <summary>
    /// Interaction logic for TypingWord.xaml
    /// </summary>
    public partial class TypingWord : BasePage<TypingWordViewModel>
    {
        private int typingIdx = 0;
        private int idx = 0;
        private int numberOfWordPerRound = 5;
        private int progress = 0;
        private bool done = false;
        private bool doneWord = false;
        private bool readyToNextWord = false;
        private bool firstTry = true;
        private List<Vocabulary> vocabularies;
        private MainDb db;
        public TypingWord()
        {
            InitializeComponent();
            db = new MainDb();
            GetData.correctAnswer = 0;
            vocabularies = (from wordSet in db.WordSets
                            join word in db.Words on wordSet.WordId equals word.Id
                            where wordSet.SetId == GetData.curSet
                            select word).Distinct().ToList();
            LoadTextBoxes();
        }

        private void LoadTextBoxes()
        {
            btnCorrect.Visibility = Visibility.Hidden;
            proBarTypingRange.Value = 0;
            progress = 0;
            Vocabulary curWord = vocabularies[idx];
            imgWord.Source = new BitmapImage(new Uri(curWord.Image, UriKind.Relative));
            typingArea.Children.Clear();
            wordArea.Children.Clear();
            done = false;
            doneWord = false;
            for (int i = 0; i < curWord.EnglishWord.Length; i++)
            {
                TextBox tb = new TextBox();
                tb.BorderThickness = new Thickness(0, 0, 0, 5);
                tb.BorderBrush = Brushes.Black;
                tb.Width = 30;
                tb.Height = 50;
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                tb.HorizontalContentAlignment = HorizontalAlignment.Center;
                tb.Margin = new Thickness(0, 0, 5, 0);
                if(curWord.EnglishWord.Length>=10)
                {
                    tb.FontSize = 20;
                }
                else
                {
                    tb.FontSize = 30;
                }
                tb.MaxLength = 1;
                tb.FontFamily = new FontFamily("Comic Sans MS");
                tb.TextAlignment = TextAlignment.Center;
                tb.Background = null;
                tb.FontWeight = FontWeights.Bold;
                tb.IsReadOnly = true;
                tb.KeyDown += keyDown;
                typingArea.Children.Add(tb);

                TextBlock tbx = new TextBlock();
                tbx.FontFamily = new FontFamily("Comic Sans MS");
                tbx.FontSize = 40;
                tbx.FontWeight = FontWeights.Bold;
                tbx.HorizontalAlignment = HorizontalAlignment.Center;
                tbx.Text = curWord.EnglishWord[i].ToString();
                wordArea.Children.Add(tbx);
            }
            typingArea.Children[typingIdx].Focus();
            (wordArea.Children[typingIdx] as TextBlock).Foreground = Brushes.Green;
        }

        private void increasingProgressBar()
        {
            proBarTypingRange.Value += (100.0 / numberOfWordPerRound);
            progress++;
            if(proBarTypingRange.Value == proBarTypingRange.Maximum)
            {
                if(firstTry)
                {
                    GetData.correctAnswer |= (1 << idx);
                }
                done = true;
                if(idx == vocabularies.Count-1)
                {
                    btnFinish.Visibility = Visibility.Visible;
                }
                else
                {
                    btnCorrect.Visibility = Visibility.Visible;
                    readyToNextWord = true;
                }
            }
        }

        private void ResetAnimationStatus()
        {
            isUnloadToLeft = isUnloadToRight = isLoadBack = isLoadFromRight = firstTime = false;
        }

        private void btnCorrect_Click(object sender, RoutedEventArgs e)
        {
            idx++;
            LoadTextBoxes();
            mePronoun.Source = null;
            readyToNextWord = false;
            firstTry = true;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToRight = true;
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
            imgCorrectButton.Source = new BitmapImage(new Uri("/Images/Button/correct_on.png", UriKind.Relative));
        }

        private void imgCorrectButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgCorrectButton.Source = new BitmapImage(new Uri("/Images/Button/correct.png", UriKind.Relative));
        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
            mePronoun.Source = null;
            GetData.medal = 0;
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && btnFinish.Visibility == Visibility.Visible)
            {
                ResetAnimationStatus();
                isUnloadToLeft = true;
                mePronoun.Source = null;
                GetData.medal = 0;
                (DataContext as TypingWordViewModel).ResultCommand.Execute(null);
                return;
            }
            if (e.Key == Key.Enter && readyToNextWord)
            {
                idx++;
                LoadTextBoxes();
                mePronoun.Source = null;
                readyToNextWord = false;
                return;
            }
            if(typingIdx == 0)
            {
                mePronoun.Source = null;
            }
            if (!done && doneWord && e.Key == Key.Enter)
            {
                typingIdx = 0;
                typingArea.Children[typingIdx].Focus();
                increasingProgressBar();
                for (int i = 0; i < typingArea.Children.Count; i++)
                {
                    (typingArea.Children[i] as TextBox).Text = "";
                    (wordArea.Children[i] as TextBlock).Foreground = Brushes.Black;
                    wordArea.Children[i].Visibility = Visibility.Visible;
                }
                (wordArea.Children[typingIdx] as TextBlock).Foreground = Brushes.Green;
                if(progress > 1)
                {
                    Random rd = new Random();
                    int lossLetters = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(0.3 * vocabularies[idx].EnglishWord.Length)));
                    var lst = new List<int>();
                    for(int i= 0; i< vocabularies[idx].EnglishWord.Length;i++)
                    {
                        lst.Add(i);
                    }
                    var result = lst.OrderBy(item => rd.Next()).ToList();
                    int cur = 0;
                    while(lossLetters > 0)
                    {
                        for(int i = 0;i<vocabularies[idx].EnglishWord.Length;i++)
                        {
                            if(result[i] == cur)
                            {
                                wordArea.Children[i].Visibility = Visibility.Hidden;
                            }
                        }
                        lossLetters--;
                        cur++;
                    }
                }
                doneWord = false;
                return;
            }
            if (e.Key < Key.A || e.Key > Key.Z || done || doneWord)
            {
                return;
            }
            char c = e.Key.ToString().ToLower()[0];
            if (e.Key.ToString().ToLower()[0] == vocabularies[idx].EnglishWord[typingIdx])
            {
                (typingArea.Children[typingIdx] as TextBox).Text = e.Key.ToString();
                (typingArea.Children[typingIdx] as TextBox).Text = (typingArea.Children[typingIdx] as TextBox).Text.ToLower();
                (wordArea.Children[typingIdx] as TextBlock).Foreground = Brushes.Black;
                typingIdx++;
                if (typingIdx == vocabularies[idx].EnglishWord.Length)
                {
                    doneWord = true;
                    mePronoun.Source = new Uri("../.." + vocabularies[idx].Pronunciation, UriKind.Relative);
                    mePronoun.Play();
                }
                if(typingIdx < vocabularies[idx].EnglishWord.Length)
                {
                    typingArea.Children[typingIdx].Focus();
                    (wordArea.Children[typingIdx] as TextBlock).Foreground = Brushes.Green;
                }
            }
            else
            {
                (wordArea.Children[typingIdx] as TextBlock).Foreground = Brushes.Red;
                firstTry = false;
            }
        }
        private void imgFinishButton_MouseEnter(object sender, MouseEventArgs e)
        {
            imgFinishButton.Source = new BitmapImage(new Uri("/Images/Button/finish_on.png", UriKind.Relative));
        }

        private void imgFinishButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgFinishButton.Source = new BitmapImage(new Uri("/Images/Button/finish.png", UriKind.Relative));
        }
    }
}
