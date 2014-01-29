using System;
using Extensibility;
using EnvDTE;
using EnvDTE80;
using Microsoft.SqlServer.Management.UI.VSIntegration;
using CodeShare.SSMSPlugin.Common.Plugin;
using Microsoft.VisualStudio.CommandBars;
using CodeShare.SSMSPlugin.Command;
using CodeShare.UI;

namespace CodeShare.SSMSPlugin
{
	/// <summary>The object for implementing an Add-in.</summary>
	/// <seealso class='IDTExtensibility2' />
	public class Connect : IDTExtensibility2
	{
        private PluginManager pluginManager;

		/// <summary>Implements the constructor for the Add-in object. Place your initialization code within this method.</summary>
		public Connect()
		{
		}

		/// <summary>Implements the OnConnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being loaded.</summary>
		/// <param term='application'>Root object of the host application.</param>
		/// <param term='connectMode'>Describes how the Add-in is being loaded.</param>
		/// <param term='addInInst'>Object representing this Add-in.</param>
		/// <seealso class='IDTExtensibility2' />
        public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
		{
            if (connectMode == ext_ConnectMode.ext_cm_Startup)
            {
                _addInInstance = (AddIn)addInInst;
                _applicationObject = _addInInstance.DTE as DTE2;
                //_applicationObject = (DTE2)ServiceCache.ExtensibilityModel;

                pluginManager = new PluginManager(_applicationObject, _addInInstance);

                CommandBarPopup toolCommandBar = pluginManager.MenuManager.CreatePopupMenu("MenuBar", "Tools");

                CategoryToolCommand categoryToolCommand = new CategoryToolCommand(_applicationObject);
                categoryToolCommand.OnCommandClick += command_OnCommandClick;
                pluginManager.MenuManager.AddCommandMenu(toolCommandBar, categoryToolCommand, 1);
            }
		}

        private Window codeCategoryToolWindow;
        private void command_OnCommandClick()
        {
            if (codeCategoryToolWindow == null)
            {
                codeCategoryToolWindow = pluginManager.WindowManager.CreateAddinWindow<CodeCategoryToolWindow>("Code Share");
                codeCategoryToolWindow.Visible = true;
            }
            else if (!codeCategoryToolWindow.Visible)
            {
                codeCategoryToolWindow.Visible = true;
            }
        }

		/// <summary>Implements the OnDisconnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being unloaded.</summary>
		/// <param term='disconnectMode'>Describes how the Add-in is being unloaded.</param>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
		{
		}

		/// <summary>Implements the OnAddInsUpdate method of the IDTExtensibility2 interface. Receives notification when the collection of Add-ins has changed.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />		
		public void OnAddInsUpdate(ref Array custom)
		{
		}

		/// <summary>Implements the OnStartupComplete method of the IDTExtensibility2 interface. Receives notification that the host application has completed loading.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnStartupComplete(ref Array custom)
		{
		}

		/// <summary>Implements the OnBeginShutdown method of the IDTExtensibility2 interface. Receives notification that the host application is being unloaded.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnBeginShutdown(ref Array custom)
		{
		}
		
		private DTE2 _applicationObject;
		private AddIn _addInInstance;
	}
}