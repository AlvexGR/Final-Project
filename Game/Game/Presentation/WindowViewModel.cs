using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Game.Presentation;

namespace Game.Presentation
{
    public class WindowViewModel : BaseViewModel
    {
        #region Private properties
        private Window myWindow;

        /// <summary>
        /// Margin around the window
        /// </summary>
        private int myOutterMarginSize = 10;
        /// <summary>
        /// Radius of the edges of the window
        /// </summary>
        private int myWindowRadius = 10;
        #endregion

        #region Public properties
        public int ResizeBorder { get; set; } = 6; //size of the resize border around the window

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        public int OuterMarginSize
        {
            get
            {
                return myWindow.WindowState == WindowState.Maximized ? 0 : myOutterMarginSize;
            }
            set
            {
                myOutterMarginSize = value;
            }
        }
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        public int WindowRadius
        {
            get
            {
                return myWindow.WindowState == WindowState.Maximized ? 0 : myWindowRadius;
            }
            set
            {
                myWindowRadius = value;
            }
        }
        public CornerRadius WindowCornerRaius { get { return new CornerRadius(WindowRadius); } }

        #endregion

        #region Constructor
        public WindowViewModel(Window window)
        {
            myWindow = window;

            myWindow.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRaius));
            };
        }
        #endregion

    }
}
