using System;
using Xamarin.Forms;

namespace WebViewExtendedSample
{
	public class WebViewExtended : ContentView
	{
		public WebViewExtended ()
		{
		}

		private static readonly BindableProperty SourceProperty =
			BindableProperty.Create<WebViewExtended, string> ( p=>p.Source, string.Empty);

		/// <summary>
		/// Gets or sets the source.
		/// </summary>
		/// <value>The source.</value>
		public string Source { 
			get { return (string)GetValue (SourceProperty); }
			set { SetValue (SourceProperty, value); }
		}

		private static readonly BindableProperty ControlWidthProperty =
			BindableProperty.Create<WebViewExtended, double> ( p=>p.ControlWidth, 0);

		/// <summary>
		/// Gets or sets the width of the control.
		/// </summary>
		/// <value>The width of the control.</value>
		public double ControlWidth { 
			get { return (double)GetValue (ControlWidthProperty); }
			set { SetValue (ControlWidthProperty, value); }
		}

		private static readonly BindableProperty ControlHeightProperty =
			BindableProperty.Create<WebViewExtended, double> ( p=>p.ControlHeight, 0);

		/// <summary>
		/// Gets or sets the height of the control.
		/// </summary>
		/// <value>The height of the control.</value>
		public double ControlHeight { 
			get { return (double)GetValue (ControlHeightProperty); }
			set { SetValue (ControlHeightProperty, value); }
		}

		private static readonly BindableProperty LoadPageFinishedProperty =
			BindableProperty.Create<WebViewExtended, bool> ( p=>p.LoadPageFinished, false);

		/// <summary>
		/// Gets or sets a value indicating if load page finished.
		/// </summary>
		/// <value><c>true</c> if load page finished; otherwise, <c>false</c>.</value>
		public bool LoadPageFinished { 
			get { return (bool)GetValue (LoadPageFinishedProperty); }
			set { SetValue (LoadPageFinishedProperty, value); }
		}

		private static readonly BindableProperty LoadPageStartedProperty =
			BindableProperty.Create<WebViewExtended, bool> ( p=>p.LoadPageStarted, false);

		/// <summary>
		/// Gets or sets a value indicating if load page started.
		/// </summary>
		/// <value><c>true</c> if load page started; otherwise, <c>false</c>.</value>
		public bool LoadPageStarted { 
			get { return (bool)GetValue (LoadPageStartedProperty); }
			set { SetValue (LoadPageStartedProperty, value); }
		}

		private static readonly BindableProperty LoadPageFailedProperty =
			BindableProperty.Create<WebViewExtended, bool> ( p=>p.LoadPageFailed, false);


		/// <summary>
		/// Gets or sets a value indicating if load page failed.
		/// </summary>
		/// <value><c>true</c> if load page failed; otherwise, <c>false</c>.</value>
		public bool LoadPageFailed { 
			get { return (bool)GetValue (LoadPageFailedProperty); }
			set { SetValue (LoadPageFailedProperty, value); }
		}

		/// <summary>
		/// Occurs when on load completed.
		/// </summary>
		public event EventHandler OnLoadCompleted;
		public void LoadCompleted(object sender, EventArgs e)
		{
			if (OnLoadCompleted != null) {
				OnLoadCompleted (sender,e);
			}
		}

		/// <summary>
		/// Occurs when on load started.
		/// </summary>
		public event EventHandler OnLoadStarted;
		public void LoadStarted(object sender, EventArgs e)
		{
			if (OnLoadStarted != null) {
				OnLoadStarted (sender,e);
			}
		}

		/// <summary>
		/// Occurs when on load failed.
		/// </summary>
		public event EventHandler OnLoadFailed;
		public void LoadFailed(object sender, EventArgs e)
		{
			if (OnLoadFailed != null) {
				OnLoadFailed (sender,e);
			}
		}
	}
}

