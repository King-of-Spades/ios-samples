// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace OpenGLESSampleGameView {

	// Base type probably should be MonoTouch.Foundation.NSObject or subclass
	[Foundation.Register("OpenGLESSampleAppDelegate")]
	public partial class OpenGLESSampleAppDelegate {

		private UIKit.UIWindow __mt_window;

		private EAGLView __mt_glView;

		#pragma warning disable 0169
		[Foundation.Connect("window")]
		private UIKit.UIWindow window {
			get {
				this.__mt_window = ((UIKit.UIWindow)(this.GetNativeField("window")));
				return this.__mt_window;
			}
			set {
				this.__mt_window = value;
				this.SetNativeField("window", value);
			}
		}

		[Foundation.Connect("glView")]
		private EAGLView glView {
			get {
				this.__mt_glView = ((EAGLView)(this.GetNativeField("glView")));
				return this.__mt_glView;
			}
			set {
				this.__mt_glView = value;
				this.SetNativeField("glView", value);
			}
		}
	}

	// Base type probably should be MonoTouch.UIKit.UIView or subclass
	[Foundation.Register("EAGLView")]
	public partial class EAGLView {
	}
}
