using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeShare.SSMSPlugin.Common.Plugin;
using EnvDTE80;

namespace CodeShare.SSMSPlugin.Command
{
    public class CategoryToolCommand : CommandBase
    {
        public CategoryToolCommand(DTE2 application)
            : base(application, "Code Share", "Organize and Share every thing")
        {
        }
    }
}
