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
    public class NoThemeSelectionViewModel : BaseViewModel
    {

        #region Public Properties

        public ICommand PreviousCommand { set; get; }
        public ICommand RandomCommand { set; get; }
        public ICommand ManualCommand { set; get; }

        #endregion

        #region Constructor
        public NoThemeSelectionViewModel()
        {
            PreviousCommand = new RelayCommand(async () => await GoToPrevious());
            RandomCommand = new RelayCommand(async () => await GoToPlayOptions());
            ManualCommand = new RelayCommand(async () => await GoToPrevious());
        }

        #endregion

        #region Async Methods
        public async Task GoToPrevious()
        {
            var pageName = GetNameOfObject.GetName(PageStack.pageStack.Peek().ToString()) + "Page";
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = (AppPage.AppPage)Enum.Parse(typeof(AppPage.AppPage), pageName);
            await Task.Delay(1);
        }

        public async Task GoToPlayOptions()
        {
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPage.AppPage.PlayOptionsPage;
            await Task.Delay(1);
        }
        #endregion

    }
}
