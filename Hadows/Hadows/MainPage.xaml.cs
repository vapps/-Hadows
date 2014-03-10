using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Hadows.Component;
using Hadows.MyWindow;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Hadows
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();
			LinkEvents();
		}

		private void LinkEvents()
		{
			WidowsButton.Click += WidowsButton_Click;
		}

		void WidowsButton_Click(object sender, RoutedEventArgs e)
		{
			this.Content = new WindowsPage001();
		}

		void WebButton_Click(object sender, RoutedEventArgs e)
		{
			this.Content = new WebBrowser();
		}

		void AudioPlayerButton_Click(object sender, RoutedEventArgs e)
		{
			this.Content = new AudioPlayer();
		}

		void Windows002Button_Click(object sender, RoutedEventArgs e)
		{
			this.Content = new WindowsPage001();
		}

		void VideoPlayerButton_Click(object sender, RoutedEventArgs e)
		{
			this.Content = new VideoPlayer();
		}
	}
}
