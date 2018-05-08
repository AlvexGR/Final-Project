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
    /// Interaction logic for WordDetail.xaml
    /// </summary>
    public partial class WordDetail : BasePage<WordDetailViewModel>
    {
        #region Properties
        private Vocabulary vc;
        #endregion

        #region Constructor
        public WordDetail()
        {
            InitializeComponent();
            UpdateData();
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

        #region Click Methods
        private void btnPronoun_Click(object sender, RoutedEventArgs e)
        {
            mePronoun.Source = new Uri("../.." + vc.Pronunciation, UriKind.Relative);
            mePronoun.Play();
        }
        #endregion

        #region Click Methods
        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToRight = true;
            mePronoun.Source = null;
        }
        #endregion

        #region Other Methods
        private void UpdateData()
        {
            vc = GetData.curWord;
            tbxDefinition.Text = vc.Definition;
            tbxEnglishWord.Text = vc.EnglishWord;
            tbxSpelling.Text = vc.Spelling;
            wordImage.Source = new BitmapImage(new Uri(vc.Image, UriKind.Relative));
            mePronoun.Source = new Uri("../.." + vc.Pronunciation, UriKind.Relative);
            mePronoun.Play();
        }

        private void ResetAnimationStatus()
        {
            isUnloadToLeft = isUnloadToRight = isLoadFromLeft = isLoadFromRight = firstTime = false;
        }
        #endregion
    }
}
