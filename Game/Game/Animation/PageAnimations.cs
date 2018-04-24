using Game.Presentation;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Game.Animation
{
    public static class PageAnimations
    {
        public static async Task SlideFromRight(this Page page, float seconds)
        {
            var sb = new Storyboard();

            sb.AddFadeIn(seconds);

            sb.AddSlideFromRight(seconds, page.WindowWidth);

            sb.Begin(page);

            page.Visibility = System.Windows.Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

        public static async Task SlideFromLeft(this Page page, float seconds)
        {
            var sb = new Storyboard();

            sb.AddFadeIn(seconds);

            sb.AddSlideFromLeft(seconds, page.WindowWidth);

            sb.Begin(page);

            page.Visibility = System.Windows.Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

        public static async Task SlideToLeft(this Page page, float seconds)
        {
            var sb = new Storyboard();

            sb.AddFadeOut(seconds);

            sb.AddSlideToLeft(seconds, page.WindowWidth);
          
            sb.Begin(page);

            page.Visibility = System.Windows.Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

        public static async Task SlideToRight(this Page page, float seconds)
        {
            var sb = new Storyboard();

            sb.AddFadeOut(seconds);

            sb.AddSlideToRight(seconds, page.WindowWidth);

            sb.Begin(page);

            page.Visibility = System.Windows.Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

    }
}
