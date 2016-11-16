using Autofac;
using TicTacToe.Services;
using TicTacToe.Services.Implementations;
using TicTacToe.ViewModels;

namespace TicTacToe.Config
{
    /// <summary>
    /// Dependency injection configuration
    /// </summary>
    internal class IocConfig
    {
        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            //registrations
            builder.RegisterType<MainWindowViewModel>()
                   .AsSelf();

            builder.RegisterType<NullGameChecker>()
                   .As<IGameChecker>();

            builder.RegisterType<NullAIPlayer>()
                   .As<IAIPlayer>();

            return builder.Build();
        }
    }
}