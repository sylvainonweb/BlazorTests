using System;
using Telerik.Blazor.Components.DatePicker;
using Telerik.Blazor.Components.TabStrip;
using Syncfusion.EJ2.Blazor.Calendars;
using Syncfusion.EJ2.Blazor.Inputs;

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
            textBox.ValueChange = (Syncfusion.EJ2.Blazor.Inputs.ChangedEventArgs args) => { };
        }
    }
}
