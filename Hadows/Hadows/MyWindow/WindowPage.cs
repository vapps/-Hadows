using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hadows.Control;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Hadows.MyWindow
{
	public class WindowPage : Page
	{
		//-------------------------- ▶ Constants
		private const double _FULL_SIZE_VIEW_MIN_WIDTH = 501;


		//-------------------------- ▶ Members
		StackPanel _snappedSizePanel;
		Grid _fullSizePanel;
		bool _isFullSizeMode;
		bool _isLoadedItem;



		//-------------------------- ▶ Constructors
		public WindowPage()
		{
			_Init();
			_LinkEvents();
		}



		//-------------------------- ▶ Methods
		void _LinkEvents()
		{
			this.Loaded += WindowPage_Loaded;
			this.SizeChanged += WindowPage_SizeChanged;
		}

		void _Init()
		{
			_isLoadedItem = false;
		}

		//-------------------------- ▶ EventHandlers
		void WindowPage_SizeChanged(object sender, Windows.UI.Xaml.SizeChangedEventArgs e)
		{
			if (_isLoadedItem == false)
				return;


			if (this.ActualWidth < _FULL_SIZE_VIEW_MIN_WIDTH &&
				this._isFullSizeMode == true)
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
						temp.Height = 0;
					}

					_snappedSizePanel.Children.Insert(0, temp);
				}
				VisualStateManager.GoToState(this, "SnappedSizeState", false);
				this._isFullSizeMode = false;
			}
			else if (this.ActualWidth > _FULL_SIZE_VIEW_MIN_WIDTH &&
				this._isFullSizeMode == false)
			{
				for (int i = _snappedSizePanel.Children.Count - 1; i >= 0; i--)
				{
					dynamic temp = _snappedSizePanel.Children[i];
					temp.Height = double.NaN;
					_snappedSizePanel.Children.RemoveAt(i);
					_fullSizePanel.Children.Add(temp);
				}
				VisualStateManager.GoToState(this, "FullSizeState", false);
				this._isFullSizeMode = true;
			}
		}

		void WindowPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
		{
			_fullSizePanel = (this.Content as Panel).Children[0] as Grid;
			_snappedSizePanel = ((this.Content as Panel).Children[1] as ScrollViewer).Content as StackPanel;
			_isFullSizeMode = true;
			Debug.Assert(_snappedSizePanel != null);
			Debug.Assert(_fullSizePanel != null);
			_isLoadedItem = true;
		}

	}
}
