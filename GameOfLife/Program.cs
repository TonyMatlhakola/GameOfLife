using Autofac;
using GameOfLife.Ioc;
using GameOfLife.Uitls;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace GameOfLife
{


    internal class Program
    {      

        private static void Main(string[] args)
        {

            // DI/Ioc register dependencies
           var _serviceProvider = DependencyInjection.ConfigureIoCc();
           
            
            //Get app settings
            var _appSettings = ConfigurationSettings.GetConfiurationSettings();            

            //Begin Game
            int runs = 0;
          
            while (runs++ < _appSettings.MaxRuns)
            {
                _serviceProvider.Resolve<IGameOfLifeService>().DrawAndGrow();
                System.Threading.Thread.Sleep(_appSettings.SleepTime);
            }


        }

    }
}
