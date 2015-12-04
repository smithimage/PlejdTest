using System;
using UIKit;
using System.Drawing;
using Foundation;
using CoreGraphics;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace PlejdTest.iOS.Robert.UI.Controls
{
	public class iOSRangeSlider:UIControl
	{		
		private UIView lowerKnobView;
		private UIView upperKnobView;
		private UIView railView;
		private UIView traceView;

		nfloat selectedMinimum = 0;
		nfloat minimum = 0;
		nfloat maximum = 1;
		nfloat selectedMaximum = 0.5f;

		public Color KnobColor { get; set;} = Color.Black;
		public Color KnobBorder { get; set;} = Color.Blue;
		public Color RailColor { get; set;} = Color.Gray;
		public Color TraceColor { get; set;} = Color.Lime;

		public UIView TraceView {
			get {
				return traceView;
			}
			set {
				traceView = value;
			}
		}

		public UIView RailView {
			get {
				return railView;
			}
			set {
				railView = value;
			}
		}

		public UIView LowerKnobView {
			get {
				return lowerKnobView;
			}
			set {
				lowerKnobView = value;
				OnPropertyChanged ();
			}
		}

		public UIView UpperKnobView {
			get {
				return upperKnobView;
			}
			set {
				upperKnobView = value;
				OnPropertyChanged ();
			}
		}

		public nfloat Minimum {
			get {
				return minimum;
			}
			set {
				minimum = value;
				OnPropertyChanged ();
			}
		}

		public nfloat Maximum {
			get {
				return maximum;
			}
			set {
				maximum = value;
				OnPropertyChanged ();
			}
		}

		public nfloat SelectedMaximum {
			get {
				return selectedMaximum;
			}
			set {				
				selectedMaximum = ForceWithinRange(value);

				if (UpperKnobX  < (LowerKnobX + LowerKnobView?.Bounds.Width)) {
					SelectedMinimum = (RailRange / RailWidth) * (UpperKnobX - LowerKnobView.Bounds.Width);
				}

				OnPropertyChanged ();
				SetNeedsLayout ();
			}
		}

		public nfloat SelectedMinimum {
			get {
				return selectedMinimum;
			}
			set {								
				selectedMinimum = ForceWithinRange (value);			

				if ((LowerKnobX + (LowerKnobView?.Bounds.Width)) > (UpperKnobX)) {
					SelectedMaximum = (RailRange / RailWidth) * (LowerKnobX);
				}

				OnPropertyChanged ();
				SetNeedsLayout ();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged = null;

		nfloat ForceWithinRange (nfloat value)
		{			
			if (value < Minimum)
				value = Minimum;
			if (value > Maximum)
				value = Maximum;
			return value;
		}



		private nfloat LowerAvailableWidth{get{ return Bounds.Width - KnobWidth; }}

		private nfloat UpperAvailableWidth{get{ return Bounds.Width - KnobWidth; }}

		private nfloat VerticalCenter { get { return Bounds.Height / 2; } }

		nfloat LowerKnobX { get { return (nfloat)Math.Floor ((float)(SelectedMinimum - Minimum) / RailRange * LowerAvailableWidth); } }

		nfloat UpperKnobX { get { return (nfloat)Math.Floor ((nfloat)(SelectedMaximum - Minimum) / RailRange * UpperAvailableWidth) + KnobWidth; } }

		nfloat KnobWidth { get { return Bounds.Height; } }

		nfloat KnobHeight{ get { return KnobWidth; } }

		nfloat KnobInset { get { return KnobWidth / 2; } }

		nfloat RailThickness { get { return Bounds.Height / 32; } }

		nfloat TraceThickness { get { return Bounds.Height / 16; } }

		nfloat TraceWidth { get { return UpperKnobX - LowerKnobX; } }

		nfloat RailWidth { get { return Bounds.Width - KnobWidth; } }

		nfloat RailY { get	{ return Bounds.Height / 2 - (RailThickness / 2); }}

		nfloat TraceY { get	{ return Bounds.Height / 2 - (TraceThickness / 2); }}

		nfloat RailRange { get { return Maximum - Minimum; } }

		void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{			
			if (PropertyChanged != null)
				PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
		}

		void Initialize ()
		{	
			if(railView == null)
				railView = new Line {Color = RailColor.ToUIColor()};
			if(traceView == null)
				traceView = new Line{Color = TraceColor.ToUIColor()}; 
			if(LowerKnobView == null)
				lowerKnobView = new Knob{Color = KnobColor.ToUIColor(), Border = KnobBorder.ToUIColor()} ;
			if(upperKnobView == null)
				upperKnobView = new Knob{Color = KnobColor.ToUIColor(), Border = KnobBorder.ToUIColor()} ;

			if (Subviews.Length > 0)
				return;

			InitializeKnobFrames ();

			lowerKnobView.UserInteractionEnabled = true;
			lowerKnobView.ContentMode = UIViewContentMode.Center;
			BindGestures (lowerKnobView, HandleLowerPanGesture);

			upperKnobView.UserInteractionEnabled = true;
			upperKnobView.ContentMode = UIViewContentMode.Center;
			BindGestures (upperKnobView, HandleUpperPanGesture);

			AddSubview (railView);
			AddSubview (traceView);
			AddSubview (lowerKnobView);
			AddSubview (upperKnobView);
		}

		void InitializeKnobFrames ()
		{			
			if (lowerKnobView.Frame.Width <= 0 && upperKnobView.Frame.Width <= 0) {				
				lowerKnobView.Frame = new CGRect (LowerKnobX + KnobInset, VerticalCenter - Bounds.Height / 2, KnobWidth, KnobHeight);
				upperKnobView.Frame = new CGRect (UpperKnobX - KnobInset, VerticalCenter - Bounds.Height / 2, KnobWidth, KnobHeight);
			}
		}

		void BindGestures (UIView view, Action<UIPanGestureRecognizer> handler)
		{
			var gestureRecoqnizer = new UIPanGestureRecognizer ();
			gestureRecoqnizer.AddTarget (() => handler(gestureRecoqnizer));
			view.AddGestureRecognizer (gestureRecoqnizer);
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			Initialize ();
			railView.Frame = new CGRect (Bounds.X + KnobInset, RailY, RailWidth, RailThickness);
			traceView.Frame = new CGRect (LowerKnobX, TraceY, TraceWidth, TraceThickness);
			lowerKnobView.Center = new CGPoint (LowerKnobX, VerticalCenter);
			upperKnobView.Center = new CGPoint (UpperKnobX, VerticalCenter);
		}

		private void HandleLowerPanGesture(UIPanGestureRecognizer gesture)
		{
			HandlePanGesture (gesture, f => SelectedMinimum += f, lowerKnobView);
		}

		private void HandleUpperPanGesture(UIPanGestureRecognizer gesture)
		{
			HandlePanGesture (gesture, f => SelectedMaximum += f, upperKnobView);			
		}

		private void HandlePanGesture(UIPanGestureRecognizer gesture, Action<nfloat> setAction, UIView targetView)
		{
			
			if (gesture.State == UIGestureRecognizerState.Began || gesture.State == UIGestureRecognizerState.Changed) {
				BringSubviewToFront (targetView);

				var translation = gesture.TranslationInView (this);
				var width = Frame.Width - targetView.Frame.Width;
				setAction(translation.X / width * RailRange);
				gesture.SetTranslation (new CGPoint(0,0), this);
				SendActionForControlEvents(UIControlEvent.ValueChanged);
			}
		}
	}
}

