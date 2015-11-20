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
    public class RangeSliderView : View, IRangeSlider 
    {
        //TODO
        //Implementer RangeSliderView. 
        //Slidern ska ha en knopp för selectedMinimum och en knopp för selectedMaximum.
        //Det är inget krav på att den ska vara implementerad i forms utan får gärna vara implementerad med renderers i
        //någon av platformarna Android eller iOS.
        //Lägg in den nya slider någonstans i TestPage eller ersätt den gamla.

        #region IRangeSlider implementation

        public event EventHandler<ValueChangedEventArgs> MaximumValueChanged;

        public event EventHandler<ValueChangedEventArgs> MinimumValueChanged;

        public double Maximum
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public double Minimum
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public double SelectedMaximumValue
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public double SelectedMinimumValue
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}

