// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;
using ObjCRuntime;
using CoreAnimation;
using Metal;
using CoreGraphics;

namespace MetalTexturedQuad
{
	public partial class ImageView : UIView
	{
		[Export ("layerClass")]
		public static Class LayerClass ()
		{
			return new Class (typeof(CAMetalLayer));
		}

		IMTLDevice device;
		MTLRenderPassDescriptor renderPassDescriptor;
		CAMetalLayer metalLayer;
		bool layerSizeDidUpdate;

		IMTLTexture depthTex;
		IMTLTexture stencilTex;
		IMTLTexture msaaTex;

		public MTLPixelFormat DepthPixelFormat { get; set; }

		public MTLPixelFormat StencilPixelFormat { get; set; }

		public nuint SampleCount { get; set; }

		public Renderer Renderer { get; set; }

		public override nfloat ContentScaleFactor {
			get {
				return base.ContentScaleFactor;
			}
			set {
				base.ContentScaleFactor = value;
				layerSizeDidUpdate = true;
			}
		}

		public ImageView (IntPtr handle) : base (handle)
		{
			Opaque = true;
			BackgroundColor = UIColor.Clear;

			metalLayer = (CAMetalLayer)Layer;

			device = MTLDevice.SystemDefault;

			metalLayer.Device = device;
			metalLayer.PixelFormat = MTLPixelFormat.BGRA8Unorm;
			metalLayer.FramebufferOnly = true;
		}

		public ICAMetalDrawable GetNextDrawable ()
		{
			ICAMetalDrawable currentDrawable = null;

			currentDrawable = metalLayer.NextDrawable ();
			if (currentDrawable == null)
				Console.WriteLine ("CurrentDrawable is null");

			return currentDrawable;
		}

		public void Display ()
		{
			if (layerSizeDidUpdate) {
				CGSize drawableSize = Bounds.Size;
				drawableSize.Width *= ContentScaleFactor;
				drawableSize.Height *= ContentScaleFactor;
				metalLayer.DrawableSize = drawableSize;
				Renderer.Reshape (this);
				layerSizeDidUpdate = false;
			}

			Renderer.Render (this);
		}

		public MTLRenderPassDescriptor GetRenderPassDescriptor (ICAMetalDrawable drawable)
		{
			if (drawable == null) {
				Console.WriteLine ("ERROR: Failed to get a drawable!");
				renderPassDescriptor = null;
			} else {
				SetupRenderPassDescriptorForTexture (drawable.Texture);
			}
			return renderPassDescriptor;
		}

		public override void MovedToWindow ()
		{
			ContentScaleFactor = Window.Screen.NativeScale;
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			layerSizeDidUpdate = true;
		}

		void SetupRenderPassDescriptorForTexture (IMTLTexture texture)
		{
			if (renderPassDescriptor == null)
				renderPassDescriptor = new MTLRenderPassDescriptor ();

			MTLRenderPassColorAttachmentDescriptor colorAttachment = renderPassDescriptor.ColorAttachments [0];
			colorAttachment.Texture = texture;
			colorAttachment.LoadAction = MTLLoadAction.Clear;
			colorAttachment.ClearColor = new MTLClearColor (0.65f, 0.65f, 0.65f, 1.0f);

			if (SampleCount > 1) {
				if (msaaTex == null || NeedUpdate (texture, msaaTex)) {
					var desc = MTLTextureDescriptor.CreateTexture2DDescriptor (MTLPixelFormat.BGRA8Unorm, texture.Width, texture.Height, false);
					desc.TextureType = MTLTextureType.k2DMultisample;
					desc.SampleCount = SampleCount;
					msaaTex = device.CreateTexture (desc);
				}

				colorAttachment.Texture = msaaTex;
				colorAttachment.ResolveTexture = texture;

				// set store action to resolve in this case
				colorAttachment.StoreAction = MTLStoreAction.MultisampleResolve;
			} else {
				colorAttachment.StoreAction = MTLStoreAction.Store;
			}

			if (DepthPixelFormat != MTLPixelFormat.Invalid && (depthTex == null || NeedUpdate (texture, depthTex))) {
					var desc = MTLTextureDescriptor.CreateTexture2DDescriptor (DepthPixelFormat, texture.Width, texture.Height, false);
					desc.TextureType = (SampleCount > 1) ? MTLTextureType.k2DMultisample : MTLTextureType.k2D;
					desc.SampleCount = SampleCount;
					depthTex = device.CreateTexture (desc);

					MTLRenderPassDepthAttachmentDescriptor depthAttachment = renderPassDescriptor.DepthAttachment;
					depthAttachment.Texture = depthTex;
					depthAttachment.LoadAction = MTLLoadAction.Clear;
					depthAttachment.StoreAction = MTLStoreAction.DontCare;
					depthAttachment.ClearDepth = 1.0;
			}

			if (StencilPixelFormat != MTLPixelFormat.Invalid && (stencilTex == null || NeedUpdate (texture, stencilTex))) {
					var desc = MTLTextureDescriptor.CreateTexture2DDescriptor (StencilPixelFormat, texture.Width, texture.Height, false);
					desc.TextureType = (SampleCount > 1) ? MTLTextureType.k2DMultisample : MTLTextureType.k2D;
					desc.SampleCount = SampleCount;
					stencilTex = device.CreateTexture (desc);

					MTLRenderPassStencilAttachmentDescriptor stencilAttachment = renderPassDescriptor.StencilAttachment;
					stencilAttachment.Texture = stencilTex;
					stencilAttachment.LoadAction = MTLLoadAction.Clear;
					stencilAttachment.StoreAction = MTLStoreAction.DontCare;
					stencilAttachment.ClearStencil = 0;
			}
		}

		bool NeedUpdate (IMTLTexture texture, IMTLTexture textureToCompare)
		{
			bool doUpdate = false;
			doUpdate = (textureToCompare.Width != texture.Width) || (textureToCompare.Height != texture.Height) || (textureToCompare.SampleCount != SampleCount);

			return doUpdate;
		}
	}
}
