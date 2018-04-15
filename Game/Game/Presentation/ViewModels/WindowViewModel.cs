using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Game.Presentation
{
    public class WindowViewModel : BaseViewModel
    {
        #region Private properties
        private Window myWindow;

        private int myOutterMarginSize = 10;
        #endregion

        #region Public properties
        public int ResizeBorder { get; set; } = 6;

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + myOutterMarginSize); } }

        public Thickness InnerContentPadding { get; set; } = new Thickness(0);

        public int TitleHeight { get; set; } = 30;
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        public AppPage.AppPage CurrentPage { set; get; } = AppPage.AppPage.MainPage;

        #endregion

        #region Constructor
        public WindowViewModel(Window window)
        {
            myWindow = window;

            myWindow.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
            };

            MinimizeWindow = new RelayCommand(() => myWindow.WindowState = WindowState.Minimized);
            CloseWindow = new RelayCommand(() => myWindow.Close());
        }
        #endregion

        #region Commands
        public ICommand MinimizeWindow { set; get; }
        public ICommand CloseWindow { set; get; }
        #endregion

    }
}
