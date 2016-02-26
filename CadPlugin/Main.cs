using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Internal;
using Autodesk.AutoCAD.Runtime;
using CadPlugin.Injection;
using Microsoft.Framework.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CadApplication = Autodesk.AutoCAD.ApplicationServices.Application;

[assembly: ExtensionApplication(typeof(CadPlugin.Main))]
// block standart cad attributes
[assembly: CommandClass(typeof(CadPlugin.Main))]


//[assembly: ExtensionApplication(typeof(CadPlugin.CadApp))]
////[assembly: CommandClass(typeof(CadPlugin.CadApp))]
//[assembly: CommandClass(typeof(CadPlugin.CadApp))]
namespace CadPlugin
{
    //public class CadApp : IExtensionApplication
    //{
    //    public void Initialize()
    //    {
    //        Editor ed = CadApplication.DocumentManager.MdiActiveDocument.Editor;
    //        ed.WriteMessage("\nPlugin Init");
    //        //throw new NotImplementedException();
    //    }

    //    public void Terminate()
    //    {
    //        //throw new NotImplementedException();
    //    }
    //}


    class Main : IExtensionApplication
    {

        //static IServiceCollection services = new ServiceCollection();
        public void Initialize()
        {
            try
            {
                this.PrepareServices();
                //var startupType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == "Startup");
                //var services = new ServiceCollection();
                //services.AddInstance(services);
                //services.AddSingleton<IActivator, Injection.Activator>();
                //var provider = services.BuildServiceProvider();
                //var instance = ActivatorUtilities.CreateInstance(provider, startupType);
                //foreach (var method in startupType.GetMethods(BindingFlags.Public | BindingFlags.Instance).OrderBy(x => x.Name))
                //{
                //    method.Invoke(instance, method.GetParameters().Select(x => provider.GetService(x.ParameterType)).ToArray());
                //}
            }
            catch (System.Exception ee)
            {
                throw;
            }
        }

        public void Terminate()
        {
            throw new NotImplementedException();
        }
    }

}
