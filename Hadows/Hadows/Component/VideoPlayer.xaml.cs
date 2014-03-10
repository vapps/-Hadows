using System;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Hadows.Component
{
	public sealed partial class VideoPlayer : UserControl, IComponent
	{
		public VideoPlayer()
		{
			this.InitializeComponent();


			LinkEvents();

			ThumbnailName = "bb.jpg";
			DisplayName = "VideoPlayer";
			SnappedStateHeight = 500;
		}

		private void LinkEvents()
		{
			PlayButton.Click += PlayButton_Click;
			OpenButton.Click += OpenButton_Click;
		}


		async void OpenButton_Click(object sender, RoutedEventArgs e)
		{
			FileOpenPicker fileOpenPicker = new FileOpenPicker();
			fileOpenPicker.ViewMode = PickerViewMode.Thumbnail;
			fileOpenPicker.FileTypeFilter.Add(".avi");
			fileOpenPicker.FileTypeFilter.Add(".wmv");
			fileOpenPicker.SuggestedStartLocation = PickerLocationId.VideosLibrary;

			var pickedFile = await fileOpenPicker.PickSingleFileAsync();
			if (pickedFile == null)
			{
				return;
			}

			var stream = await pickedFile.OpenAsync(FileAccessMode.Read);
			mediaElement.SetSource(stream, pickedFile.ContentType);
		}

		void PlayButton_Click(object sender, RoutedEventArgs e)
		{
			if (mediaElement.Source == null)
				return;

			mediaElement.Play();
		}


		public string ThumbnailName { get; set; }
		public string DisplayName { get; set; }
		public double SnappedStateHeight { get; set; }

		public FrameworkElement GetInstance()
		{
			return new VideoPlayer();
		}
	}
}
