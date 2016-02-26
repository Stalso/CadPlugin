using Autodesk.AutoCAD.Runtime;
using Microsoft.Framework.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CadPlugin.Injection
{
    public static class CadInitializer
    {
        //TODO Why it shoulbe static???
        private static IServiceCollection services = new ServiceCollection();
        public static void PrepareServices(this IExtensionApplication app)
        {
            var startupType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == "Startup");
            //var services = new ServiceCollection();
            services.AddInstance(services);
            services.AddSingleton<IActivator, Injection.Activator>();
            var provider = services.BuildServiceProvider();
            var instance = ActivatorUtilities.CreateInstance(provider, startupType);
            foreach (var method in startupType.GetMethods(BindingFlags.Public | BindingFlags.Instance).OrderBy(x => x.Name))
            {
                method.Invoke(instance, method.GetParameters().Select(x => provider.GetService(x.ParameterType)).ToArray());
            }
        }
    }
}
