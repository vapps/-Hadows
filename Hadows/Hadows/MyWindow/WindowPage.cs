using System.Diagnostics;
using Hadows.Control;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Hadows.MyWindow
{
	public class WindowPage : Page
	{
		//-------------------------- ▶ Constants
		private const double _FULL_SIZE_VIEW_MIN_WIDTH = 501;
		private const double _DEFAULT_MIN_HEIHGT = 400;


		//-------------------------- ▶ Members
		StackPanel _snappedSizePanel;
		Grid _fullSizePanel;
		bool _isLoadedItem = false;



		//-------------------------- ▶ Constructors
		public WindowPage()
		{
			_LinkEvents();
		}



		//-------------------------- ▶ Methods
		void _LinkEvents()
		{
			this.Loaded += WindowPage_Loaded;
			this.SizeChanged += WindowPage_SizeChanged;
		}


		//-------------------------- ▶ EventHandlers
		void WindowPage_SizeChanged(object sender, Windows.UI.Xaml.SizeChangedEventArgs e)
		{
			if (_isLoadedItem == false)
				return;


			if (this.ActualWidth < _FULL_SIZE_VIEW_MIN_WIDTH)
			{
				for (int i = _fullSizePanel.Children.Count - 1; i >= 0; i--)
				{
					ComponentContentControl temp = _fullSizePanel.Children[i] as ComponentContentControl;
					_fullSizePanel.Children.RemoveAt(i);

					if (temp == null)
					{
						Debug.Assert(false);
						continue;
					}

					temp.Height = temp.GetComponentSnappedHeight();
					if (double.IsNaN(temp.Height) == true)
					{
						temp.Height = _DEFAULT_MIN_HEIHGT;
					}

					_snappedSizePanel.Children.Insert(0, temp);
				}

				VisualStateManager.GoToState(this, "SnappedSizeState", false);
			}
			else
			{
				for (int i = _snappedSizePanel.Children.Count - 1; i >= 0; i--)
				{
					dynamic temp = _snappedSizePanel.Children[i];
					temp.Height = double.NaN;
					_snappedSizePanel.Children.RemoveAt(i);
					_fullSizePanel.Children.Add(temp);
				}

				VisualStateManager.GoToState(this, "FullSizeState", false);
			}
		}

		void WindowPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
		{
			_fullSizePanel = (this.Content as Panel).Children[0] as Grid;
			_snappedSizePanel = ((this.Content as Panel).Children[1] as ScrollViewer).Content as StackPanel;

			Debug.Assert(_snappedSizePanel != null);
			Debug.Assert(_fullSizePanel != null);

			_isLoadedItem = true;
		}

	}
}
