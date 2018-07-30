

using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorTests.Client.Controls
{
    public class MessageBox
    {
        public static Task<string> ShowAlert(string message)
        {
            return JSRuntime.Current.InvokeAsync<string>(
                "JavascriptFunctions.showAlert",
                message);
        }
    }
}