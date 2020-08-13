using Autofac;
using Autofac.Core;

namespace GameOfLife.Ioc
{
    public static class DependencyInjection
    {      
        public static IContainer ConfigureIoCc()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Program>();
            builder.RegisterType<GameOfLifeService>().As<IGameOfLifeService>();
            return builder.Build();
        }
    }
}
