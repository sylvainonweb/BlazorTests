using Microsoft.AspNetCore.Blazor.Browser.Interop;

namespace BlazorTests.Client.Shared
{
    public class MessageBox
    {
        public static bool ShowDeletionConfirmation()
        {
            return RegisteredFunction.Invoke<bool>("showDeletionConfirmation", string.Empty);
        }

        public static bool ShowAlert(string message)
        {
            return RegisteredFunction.Invoke<bool>("showAlert", message);
        }
    }
}