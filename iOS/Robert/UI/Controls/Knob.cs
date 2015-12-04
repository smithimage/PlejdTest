using System;
using UIKit;
using CoreGraphics;

namespace PlejdTest.iOS.Robert.UI.Controls
{
	public class Knob:UIView
	{
		public UIColor Color { get; set;}
		public UIColor Border { get; set;}

		private nfloat inset = 1;

		public Knob ()
		{
			Color = UIColor.Gray;
			Border = UIColor.LightGray;
			BackgroundColor = UIColor.FromWhiteAlpha (0, 0);
			Opaque = false;
		}

		public override void Draw (CoreGraphics.CGRect rect)
		{			
			base.Draw (rect);
			var outer = UIBezierPath.FromOval (rect.Inset(inset, inset));
			Color.SetFill ();
			outer.Fill ();
			Border.SetStroke ();
			outer.LineWidth = inset;
			outer.Stroke ();
		}
	}
}

