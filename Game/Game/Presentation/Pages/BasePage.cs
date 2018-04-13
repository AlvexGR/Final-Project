using System.Windows.Controls;
using Game.Animation;
using System.Windows;
using System;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Game.Presentation.Pages
{
    public class BasePage: Page
    {
        #region Public Properties
        public PageAnimation PageLoadAnimation { set; get; } = PageAnimation.SlideFromRight;

        public PageAnimation PageUnloadAnimation { set; get; } = PageAnimation.SlideToLeft;

        public float SlideSeconds { set; get; } = 0.5f;
        #endregion

        public BasePage()
        {
            if(PageLoadAnimation != PageAnimation.None)
            {
                Visibility = Visibility.Collapsed;
            }

            Loaded += BasePage_Loaded;
        }

        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            await AnimateIn();
        }

        public async Task AnimateIn()
        {
            if (PageLoadAnimation == PageAnimation.None)
            {
                return;
            }
            switch(PageLoadAnimation)
            {
                case PageAnimation.SlideFromRight:
                    await this.SlideFromRight(SlideSeconds);
                    break;
            }
        }

        public async Task AnimateOut()
        {
            if (PageUnloadAnimation == PageAnimation.None)
            {
                return;
            }
            switch (PageUnloadAnimation)
            {
                case PageAnimation.SlideToLeft:
                    await this.SlideToLeft(SlideSeconds);
                    break;
            }
        }
    }
}
