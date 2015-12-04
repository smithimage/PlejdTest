/*
 * Copyright 2015, Plejd AB. All Rights Reserved.
 * 
 * All information contained herein is the property of Plejd AB.
 * Reproduction of this material is strictly forbidden unless prior
 * written permission is obtained from Plejd AB.
 */

using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PlejdTest
{
    public partial class TestPage : ContentPage
    {
        readonly RangeSlider rangeSlider;

        public TestPage()
        {
            InitializeComponent();

//            rangeSlider = RangeSlider.DefaultRangeSlider();
//            rangeSlider.PropertyChanged += (sender, e) => RegularSlider.Value = rangeSlider.SelectedMaximumValue; 
//
//            RegularSlider.Maximum = rangeSlider.Maximum;
//            RegularSlider.Minimum = rangeSlider.Minimum;
//            RegularSlider.Value = rangeSlider.SelectedMaximumValue;
//            RegularSlider.ValueChanged += (sender, e) => rangeSlider.SelectedMaximumValue = (int)RegularSlider.Value;
//
//            MinCurrentValue.BindingContext = rangeSlider;
//            MinCurrentValue.SetBinding(Label.TextProperty, "SelectedMinimumValue");
//
//            MinMinusButton.Clicked += (sender, e) => rangeSlider.SelectedMinimumValue--;
//            MinPlusButton.Clicked += (sender, e) => rangeSlider.SelectedMinimumValue++;
//
//            MaxCurrentValue.BindingContext = rangeSlider;
//            MaxCurrentValue.SetBinding(Label.TextProperty, "SelectedMaximumValue");
//
//            MaxMinusButton.Clicked += (sender, e) => rangeSlider.SelectedMaximumValue--;
//            MaxPlusButton.Clicked += (sender, e) => rangeSlider.SelectedMaximumValue++;
        }

		public void IncreaseMinimum(object sender, EventArgs e)
		{
			RobertSlider.SelectedMinimumValue++;
		}

		public void DecreaseMinimum(object sender, EventArgs e)
		{
			RobertSlider.SelectedMinimumValue--;
		}

		public void IncreaseMaximum(object sender, EventArgs e)
		{
			RobertSlider.SelectedMaximumValue++;
		}

		public void DecreaseMaximum(object sender, EventArgs e)
		{
			RobertSlider.SelectedMaximumValue--;
		}
    }
}

