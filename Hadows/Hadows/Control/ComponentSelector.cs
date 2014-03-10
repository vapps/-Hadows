using System;
using System.Diagnostics;
using Hadows.Component;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Hadows.Control
{
	[TemplatePart(Name = "ComponentListView", Type = typeof(ListBox))]
	[TemplatePart(Name = "EmptyState", Type = typeof(VisualState))]
	[TemplatePart(Name = "ContentState", Type = typeof(VisualState))]
	[TemplatePart(Name = "ContentSelectingState", Type = typeof(VisualState))]
	public class ComponentSelector : Windows.UI.Xaml.Controls.Control
	{
		//-------------------------- ▶ Members
		internal const string ComponentListViewName = "ComponentListView";
		internal ListBox ComponentListView;









		//-------------------------- ▶ Events
		#region ItemSelected
		public event EventHandler<IComponent> ItemSelected;
		/// <summary>
		/// 
		/// </summary>
		private void InvokeItemSelected(IComponent component)
		{
			if (ItemSelected == null)
				return;

			ItemSelected(this, component);
		}
		#endregion ItemSelected


		//-------------------------- ▶ Constructors	
		public ComponentSelector()
		{
			this.DefaultStyleKey = typeof(ComponentSelector);

			Binding dataContextBinding = new Binding()
			{
				Source = App.Current.Resources["Locator"],
				Path = new PropertyPath("Component")
			};
			this.SetBinding(FrameworkElement.DataContextProperty, dataContextBinding);
		}


		//-------------------------- ▶ Methods
		void LinkEvents()
		{
			ComponentListView.SelectionChanged += ComponentListView_SelectionChanged;
		}


		//-------------------------- ▶ EventHandlers
		void ComponentListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			IComponent selectedComponent = e.AddedItems[0] as IComponent;
			if (selectedComponent == null)
			{
				Debug.Assert(false, "선택된 아이템이 IComponent가 아닙니다.");
				return;
			}

			InvokeItemSelected(selectedComponent);
		}



		//-------------------------- ▶ Overrides
		protected override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			InitilaizeComponents();
			LinkEvents();
		}

		void InitilaizeComponents()
		{
			ComponentListView = (ListBox)GetTemplateChild(ComponentListViewName);
			Debug.Assert(ComponentListView != null);
		}
	}
}
