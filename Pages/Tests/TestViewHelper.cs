using System;
using Telerik.Blazor.Components.DatePicker;
using Telerik.Blazor.Components.TabStrip;
using Syncfusion.EJ2.RazorComponents.Calendars;
using Syncfusion.EJ2.RazorComponents.Inputs;

namespace BlazorTests.Pages.Tests
{
    public class TestViewHelper
    {
        public void TestTelerik()
        {
            TelerikTab tab = new TelerikTab();
            TelerikDatePicker datePicker = new TelerikDatePicker();
            //datePicker.ValueChanged
        }

        public void TestSyncfusion()
        {
            EjsDatePicker datePicker = new EjsDatePicker();
            //datePicker.Change

            EjsTextBox textBox = new EjsTextBox();
            textBox.Change = (Syncfusion.EJ2.RazorComponents.Inputs.ChangedEventArgs args) => { };
        }
    }
}
