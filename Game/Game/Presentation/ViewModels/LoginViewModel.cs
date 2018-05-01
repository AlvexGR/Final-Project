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
    public class LoginViewModel : BaseViewModel
    {
        
        #region Public Properties
        public ICommand MainCommand { set; get; }
        public ICommand RegisterCommand { set; get; }
        #endregion

        #region Constructor
        public LoginViewModel()
        {
            MainCommand = new RelayCommand(async() => await GoToMain());
            RegisterCommand = new RelayCommand(async() => await GoToRegister());
        }
        #endregion

        #region Async Methods
        public async Task GoToMain()
        {
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPage.AppPage.MainPage;
            await Task.Delay(1);
        }

        public async Task GoToRegister()
        {
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPage.AppPage.RegisterPage;
            await Task.Delay(1);
        }
        #endregion
    }
}
