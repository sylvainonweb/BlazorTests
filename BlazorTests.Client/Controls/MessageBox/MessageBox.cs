

using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorTests.Client.Controls
{
    public class MessageBox
    {
        public static Task<bool> ShowDeletionConfirmation()
        {
            return JSRuntime.Current.InvokeAsync<bool>("showDeletionConfirmation", string.Empty);
        }

        public static Task<bool> ShowAlert(string message)
        {
            return JSRuntime.Current.InvokeAsync<bool>("showAlert", message);
        }
    }
}