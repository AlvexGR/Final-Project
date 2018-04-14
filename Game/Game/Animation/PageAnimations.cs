using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Game.Animation
{
    public static class PageAnimations
    {
        public static async Task SlideFromRight(this Page page, float seconds)
        {
            var sb = new Storyboard();

            sb.AddFadeIn(seconds * 2);

            sb.AddSlideFromRight(seconds * 2, page.WindowWidth);

            sb.Begin(page);

            page.Visibility = System.Windows.Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

        public static async Task SlideFromLeft(this Page page, float seconds)
        {
            var sb = new Storyboard();

            sb.AddFadeIn(seconds * 2);

            sb.AddSlideFromLeft(seconds * 2, page.WindowWidth);

            sb.Begin(page);

            page.Visibility = System.Windows.Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

        public static async Task SlideToLeft(this Page page, float seconds)
        {
            var sb = new Storyboard();

            sb.AddFadeOut(seconds);

            sb.AddSlideToLeft(seconds * 3, page.WindowWidth);
          
            sb.Begin(page);

            page.Visibility = System.Windows.Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

        public static async Task SlideToRight(this Page page, float seconds)
        {
            var sb = new Storyboard();

            sb.AddFadeOut(seconds);

            sb.AddSlideToRight(seconds * 3, page.WindowWidth);

            sb.Begin(page);

            page.Visibility = System.Windows.Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

    }
}
