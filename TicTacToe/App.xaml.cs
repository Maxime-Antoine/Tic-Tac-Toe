using Autofac;
using System.Windows;
using TicTacToe.Config;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IContainer DependencyResolver { get; private set; }

        public App()
        {
            DependencyResolver = IocConfig.CreateContainer();
        }
    }
}