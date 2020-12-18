using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WPF_CaliburnMicro_MVVM.Infrastructure
{
    public static class DialogService
    {
        public static void ShowDialog(MetroWindow window, string message, MessageDialogStyle dialogStyle, string dialogTitle = null, string affirmativeButtonText = null)
        {
            window.MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;
            window.MetroDialogOptions.AffirmativeButtonText = !string.IsNullOrEmpty(affirmativeButtonText) ? affirmativeButtonText : "OK";
            window.ShowDialog();
        }
    }
}
