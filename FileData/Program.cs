using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyTools;
using Autofac;
using ThirdPartyTools.Interface;

namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var container = ContainerConfig.Configure();
                using (var scope = container.BeginLifetimeScope())
                {
                    var app = scope.Resolve<IApplication>();
                    string consoleMessage = app.GetVersionOrSize(args);
                    Console.WriteLine(consoleMessage);
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
           
        }
    }
}
