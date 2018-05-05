using System.Windows.Controls;
using Game.Animation;
using System.Windows;
using System;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using Game.UserControls;
using System.Windows.Media;

namespace Game.Presentation.Pages
{
    public class BasePage : Page
    {
        #region Constructor
        public BasePage()
        {
            if (PageLoadAnimationFromRight != PageAnimation.None || PageLoadAnimationFromLeft != PageAnimation.None)
            {
                Visibility = Visibility.Collapsed;
            }

            Loaded += BasePage_Loaded;
        } 
        #endregion

        #region Public Properties
        public PageAnimation PageLoadAnimationFromRight { set; get; } = PageAnimation.SlideFromRight;

        public PageAnimation PageLoadAnimationFromLeft { set; get; } = PageAnimation.SlideFromLeft;

        public PageAnimation PageUnloadAnimationToLeft { set; get; } = PageAnimation.SlideToLeft;

        public PageAnimation PageUnloadAnimationToRight { set; get; } = PageAnimation.SlideToRight;

        public float SlideSeconds { set; get; } = 0.4f;

        public bool isLoadFromRight { set; get; }

        public bool isLoadBack { set; get; }

        public bool isUnloadToRight { set; get; }

        public bool isUnloadToLeft { set; get; }

        public bool firstTime { set; get; }
    
        #endregion

        #region Animations
        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            if(firstTime)
            {
                await AnimateInFromRight();
            }
            if(isLoadFromRight)
            {
                await AnimateInFromRight();
            }
            if(isLoadBack)
            {
                await AnimateInFromLeft();
            }
            if(isUnloadToRight)
            {
                await AnimateOutToRight();
            }
            if(isUnloadToLeft)
            {
                await AnimateOutToLeft();
            }
            isUnloadToLeft = isUnloadToRight = isLoadBack = isLoadFromRight = firstTime = false;
            if (GetNameOfObject.GetName(this.ToString()) == "Login" && GetData.didRegister)
            {
                (this as Login).tbxUserName.Text = GetData.currentUser.Username;
                (this as Login).tbxError.Text = "Đăng kí thành công";
                (this as Login).tbxError.Foreground = Brushes.Green;
                (this as Login).tbxError.Visibility = Visibility.Visible;
                (this as Login).tbxPassword.Focus();
                GetData.didRegister = false;
            }
            if (GetNameOfObject.GetName(this.ToString()) == "WordSet" && GetData.isLearned && GetData.isTheme)
            {
                (this as WordSet).LoadData();
            }
            if (GetNameOfObject.GetName(ToString()) == "PlayOptions" && GetData.isLearned && GetData.isTheme)
            {
                (this as PlayOptions).ChangeStudyStatus(true);
            }
        }

        public async Task AnimateInFromRight()
        {
            if (PageLoadAnimationFromRight == PageAnimation.None)
            {
                return;
            }
            switch (PageLoadAnimationFromRight)
            {
                case PageAnimation.SlideFromRight:
                    await this.SlideFromRight(SlideSeconds);
                    break;
            }
        }

        public async Task AnimateInFromLeft()
        {
            if (PageLoadAnimationFromLeft == PageAnimation.None)
            {
                return;
            }
            switch (PageLoadAnimationFromLeft)
            {
                case PageAnimation.SlideFromLeft:
                    await this.SlideFromLeft(SlideSeconds);
                    break;
            }
        }


        public async Task AnimateOutToLeft()
        {
            if (PageUnloadAnimationToLeft == PageAnimation.None)
            {
                return;
            }
            switch (PageUnloadAnimationToLeft)
            {
                case PageAnimation.SlideToLeft:
                    await this.SlideToLeft(SlideSeconds);
                    break;
            }
        }

        public async Task AnimateOutToRight()
        {
            if (PageUnloadAnimationToRight == PageAnimation.None)
            {
                return;
            }
            switch (PageUnloadAnimationToRight)
            {
                case PageAnimation.SlideToRight:
                    await this.SlideToRight(SlideSeconds);
                    break;
            }
        } 
        #endregion
    }

    public class BasePage<VM> : BasePage
        where VM: BaseViewModel, new()
    {
        #region Private Properties
        private VM myViewModel;
        #endregion

        #region Public Properties

        public VM MyViewModel
        {
            get => myViewModel;
            set
            {
                if(myViewModel == value)
                {
                    return;
                }

                myViewModel = value;
                DataContext = myViewModel;
            }
        }
        #endregion

        #region Constructor
        public BasePage()
        {
            DataContext = new VM();
        } 
        #endregion

    }
}
