using Game.Model;
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
    /// Interaction logic for PlayOptions.xaml
    /// </summary>
    public partial class PlayOptions : BasePage<PlayOptionsViewModel>
    {
        private MainDb db = new MainDb();
        public PlayOptions()
        {
            InitializeComponent();
            if(!GetData.isTheme)
            {
                btnSelectingWordOnTheme.Visibility = Visibility.Hidden;
                GetData.wordListTotal = db.Words.ToList();
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

        private void randomizeListOfWord()
        {
            var rnd = new Random();
            GetData.wordListTotal = GetData.wordListTotal.OrderBy(item => rnd.Next()).ToList();
            GetData.wordList.Clear();
            for (int i = 0; i < 5; i++)
            {
                GetData.wordList.Add(GetData.wordListTotal[i]);
            }
        }

        private void btnWordReview_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
        }

        private void btnRandom_Click(object sender, RoutedEventArgs e)
        {
            randomizeListOfWord();
        }
    }
}
