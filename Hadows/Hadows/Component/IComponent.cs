using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Hadows.Component
{
	public interface IComponent
	{
		string ThumbnailName { get; set; }
		string DisplayName { get; set; }
		FrameworkElement GetInstance();
		double SnappedStateHeight { get; set; }
	}
}
