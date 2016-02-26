using CadPlugin.Injection;
using CadPlugin.Services.InitService;
using Microsoft.Framework.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadPlugin
{
    class Startup
    {      
        public void Configure(IServiceCollection col, IActivator activator)
        {             
            activator.AddCommands<InitCommands>();
        }
    }
}
