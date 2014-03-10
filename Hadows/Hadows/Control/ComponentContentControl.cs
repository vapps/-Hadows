using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hadows.Component;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Hadows.Control
{
	[TemplatePart(Name = "AddButton", Type = typeof(Button))]
	[TemplatePart(Name = "ClearButton", Type = typeof(Button))]
	[TemplatePart(Name = "ComponentSelector", Type = typeof(ComponentSelector))]
	[TemplatePart(Name = "EmptyState", Type = typeof(VisualState))]
	[TemplatePart(Name = "ContentState", Type = typeof(VisualState))]
	[TemplatePart(Name = "MyContentPresenter", Type = typeof(ContentPresenter))]
	public class ComponentContentControl : ContentControl, INotifyPropertyChanged
	{
		internal const string MyContentPresenterName = "MyContentPresenter";
		internal ContentPresenter MyContentPresenter;

		internal const string AddButtonName = "AddButton";
		internal Button AddButton;

		internal const string ClearButtonName = "ClearButton";
		internal Button ClearButton;

		internal const string EmptyStateName = "EmptyState";
		internal VisualState EmptyState;


		internal const string ContentStateName = "ContentState";
		internal VisualState ContentState;

		internal const string ContentSelectingStateName = "ContentSelectingState";
		internal VisualState ContentSelectingState;

		internal const string ComponentSelectorName = "ComponentSelector";
		internal ComponentSelector ComponentSelector;


		public ComponentContentControl()
		{
			this.DefaultStyleKey = typeof(ComponentContentControl);
			this.DataContext = this;
		}

		protected override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			InitializeComponents();
			LinkEvents();
		}

		public double GetComponentSnappedHeight()
		{
			if (MyContentPresenter == null ||
				MyContentPresenter.Content == null)
			{
				return double.NaN;
			}

			IComponent selectedItem = MyContentPresenter.Content as IComponent;
			Debug.Assert(selectedItem != null);


			return selectedItem.SnappedStateHeight;
		}

		private void LinkEvents()
		{
			AddButton.Click += AddButton_Click;
			ClearButton.Click += ClearButton_Click;
			ComponentSelector.ItemSelected += selector_ItemSelected;
		}

		void AddButton_Click(object sender, RoutedEventArgs e)
		{
			VisualStateManager.GoToState(this, ContentSelectingState.Name, false);
		}

		void selector_ItemSelected(object sender, Component.IComponent e)
		{
			FrameworkElement element = e.GetInstance();

			if (element == null)
			{
				Debug.Assert(false, "GetInstance()를 통해서 아이템을 만들어 내지 못했습니다.");
				return;
			}

			MyContentPresenter.Content = element;
			VisualStateManager.GoToState(this, ContentState.Name, false);
		}

		void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			MyContentPresenter.Content = null;
			VisualStateManager.GoToState(this, EmptyState.Name, false);
		}

		private void InitializeComponents()
		{
			MyContentPresenter = (ContentPresenter)GetTemplateChild(MyContentPresenterName);
			AddButton = (Button)GetTemplateChild(AddButtonName);
			ClearButton = (Button)GetTemplateChild(ClearButtonName);
			ComponentSelector = (ComponentSelector)GetTemplateChild(ComponentSelectorName);

			EmptyState = (VisualState)GetTemplateChild(EmptyStateName);
			ContentState = (VisualState)GetTemplateChild(ContentStateName);
			ContentSelectingState = (VisualState)GetTemplateChild(ContentSelectingStateName);




			Debug.Assert(MyContentPresenter != null);
			Debug.Assert(AddButton != null);
			Debug.Assert(ClearButton != null);
			Debug.Assert(ComponentSelector != null);


			Debug.Assert(EmptyState != null);
			Debug.Assert(ContentState != null);
			Debug.Assert(ContentSelectingState != null);
		}

		#region ▶ INotifyPropertyChanged Members
		public event PropertyChangedEventHandler PropertyChanged;
		/// <summary>
		/// 프로퍼티가 변경되면 PropertyChanged 이벤트을 발생시켜주는 메서드
		/// </summary>
		/// <param name="propertyName">변경된 프로퍼티 이름</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler == null)
			{
				return;
			}
			handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion INotifyPropertyChanged Members


	}
}
