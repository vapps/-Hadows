using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Hadows.Component
{
	public sealed partial class WebBrowser : UserControl, IComponent
	{
		public WebBrowser()
		{
			this.InitializeComponent();
			ThumbnailName = "thumbnail webbrowser";
			DisplayName = "displayname webbrowser";
			SnappedStateHeight = 800;

			LinkEvents();
		}

		private void LinkEvents()
		{
			GoButton.Click += GoButton_Click;
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
