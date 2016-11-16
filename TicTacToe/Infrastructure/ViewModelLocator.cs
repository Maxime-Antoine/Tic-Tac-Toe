using Autofac;
using System.Windows;
using TicTacToe.ViewModels;

namespace TicTacToe.Infrastructure
{
    internal class ViewModelLocator
    {
        private IContainer _container;

        public ViewModelLocator()
        {
            _container = ((App)Application.Current).DependencyResolver;
        }

        #region ViewModels

        public MainWindowViewModel MainWindow
        {
            get
            {
                using (_container.BeginLifetimeScope())
                {
                    return _container.Resolve<MainWindowViewModel>();
                }
            }
        }

        #endregion ViewModels
    }
}