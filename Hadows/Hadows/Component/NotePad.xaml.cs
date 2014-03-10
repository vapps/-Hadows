using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Hadows.Component
{
	public sealed partial class NotePad : UserControl, IComponent
	{
		public NotePad()
		{
			this.InitializeComponent();
			ThumbnailName = "thumbnail notepad";
			DisplayName = "notepad";
			SnappedStateHeight = 700;
		}

		public string ThumbnailName { get; set; }
		public string DisplayName { get; set; }
		public double SnappedStateHeight { get; set; }

		public FrameworkElement GetInstance()
		{
			return new NotePad();
		}
	}
}
