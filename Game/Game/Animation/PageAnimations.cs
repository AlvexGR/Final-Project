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

            sb.AddSlideFromRight(seconds * 2, page.WindowWidth);

            sb.AddFadeIn(seconds * 4);

            sb.Begin(page);

            page.Visibility = System.Windows.Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

        public static async Task SlideToLeft(this Page page, float seconds)
        {
            var sb = new Storyboard();

            sb.AddSlideToLeft(seconds * 3, page.WindowWidth);

            sb.AddFadeOut(seconds);

            sb.Begin(page);

            page.Visibility = System.Windows.Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

    }
}
