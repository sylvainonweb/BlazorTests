using System;
using System.Timers;

namespace BlazorTests.Services
{
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
                Countdown = new Timer(2000);
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