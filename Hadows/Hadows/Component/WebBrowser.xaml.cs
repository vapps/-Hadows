using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Hadows.Component
{
	public sealed partial class WebBrowser : UserControl, IComponent
	{
		public WebBrowser()
		{
			this.InitializeComponent();
			ThumbnailName = "thumbnail webbrowser";
			DisplayName = "webbrowser";
			SnappedStateHeight = 800;

			LinkEvents();
		}

		private void LinkEvents()
		{
			GoButton.Click += GoButton_Click;
			UrlTextBox.KeyUp += UrlTextBox_KeyUp;
		}

		void UrlTextBox_KeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
		{
			if (e.Key == Windows.System.VirtualKey.Enter)
			{
				webView.Source = new Uri(UrlTextBox.Text);
			}
		}

		void GoButton_Click(object sender, RoutedEventArgs e)
		{
			webView.Source = new Uri(UrlTextBox.Text);
		}

		public string ThumbnailName { get; set; }
		public string DisplayName { get; set; }
		public double SnappedStateHeight { get; set; }

		public FrameworkElement GetInstance()
		{
			return new WebBrowser();
		}
	}
}
