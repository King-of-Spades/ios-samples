// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace Example_Touch.Screens.iPhone.SimpleTouch {

	// Base type probably should be MonoTouch.UIKit.UIViewController or subclass
	[Foundation.Register("Touches_iPhone")]
	public partial class Touches_iPhone {

		private UIKit.UIView __mt_view;

		private UIKit.UIImageView __mt_imgDragMe;

		private UIKit.UIImageView __mt_imgTouchMe;

		private UIKit.UILabel __mt_lblTouchStatus;

		private UIKit.UIImageView __mt_imgTapMe;

		private UIKit.UILabel __mt_lblNumberOfFingers;

		#pragma warning disable 0169
		[Foundation.Connect("view")]
		private UIKit.UIView view {
			get {
				this.__mt_view = ((UIKit.UIView)(this.GetNativeField("view")));
				return this.__mt_view;
			}
			set {
				this.__mt_view = value;
				this.SetNativeField("view", value);
			}
		}

		[Foundation.Connect("imgDragMe")]
		private UIKit.UIImageView imgDragMe {
			get {
				this.__mt_imgDragMe = ((UIKit.UIImageView)(this.GetNativeField("imgDragMe")));
				return this.__mt_imgDragMe;
			}
			set {
				this.__mt_imgDragMe = value;
				this.SetNativeField("imgDragMe", value);
			}
		}

		[Foundation.Connect("imgTouchMe")]
		private UIKit.UIImageView imgTouchMe {
			get {
				this.__mt_imgTouchMe = ((UIKit.UIImageView)(this.GetNativeField("imgTouchMe")));
				return this.__mt_imgTouchMe;
			}
			set {
				this.__mt_imgTouchMe = value;
				this.SetNativeField("imgTouchMe", value);
			}
		}

		[Foundation.Connect("lblTouchStatus")]
		private UIKit.UILabel lblTouchStatus {
			get {
				this.__mt_lblTouchStatus = ((UIKit.UILabel)(this.GetNativeField("lblTouchStatus")));
				return this.__mt_lblTouchStatus;
			}
			set {
				this.__mt_lblTouchStatus = value;
				this.SetNativeField("lblTouchStatus", value);
			}
		}

		[Foundation.Connect("imgTapMe")]
		private UIKit.UIImageView imgTapMe {
			get {
				this.__mt_imgTapMe = ((UIKit.UIImageView)(this.GetNativeField("imgTapMe")));
				return this.__mt_imgTapMe;
			}
			set {
				this.__mt_imgTapMe = value;
				this.SetNativeField("imgTapMe", value);
			}
		}

		[Foundation.Connect("lblNumberOfFingers")]
		private UIKit.UILabel lblNumberOfFingers {
			get {
				this.__mt_lblNumberOfFingers = ((UIKit.UILabel)(this.GetNativeField("lblNumberOfFingers")));
				return this.__mt_lblNumberOfFingers;
			}
			set {
				this.__mt_lblNumberOfFingers = value;
				this.SetNativeField("lblNumberOfFingers", value);
			}
		}
	}
}
