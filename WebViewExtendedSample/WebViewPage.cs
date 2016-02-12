using System;
using Xamarin.Forms;

namespace WebViewExtendedSample
{
	public class WebViewPage : ContentPage
	{
		public WebViewPage ()
		{
			this.SizeChanged += WebViewPage_SizeChanged;
		}

		void WebViewPage_SizeChanged (object sender, EventArgs e)
		{
			Layout ();
		}

		WebViewExtended webView { get; set;}
		public void Layout()
		{
			var webView = new WebViewExtended ();
			webView.Source = "https://xamarin.com";
			webView.ControlWidth = this.Width;
			webView.ControlHeight = this.Height;
			webView.VerticalOptions = LayoutOptions.FillAndExpand;
			webView.HorizontalOptions = LayoutOptions.FillAndExpand;
			Content = webView;
		}
	}
}

