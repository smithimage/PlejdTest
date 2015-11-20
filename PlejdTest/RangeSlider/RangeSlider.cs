/*
 * Copyright 2015, Plejd AB. All Rights Reserved.
 * 
 * All information contained herein is the property of Plejd AB.
 * Reproduction of this material is strictly forbidden unless prior
 * written permission is obtained from Plejd AB.
 */

using System;
using System.ComponentModel;

namespace PlejdTest
{
    public class RangeSlider : INotifyPropertyChanged
    {
        #region Properties implementation

        public double Maximum { 
            get{ return _Maximum; } 
            set{
                if(_Maximum != value){
                    _Maximum = value;
                    OnPropertyChanged("Maximum");
                }
            }
        } double _Maximum;

        public double Minimum { 
            get{ return _Minimum; } 
            set{
                if(_Minimum != value){
                    _Minimum = value;
                    OnPropertyChanged("Minimum");
                }
            }
        } double _Minimum;

        public double SelectedMaximumValue { 
            get{ return _SelectedMaximumValue; } 
            set{
                if(_SelectedMaximumValue != value){
                    _SelectedMaximumValue = value;
                    OnPropertyChanged("SelectedMaximumValue");
                }
            }
        } double _SelectedMaximumValue;

        public double SelectedMinimumValue { 
            get{ return _SelectedMinimumValue; } 
            set{
                if(_SelectedMinimumValue != value){
                    _SelectedMinimumValue = value;
                    OnPropertyChanged("SelectedMinimumValue");
                }
            }
        } double _SelectedMinimumValue;

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public static RangeSlider DefaultRangeSlider(){
            return new RangeSlider
            {
                Maximum = 200,
                Minimum = 0,
                SelectedMaximumValue = 100,
                SelectedMinimumValue = 50
            };
        }

    }
}
