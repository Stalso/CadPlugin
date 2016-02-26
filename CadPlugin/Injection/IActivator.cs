using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadPlugin.Injection
{
    public interface IActivator
    {
        object Create<Type>();
        void AddCommands<Type>();
        void AddCommandsSingleton<Type>();
    }
}
