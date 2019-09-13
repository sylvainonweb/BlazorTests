using System;
using System.Timers;

namespace BlazorTests.Services
{
    /// <summary>
    /// L'utilisation des notifications Toast nécessitent :
    /// 
    /// * ajouter les classes ToastService, ToastBase.cs et Toast.razor
    /// 
    /// * ajouter le fichier toast.css dans wwwroot\css
    /// 
    /// * ajouter l'import du fichier toast.css dans site.css comme suit : @import url('toast.css');
    /// 
    /// * ajouter le code suivant dans MainLayout
    /// 
    ///    @using Neptune.Hyperviseur.Services.Technical.Toast
    /// 
    ///    <!-- Composant permettant d'afficher les notifications Toast -->
    ///    <Toast></Toast>
    /// 
    /// </summary>
    public class ToastService
    {
        public event Action<string, ToastLevel, string> OnShow;
        public event Action OnHide;
        private Timer Countdown;

        public void ShowToast(string message, ToastLevel level, string heading = null)
        {
            OnShow?.Invoke(message, level, heading);
            StartCountdown();
        }

        private void StartCountdown()
        {
            if (Countdown == null)
            {
                Countdown = new Timer(5000);
                Countdown.Elapsed += HideToast;
                Countdown.AutoReset = false;
            }

            Countdown.Stop();
            Countdown.Start();
        }

        private void HideToast(object source, ElapsedEventArgs args)
        {
            OnHide?.Invoke();
        }

        public void Dispose()
        {
            Countdown?.Dispose();
        }
    }

    public enum ToastLevel
    {
        Info,
        Success,
        Warning,
        Error
    }
}