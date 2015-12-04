using System;
using Xamarin.Forms;

namespace PlejdTest.Robert
{
	public class RobertRangeSlider:BoxView, IRangeSlider
	{
		public event EventHandler<ValueChangedEventArgs> MaximumValueChanged;
		public event EventHandler<ValueChangedEventArgs> MinimumValueChanged;

		public Color KnobColor { get; set;} = Color.Black;
		public Color KnobBorder { get; set;} = Color.Blue;
		public Color RailColor { get; set;} = Color.Gray;
		public Color TraceColor { get; set;} = Color.Lime;

		public double SelectedMaximumValue {
			get {				
				return Convert.ToDouble (SelectedMaximum);
			}
			set {
				SelectedMaximum =  (float)value;
			}
		}
		public double SelectedMinimumValue {
			get {
				return Convert.ToDouble (SelectedMinimum);
			}
			set {
				SelectedMinimum = (float)value;
			}
		}

		public static readonly BindableProperty MinimumProperty  = BindableProperty.Create<RobertRangeSlider, float>(prop => prop.Minimum, 
			default(float), BindingMode.TwoWay);

		public float Minimum {
			get{ return (float)GetValue (MinimumProperty);}
			set{ SetValue (MinimumProperty, value);}
		}

		double IRangeSlider.Minimum {
			get{ return Convert.ToDouble (Minimum);}
			set{ Minimum = (float)value;}
		}

		public static readonly BindableProperty SelectedMinimumProperty  = BindableProperty.Create<RobertRangeSlider, float>(prop => prop.SelectedMinimum, 
			default(float), BindingMode.TwoWay);

		public float SelectedMinimum {
			get{ return (float)GetValue (SelectedMinimumProperty);}
			set{
				var oldValue = SelectedMinimum;
				SetValue (SelectedMinimumProperty, value);
				if (MinimumValueChanged != null)
					MinimumValueChanged (this, new ValueChangedEventArgs (oldValue, value));
			}
		}

		public static readonly BindableProperty MaximumProperty  = BindableProperty.Create<RobertRangeSlider, float>(prop => prop.Maximum, default(float));

		public float Maximum {
			get{ return (float)GetValue (MaximumProperty);}
			set{ SetValue (MaximumProperty, value);}
		}

		double IRangeSlider.Maximum {
			get{ return Convert.ToDouble (Maximum);}
			set{ Maximum = (float)value;}
		}

		public static readonly BindableProperty SelectedMaximumProperty  = BindableProperty.Create<RobertRangeSlider, float>(prop => prop.SelectedMaximum, default(float));

		public float SelectedMaximum {
			get{ return (float)GetValue (SelectedMaximumProperty);}
			set{ 
				var oldValue = SelectedMaximum;
				SetValue (SelectedMaximumProperty, value);

				if (MaximumValueChanged != null)
					MaximumValueChanged (this, new ValueChangedEventArgs (oldValue, value));
			}
		}
	}
}


