using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadApplication = Autodesk.AutoCAD.ApplicationServices.Application;

namespace CadPlugin.Services.InitService
{
    public class InitCommands
    {
        [CommandMethod("pinit")]
        public void InitCommand()
        {
            Editor ed = CadApplication.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage("\nPinit command");
        }
    }
}
