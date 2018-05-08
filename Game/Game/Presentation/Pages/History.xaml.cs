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
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : BasePage<HistoryViewModel>
    {
        //MainDb db;
        //public History()
        //{
        //    InitializeComponent();
        //    db = new MainDb();

        //    lbxPlayHistories.ItemsSource = db.PlayHistories.Select(x => new PlayHitoriesView
        //    {
        //        Date = x.Date.Day + "/" + x.Date.Month + "/" + x.Date.Year,
        //        Score = x.Score.ToString()
        //    }).ToList();
        //}

        //private void ResetAnimationStatus()
        //{
        //    isUnloadToLeft = isUnloadToRight = isLoadFromLeft = isLoadFromRight = firstTime = false;
        //}

        //private void btnGoBack_Click(object sender, RoutedEventArgs e)
        //{
        //    ResetAnimationStatus();
        //    isUnloadToRight = true;
        //}

        //private void imgBackButton_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button_on.png", UriKind.Relative));
        //}

        //private void imgBackButton_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button.png", UriKind.Relative));
        //}



        //private void rdNewToOld_Checked(object sender, RoutedEventArgs e)
        //{
        //    lbxPlayHistories.ItemsSource = db.PlayHistories.OrderBy(x => x.Date).Select(x => new PlayHitoriesView
        //    {
        //        Date = x.Date.Day + "/" + x.Date.Month + "/" + x.Date.Year,
        //        Score = x.Score.ToString()
        //    }).ToList();
        //}

        //private void rdOldToNew_Checked(object sender, RoutedEventArgs e)
        //{
        //    lbxPlayHistories.ItemsSource = db.PlayHistories.OrderByDescending(x => x.Date).Select(x => new PlayHitoriesView
        //    {
        //        Date = x.Date.Day + "/" + x.Date.Month + "/" + x.Date.Year,
        //        Score = x.Score.ToString()
        //    }).ToList();
        //}

        //private void rdIncreasePoint_Checked(object sender, RoutedEventArgs e)
        //{
        //    lbxPlayHistories.ItemsSource = db.PlayHistories.OrderBy(x => x.Score).Select(x => new PlayHitoriesView
        //    {
        //        Date = x.Date.Day + "/" + x.Date.Month + "/" + x.Date.Year,
        //        Score = x.Score.ToString()
        //    }).ToList();
        //}

        //private void rdDecreasePoint_Checked(object sender, RoutedEventArgs e)
        //{
        //    lbxPlayHistories.ItemsSource = db.PlayHistories.OrderByDescending(x => x.Score).Select(x => new PlayHitoriesView
        //    {
        //        Date = x.Date.Day + "/" + x.Date.Month + "/" + x.Date.Year,
        //        Score = x.Score.ToString()
        //    }).ToList();
        //}

        //public class PlayHitoriesView
        //{
        //    public string Date { get; set; }
        //    public string Score { get; set; }
        //}
    }

}
