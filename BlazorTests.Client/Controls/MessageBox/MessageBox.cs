

using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorTests.Client.Controls
{
    public class MessageBox
    {
        public static Task<bool> ShowAlert(string message)
        {
            return JSRuntime.Current.InvokeAsync<bool>("exampleJsFunctions.showAlert", message);
        }
    }
}