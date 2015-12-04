using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using PlejdTest.iOS.Robert.UI.Renderer;
using PlejdTest.iOS.Robert.UI.Controls;
using PlejdTest.Robert;

[assembly: ExportRenderer (typeof(RobertRangeSlider), typeof(NativeiOSRangeSliderRenderer))]
namespace PlejdTest.iOS.Robert.UI.Renderer
{
	public class NativeiOSRangeSliderRenderer:ViewRenderer<RobertRangeSlider, iOSRangeSlider>
	{
		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			//var element = ((IElementController)Element);
			if (e.PropertyName == RobertRangeSlider.MaximumProperty.PropertyName) {								
				//element.SetValueFromRenderer (RobertRangeSlider.MaximumProperty, Element.Maximum);
				Control.Maximum = Element.Maximum;
			} else if (e.PropertyName == RobertRangeSlider.MinimumProperty.PropertyName) {
				//element.SetValueFromRenderer (RobertRangeSlider.MinimumProperty, Element.Minimum);
				Control.Minimum = Element.Minimum;
			} else if (e.PropertyName == RobertRangeSlider.SelectedMaximumProperty.PropertyName) {
				//element.SetValueFromRenderer (RobertRangeSlider.SelectedMaximumProperty, Element.SelectedMaximum);
				Control.SelectedMaximum = Element.SelectedMaximum;
			}else if (e.PropertyName == RobertRangeSlider.SelectedMinimumProperty.PropertyName) {
				//element.SetValueFromRenderer (RobertRangeSlider.SelectedMinimumProperty, Element.SelectedMinimum);
				Control.SelectedMinimum = Element.SelectedMinimum;
			}
		}
		
		private void OnControlChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{			
			var element = ((IElementController)Element);
			if (e.PropertyName == RobertRangeSlider.MaximumProperty.PropertyName) {				
				//element.SetValueFromRenderer (RobertRangeSlider.MinimumProperty, Control.Minimum);
				Element.Maximum = (float)Control.Maximum;
			} else if (e.PropertyName == RobertRangeSlider.MinimumProperty.PropertyName) {
				//element.SetValueFromRenderer (RobertRangeSlider.MinimumProperty, Control.Minimum);
				Element.Minimum = (float)Control.Minimum;
			} else if (e.PropertyName == RobertRangeSlider.SelectedMaximumProperty.PropertyName) {
				//element.SetValueFromRenderer (RobertRangeSlider.SelectedMaximumProperty, Control.SelectedMaximum);
				Element.SelectedMaximum = (float)Control.SelectedMaximum;
			}else if (e.PropertyName == RobertRangeSlider.SelectedMinimumProperty.PropertyName) {
				//element.SetValueFromRenderer (RobertRangeSlider.SelectedMinimumProperty, Control.SelectedMinimum);
				Element.SelectedMinimum = (float)Control.SelectedMinimum;
			}
		}

		protected override void OnElementChanged (ElementChangedEventArgs<RobertRangeSlider> e)
		{			
			
			base.OnElementChanged (e);

			if (e.OldElement != null || this.Element == null)
				return;
			
			var slider = new iOSRangeSlider {
				Maximum = Element.Maximum,
				Minimum = Element.Minimum,
				SelectedMaximum = Element.SelectedMaximum,
				SelectedMinimum = Element.SelectedMinimum,
				RailColor = Element.RailColor,
				TraceColor = Element.TraceColor,
				KnobColor = Element.KnobColor,
				KnobBorder = Element.KnobBorder
			};

			slider.PropertyChanged += OnControlChanged;


			SetNativeControl (slider);
		}
	}
}

