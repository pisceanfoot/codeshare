using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EnvDTE;
using EnvDTE80;

namespace CodeShare.SSMSPlugin.Common.Plugin
{
    public class WindowManager
    {
        private DTE2 _applicationObject;
        private AddIn _addInInstance;

        public void CreateAddinWindow(string fullClassName)
        {
            Guid id = new Guid("4c410c93-d66b-495a-9de2-99d5bde4a3b9"); // this guid doesn't seem to matter?

            Assembly asm = Assembly.GetExecutingAssembly();
            //toolWindow = CreateToolWindow("iucon.ssms.QuickFind.SearchToolWindow", asm.Location, id, addinInstance);
        }

        private Window CreateToolWindow(string typeName, string assemblyLocation, Guid uiTypeGuid, AddIn addinInstance)
        {
            Windows2 win2 = _applicationObject.Windows as Windows2;
            if (win2 != null)
            {
                object controlObject = null;
                Assembly asm = Assembly.GetExecutingAssembly();
                Window toolWindow = win2.CreateToolWindow2(addinInstance, assemblyLocation, typeName, "QuickFind", "{" + uiTypeGuid.ToString() + "}", ref controlObject);
                toolWindow.Visible = true;
                return toolWindow;
            }
            return null;
        }
    }
}
