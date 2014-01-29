using System.Reflection;

using EnvDTE80;

using EnvDTE;
using System;

namespace CodeShare.SSMSPlugin.Common.Plugin
{
    public abstract class CommandBase
    {
        //protected static readonly ILog _logger = LogManager.GetLogger((MethodBase.GetCurrentMethod().DeclaringType));

        private DTE2 application;

        public delegate void OnCommandClickHandler();
        public event OnCommandClickHandler OnCommandClick;

        private System.Guid id = System.Guid.NewGuid();
        private string caption;
        private string tooltipText;

        /// <summary>
        /// Gets or sets the application.
        /// </summary>
        /// <value>The application.</value>
        public DTE2 Application
        {
            get { return application; }
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        /// <value>The id.</value>
        public System.Guid Id
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { return this.GetType().Name; }
        }
        
        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>The caption.</value>
        public string Caption
        {
            get
            {
                return caption;
            }
            set
            {
                caption = value;
            }
        }

        /// <summary>
        /// Gets or sets the tooltip text.
        /// </summary>
        /// <value>The tooltip text.</value>
        public string TooltipText
        {
            get
            {
                return tooltipText;
            }
            set
            {
                tooltipText = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CommandBase"/> class.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <param name="caption">The caption code.</param>
        /// <param name="tooltipText">The tooltip text code.</param>
        public CommandBase(DTE2 application, string caption, string tooltipText)
        {
            this.application = application;
            this.caption = caption;
            this.tooltipText = tooltipText;
        }

        /// <summary>
        /// Performs this instance.
        /// </summary>
        public virtual void Perform()
        {
            if (OnCommandClick != null)
            {
                OnCommandClick();
            }
        }

        /// <summary>
        /// ����� OutputWindow
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        protected void writeReadOW(string type, string message)
        {
            DTE2 dte = Application;

            // Add-in code.
            // Create a reference to the Output window.
            // Create a tool window reference for the Output window
            // and window pane.
            OutputWindow ow = dte.ToolWindows.OutputWindow;
            // Create a reference to the pane contents.

            // Select the Build pane in the Output window.
            OutputWindowPane pane = null;

            for (int i = 1; i <= ow.OutputWindowPanes.Count; i++)
            {
                OutputWindowPane tmpPane = ow.OutputWindowPanes.Item(i);
                //if (tmpPane.Name == REFERENCELIB_PANE_NAME)
                //{
                //    pane = tmpPane;
                //    break;
                //}
            }

            if (pane == null)
            {
                //pane = ow.OutputWindowPanes.Add(REFERENCELIB_PANE_NAME);
            }

            pane.Activate();

            // Put some text in the pane.
            pane.OutputString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + type + ":\r\n");
            pane.OutputString(message + "\r\n");
        }
    }
}
