using System;
using Microsoft.Maui.Controls;

namespace BMI_Calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            // Get user input
            bool isHeightValid = double.TryParse(HeightEntry.Text, out double height);
            bool isWeightValid = double.TryParse(WeightEntry.Text, out double weight);

            if (!isHeightValid || !isWeightValid || height <= 0 || weight <= 0)
            {
                ResultLabel.Text = "Please enter valid height and weight!";
                return;
            }

            // Calculate BMI
            double bmi = weight / (height * height);
            string category = GetBMICategory(bmi);

            // Display result
            ResultLabel.Text = $"Your BMI: {bmi:F2}\nCategory: {category}";
        }

        private string GetBMICategory(double bmi)
        {
            if (bmi < 18.5)
                return "Underweight";
            else if (bmi < 24.9)
                return "Normal weight";
            else if (bmi < 29.9)
                return "Overweight";
            else
                return "Obese";
        }
    }
}