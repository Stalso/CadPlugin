using Autodesk.AutoCAD.Internal;
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
    public class Activator : IActivator
    {
        private IServiceCollection services;

        public Activator(IServiceCollection services)
        {
            this.services = services;
        }

        object Create(Type type)
        {
            return ActivatorUtilities.CreateInstance(services.BuildServiceProvider(), type);
        }

        public object Create<Type>()
        {
            return Create(typeof(Type));
        }

        public void AddCommandsSingleton<Type>()
        {
            var type = typeof(Type);
            object instance = null; // will be created once at first command call

            var commandMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(x => x.GetCustomAttributes<CommandMethodAttribute>().Any());

            if (commandMethods.Any())
            {
                foreach (var method in commandMethods)
                {
                    var attr = method.GetCustomAttribute<CommandMethodAttribute>();
                    Utils.AddCommand(attr.GroupName ?? "CadPlugin", attr.GlobalName, attr.LocalizedNameId ?? attr.GlobalName, attr.Flags, () =>
                    {
                        var provider = services.BuildServiceProvider();
                        method.Invoke(
                                instance ?? (instance = Create(type)),
                                method.GetParameters().Select(x => provider.GetService(x.ParameterType)).ToArray()
                                );
                    });
                }
            }
        }

        public void AddCommands<Type>()
        {
            var type = typeof(Type);

            var commandMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(x => x.GetCustomAttributes<CommandMethodAttribute>().Any());

            if (commandMethods.Any())
            {
                foreach (var method in commandMethods)
                {
                    var attr = method.GetCustomAttribute<CommandMethodAttribute>();
                    //TODO AcEdCommandStack::addCommand(). 
                    Utils.AddCommand(attr.GroupName ?? "CadPlugin", attr.GlobalName, attr.LocalizedNameId ?? attr.GlobalName, attr.Flags, () =>
                    {
                        var provider = services.BuildServiceProvider();
                        var instance = ActivatorUtilities.CreateInstance(provider, type);
                        method.Invoke(
                            instance,
                            method.GetParameters().Select(x => provider.GetService(x.ParameterType)).ToArray()
                            );
                    });
                }
            }
        }
    }
}
