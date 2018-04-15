using System.Windows;
using System.Windows.Controls;

namespace Game
{
    public class RemoveNavigationFrameHistory : BaseAttachedProperty<RemoveNavigationFrameHistory, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // get the frame
            var frame = (sender as Frame);

            // hidden the navigation bar
            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            // clear history
            frame.Navigated += (ss, ee) => ((Frame)ss).NavigationService.RemoveBackEntry();

        }
    }
}
