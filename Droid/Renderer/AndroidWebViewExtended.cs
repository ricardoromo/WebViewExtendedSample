using System;
using Xamarin.Forms;
using Android.App;
using Xamarin.Forms.Platform.Android;
using WebViewExtendedSample.Droid;
using WebViewExtendedSample;
using Android.Widget;
using Android.Webkit;

[assembly : ExportRenderer(typeof(WebViewExtended),typeof(AndroidWebViewExtended))]
namespace WebViewExtendedSample.Droid 
{
	
	public class AndroidWebViewExtended : ViewRenderer<WebViewExtended, global::Android.Views.View>
	{
		static WebViewExtended CustomWebView { get; set;}
		static ProgressDialog ActiveIndicator { get; set;} 
		public AndroidWebViewExtended ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<WebViewExtended> e)
		{
			base.OnElementChanged (e);
			if (e.NewElement != null) {
				CustomWebView = (WebViewExtended)Element;
				LinearLayout contentView = new LinearLayout (Forms.Context);

				ActiveIndicator = new ProgressDialog(Forms.Context);
				ActiveIndicator.SetMessage ("Loading Page......");
				ActiveIndicator.SetProgressStyle (ProgressDialogStyle.Spinner);

				var webView = new  Android.Webkit.WebView (Forms.Context);
				webView.Settings.JavaScriptEnabled = true;
				webView.LoadUrl (CustomWebView.Source);
				webView.SetWebViewClient (new Callback());
				contentView.AddView(webView);
				SetNativeControl(contentView);
			}

		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			if (e.PropertyName == "LoadPageFinished") {
				CustomWebView.LoadCompleted (sender, e);
			}
			else if (e.PropertyName == "LoadPageStarted") {
				CustomWebView.LoadStarted (sender, e);
			}
			else if (e.PropertyName == "LoadPageFailed") {
				CustomWebView.LoadFailed (sender, e);
			}
		}

		private class Callback : WebViewClient {
			public override void OnPageFinished (Android.Webkit.WebView view, string url)
			{
				base.OnPageFinished (view, url);
				ActiveIndicator.Hide ();
				CustomWebView.LoadCompleted (this, new EventArgs ());
			}

			public override void OnPageStarted (Android.Webkit.WebView view, string url, Android.Graphics.Bitmap favicon)
			{
				base.OnPageStarted (view, url, favicon);
				ActiveIndicator.Show ();
				CustomWebView.LoadStarted (this, new EventArgs ());
			}

			public override void OnReceivedHttpError (Android.Webkit.WebView view, IWebResourceRequest request, WebResourceResponse errorResponse)
			{
				base.OnReceivedHttpError (view, request, errorResponse);
				CustomWebView.LoadFailed (this, new EventArgs ());

			}
		}
	}
}

