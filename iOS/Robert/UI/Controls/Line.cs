using System;
using UIKit;
using System.Drawing;
using CoreGraphics;

namespace PlejdTest.iOS.Robert.UI.Controls
{
	public class Line:UIView
	{
		public UIColor Color { get; set;}			

		public Line ()
		{
			Color = UIColor.Green;
			BackgroundColor = UIColor.FromWhiteAlpha (0, 0);
			Opaque = false;
		}

		public override void Draw (CoreGraphics.CGRect rect)
		{
			base.Draw (rect);
			var inset = rect.Height / 3;
			UIBezierPath path = UIBezierPath.FromRoundedRect (rect.Inset(inset, inset), 3);
			Color.SetFill ();
			path.Fill ();
		}
	}
}

