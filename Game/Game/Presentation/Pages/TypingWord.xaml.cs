using Game.Model;
using Game.UserControls;
using System;
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
        private int numberOfWordPerRound = 10;
        private bool done = false;
        private bool doneWord = false;
        public TypingWord()
        {
            InitializeComponent();
            LoadTextBoxes();
        }

        private void LoadTextBoxes()
        {
            btnCorrect.Visibility = Visibility.Hidden;
            proBarTypingRange.Value = 0;
            Vocabulary curWord = GetData.wordList[idx];
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
                tb.FontSize = 30;
                tb.MaxLength = 1;
                tb.FontFamily = new FontFamily("Arial");
                tb.TextAlignment = TextAlignment.Center;
                tb.Background = null;
                tb.FontWeight = FontWeights.Bold;
                tb.IsReadOnly = true;
                tb.KeyDown += keyDown;
                typingArea.Children.Add(tb);

                TextBlock tbx = new TextBlock();
                tbx.FontFamily = new FontFamily("Arial");
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
            if(proBarTypingRange.Value == proBarTypingRange.Maximum)
            {
                done = true;
                if(idx == GetData.wordList.Count-1)
                {
                    btnFinish.Visibility = Visibility.Visible;
                }
                else
                {
                    btnCorrect.Visibility = Visibility.Visible;
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

        private void imgCorrectButton_MouseEnter(object sender, MouseEventArgs e)
        {
            imgCorrectButton.Source = new BitmapImage(new Uri("/Images/Button/next_button_on.png", UriKind.Relative));
        }

        private void imgCorrectButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgCorrectButton.Source = new BitmapImage(new Uri("/Images/Button/correct.png", UriKind.Relative));
        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {

        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if(typingIdx == 0)
            {
                mePronoun.Source = null;
            }
            if (!done && doneWord && (e.Key == Key.Enter  || e.Key == Key.Space))
            {
                typingIdx = 0;
                typingArea.Children[typingIdx].Focus();
                increasingProgressBar();
                for (int i = 0; i < typingArea.Children.Count; i++)
                {
                    (typingArea.Children[i] as TextBox).Text = "";
                    (wordArea.Children[i] as TextBlock).Foreground = Brushes.Black;
                }
                (wordArea.Children[typingIdx] as TextBlock).Foreground = Brushes.Green;
                doneWord = false;
                return;
            }
            if (e.Key < Key.A || e.Key > Key.Z || done || doneWord)
            {
                return;
            }
            char c = e.Key.ToString().ToLower()[0];
            if (e.Key.ToString().ToLower()[0] == GetData.wordList[idx].EnglishWord[typingIdx])
            {
                (typingArea.Children[typingIdx] as TextBox).Text = e.Key.ToString();
                (typingArea.Children[typingIdx] as TextBox).Text = (typingArea.Children[typingIdx] as TextBox).Text.ToLower();
                (wordArea.Children[typingIdx] as TextBlock).Foreground = Brushes.Black;
                typingIdx++;
                if (typingIdx == GetData.wordList[idx].EnglishWord.Length)
                {
                    doneWord = true;
                    mePronoun.Source = new Uri("../.." + GetData.wordList[idx].Pronunciation, UriKind.Relative);
                    mePronoun.Play();
                }
                if(typingIdx < GetData.wordList[idx].EnglishWord.Length)
                {
                    typingArea.Children[typingIdx].Focus();
                    (wordArea.Children[typingIdx] as TextBlock).Foreground = Brushes.Green;
                }
            }
            else
            {
                (wordArea.Children[typingIdx] as TextBlock).Foreground = Brushes.Red;
            }
        }
    }
}
