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

namespace Game.Presentation.Pages
{
    /// <summary>
    /// Interaction logic for VocabularyList.xaml
    /// </summary>
    public partial class VocabularyList : BasePage<VocabularyListViewModel>
    {
        private MainDb db;
        public VocabularyList()
        {
            InitializeComponent();
            db = new MainDb();
            lbxVocabularies.ItemsSource = db.Words.ToList();
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

        private void rdAllWords_Checked(object sender, RoutedEventArgs e)
        {
            lbxVocabularies.ItemsSource = db.Words.ToList();
        }

        private void rdKnownWords_Checked(object sender, RoutedEventArgs e)
        {
            lbxVocabularies.ItemsSource = db.Words.Where(x=>x.IsLearned).ToList();
        }

        private void rdUnknownWords_Checked(object sender, RoutedEventArgs e)
        {
            lbxVocabularies.ItemsSource = db.Words.Where(x => !x.IsLearned).ToList();
        }
    }
}
