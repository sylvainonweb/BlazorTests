using System;
using Telerik.Blazor.Components;
using Syncfusion.EJ2.Blazor.Calendars;
using Syncfusion.EJ2.Blazor.Inputs;
using Telerik.Blazor.Components.Grid;

namespace BlazorTests.Pages.Tests
{
    public class TestViewHelper
    {
        public void TestTelerik()
        {
            //TelerikTab tab = new TelerikTab();
            //TelerikDatePicker datePicker = new TelerikDatePicker();
            //datePicker.ValueChanged
        }

        public void TestSyncfusion()
        {
            EjsDatePicker<DateTime?> datePicker = new EjsDatePicker<DateTime?>();
            //datePicker.Change

            EjsTextBox textBox = new EjsTextBox();
            //textBox.ValueChange = (Syncfusion.EJ2.Blazor.Inputs.ChangedEventArgs args) => { };
        }
    }
}
