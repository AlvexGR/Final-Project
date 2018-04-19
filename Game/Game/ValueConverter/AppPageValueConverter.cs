using System;
using System.Diagnostics;
using System.Globalization;
using Game.Presentation.Pages;
namespace Game
{
    public class AppPageValueConverter : BaseValueConverter<AppPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((AppPage.AppPage)value)
            {
                case AppPage.AppPage.MainPage:
                    return new Main();
                case AppPage.AppPage.NoThemeSelectionPage:
                    return new NoThemeSelection();
                case AppPage.AppPage.HistoryPage:
                    return new History();
                case AppPage.AppPage.SettingPage:
                    return new Setting();
                case AppPage.AppPage.ThemeSelectionPage:
                    return new ThemeSelection();
                case AppPage.AppPage.VocabularyListPage:
                    return new VocabularyList();
                case AppPage.AppPage.PlayOptionsPage:
                    return new PlayOptions();
                case AppPage.AppPage.WordSelectionPage:
                    return new WordSelection();
                case AppPage.AppPage.WordReviewPage:
                    return new WordReview();
                case AppPage.AppPage.SelectingWordOnListeningPage:
                    return new SelectingWordOnListening();
                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
