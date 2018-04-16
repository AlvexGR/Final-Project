using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Game.Presentation
{
    public class NoThemeSelectionViewModel : BaseViewModel
    {

        #region Public Properties

        public ICommand MainCommand { set; get; }

        #endregion

        #region Constructor
        public NoThemeSelectionViewModel()
        {
            MainCommand = new RelayCommand(async () => await GoToMain());
        }

        #endregion

        #region MyRegion
        private async Task GoToMain()
        {
            ((WindowViewModel)((MainWindow)System.Windows.Application.Current.MainWindow).DataContext).CurrentPage = AppPage.AppPage.MainPage;
            await Task.Delay(1);
        } 
        #endregion

    }
}
