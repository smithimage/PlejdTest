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

			if (e.PropertyName == RobertRangeSlider.MaximumProperty.PropertyName) {								
				Control.Maximum = Element.Maximum;
			} else if (e.PropertyName == RobertRangeSlider.MinimumProperty.PropertyName) {
				Control.Minimum = Element.Minimum;
			} else if (e.PropertyName == RobertRangeSlider.SelectedMaximumProperty.PropertyName) {
				Control.SelectedMaximum = Element.SelectedMaximum;
			}else if (e.PropertyName == RobertRangeSlider.SelectedMinimumProperty.PropertyName) {
				Control.SelectedMinimum = Element.SelectedMinimum;
			}
		}
		
		private void OnControlChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{			
			var element = ((IElementController)Element);
			if (e.PropertyName == RobertRangeSlider.MaximumProperty.PropertyName) {				
				Element.Maximum = (float)Control.Maximum;
			} else if (e.PropertyName == RobertRangeSlider.MinimumProperty.PropertyName) {
				Element.Minimum = (float)Control.Minimum;
			} else if (e.PropertyName == RobertRangeSlider.SelectedMaximumProperty.PropertyName) {
				Element.SelectedMaximum = (float)Control.SelectedMaximum;
			}else if (e.PropertyName == RobertRangeSlider.SelectedMinimumProperty.PropertyName) {
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

