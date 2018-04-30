using Autofac;
using SR.Xam.Sample.Services;
using System;
using System.Globalization;
using System.Reflection;
using SR.Xam.Sample.Services.RequestProvider;
using Xamarin.Forms;
using SR.Xam.Sample.Services.User;

namespace SR.Xam.Sample.ViewModels.Base
{
    public static class ViewModelLocator
    {
		private static IContainer _container;

		public static readonly BindableProperty AutoWireViewModelProperty =
			BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

		public static bool GetAutoWireViewModel(BindableObject bindable)
		{
			return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
		}

		public static void SetAutoWireViewModel(BindableObject bindable, bool value)
		{
			bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
		}

		public static bool UseMockService { get; set; }

		public static void RegisterDependencies(bool useMockServices)
		{
            try
            {
                var builder = new ContainerBuilder();

                // View models
                builder.RegisterType<UserListViewModel>();

                // Services
                builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
                builder.RegisterType<DialogService>().As<IDialogService>();
                builder.RegisterType<RequestProvider>().As<IRequestProvider>();
                if (useMockServices)
                {
                    builder.RegisterType<UserService>().As<IUserService>();
                }
                else
                {
                    builder.RegisterType<UserService>().As<IUserService>();
                }

                if (_container != null)
                {
                    _container.Dispose();
                }
                _container = builder.Build();
            }
            catch (Exception ex)
            {

                throw;
            }
		}

		public static T Resolve<T>()
		{
			return _container.Resolve<T>();
		}

		private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var view = bindable as Element;
			if (view == null)
			{
				return;
			}

			var viewType = view.GetType();
			var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
			var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
			var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

			var viewModelType = Type.GetType(viewModelName);
			if (viewModelType == null)
			{
				return;
			}
			var viewModel = _container.Resolve(viewModelType);
			view.BindingContext = viewModel;
		}
	}
}