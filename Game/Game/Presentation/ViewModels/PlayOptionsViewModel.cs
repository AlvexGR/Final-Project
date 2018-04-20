using Game.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Game.Presentation
{
    public class PlayOptionsViewModel : BaseViewModel
    {
        
        #region Public Properties
        public ICommand PreviousCommand { set; get; }
        public ICommand WordReviewCommand { set; get; }
        public ICommand SelectingWordOnListeningPageCommand { set; get; }
        public ICommand SelectingPictureOnListeningPageCommand { set; get; }
        #endregion

        #region Constructor
        public PlayOptionsViewModel()
        {
            PreviousCommand = new RelayCommand(async() => await GoToPrevious());
            WordReviewCommand = new RelayCommand(async () => await GoToWordReview());
            SelectingWordOnListeningPageCommand = new RelayCommand(async () => await GoToSelectingWordOnListening());
            SelectingPictureOnListeningPageCommand = new RelayCommand(async () => await GoToSelectingPictureOnListening());
        }
        #endregion

        #region Async Methods
        public async Task GoToPrevious()
        {
            var pageName = GetNameOfObject.GetName(PageStack.pageStack.Peek().ToString()) + "Page";
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = (AppPage.AppPage)Enum.Parse(typeof(AppPage.AppPage), pageName);
            await Task.Delay(1);
        }

        public async Task GoToWordReview()
        {
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPage.AppPage.WordReviewPage;
            await Task.Delay(1);
        }

        public async Task GoToSelectingWordOnListening()
        {
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPage.AppPage.SelectingWordOnListeningPage;
            await Task.Delay(1);
        }

        public async Task GoToSelectingPictureOnListening()
        {
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPage.AppPage.SelectingPictureOnListeningPage;
            await Task.Delay(1);
        }
        #endregion
    }
}
