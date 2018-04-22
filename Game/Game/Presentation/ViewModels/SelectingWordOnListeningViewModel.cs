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
    public class SelectingWordOnListeningViewModel : BaseViewModel
    {
        
        #region Public Properties
        public ICommand PreviousCommand { set; get; }
        public ICommand ResultCommand { set; get; }
        #endregion

        #region Constructor
        public SelectingWordOnListeningViewModel()
        {
            PreviousCommand = new RelayCommand(async() => await GoToPrevious());
            ResultCommand = new RelayCommand(async () => await GoToResult());
        }
        #endregion

        #region Async Methods
        public async Task GoToPrevious()
        {
            var pageName = GetNameOfObject.GetName(PageStack.pageStack.Peek().ToString()) + "Page";
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = (AppPage.AppPage)Enum.Parse(typeof(AppPage.AppPage), pageName);
            await Task.Delay(1);
        }
        public async Task GoToResult()
        {
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPage.AppPage.ResultPage;
            await Task.Delay(1);
        }
        #endregion
    }
}
