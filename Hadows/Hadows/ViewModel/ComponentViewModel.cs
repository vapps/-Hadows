using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Hadows.Component;

namespace Hadows.ViewModel
{
	public class ComponentViewModel : ViewModelBase
	{
		#region ObservableCollection<IComponent> Components
		private ObservableCollection<IComponent> _components;
		public ObservableCollection<IComponent> Components
		{
			get
			{
				return _components;
			}
			set
			{
				_components = value;
				RaisePropertyChanged("Components");
			}
		}
		#endregion ObservableCollection<IComponent> Components

		public ComponentViewModel()
		{
			Components = new ObservableCollection<IComponent>();
			RegistryComponents();
		}

		private void RegistryComponents()
		{
			Components.Add(new AudioPlayer());
			Components.Add(new VideoPlayer());
			Components.Add(new NotePad());
			Components.Add(new WebBrowser());
		}

		public override string ToString()
		{
			return Components.Count.ToString();
		}
	}
}
