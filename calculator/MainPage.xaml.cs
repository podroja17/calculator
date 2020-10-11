using Xamarin.Forms;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data;

namespace calculator
{
    public partial class MainPage : ContentPage
    {
        List<String> excluded = new List<string>() { "÷", "×", "-", "+", "." };

        public MainPage()
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                this.Padding = new Thickness(0, 20, 0, 0);
            }

            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            String buttonText = ((Button)sender).Text;

            if (buttonText == "=")
            {
                Calculate();
                return;
            }

            if (buttonText == "C")
            {
                Erase();
                return;
            }

            UpdateDisplay(buttonText);
        }

        void UpdateDisplay(string character)
        {
            if (display.Text == "0" && !excluded.Contains(character))
            {
                display.Text = character;
            } else {
                display.Text += character;
            }
            
        }

        void Calculate()
        {
            DataTable dt = new DataTable();
            try
            {
                display.Text = dt.Compute(display.Text.Replace('÷', '/').Replace('×', '*'), "").ToString();
            } catch (Exception e)
            {
                DisplayAlert("OOF", "Velký špatný" , "Odbouchnout");
            }
            
        }

        void Erase()
        {
            display.Text = "0";
        }
    }
}
