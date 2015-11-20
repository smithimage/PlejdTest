/*
 * Copyright 2015, Plejd AB. All Rights Reserved.
 * 
 * All information contained herein is the property of Plejd AB.
 * Reproduction of this material is strictly forbidden unless prior
 * written permission is obtained from Plejd AB.
 */

using System;
using Xamarin.Forms;

namespace PlejdTest
{
    public interface IRangeSlider
    {
        //
        // Properties
        //
        double Maximum { get; set; }
        double Minimum { get; set; }
        double SelectedMaximumValue { get; set; }
        double SelectedMinimumValue { get; set; }

        //
        // Events
        //
        event EventHandler<ValueChangedEventArgs> MaximumValueChanged;
        event EventHandler<ValueChangedEventArgs> MinimumValueChanged;
    }
}

