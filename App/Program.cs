using System;
using App.GeneralInterfaces;

namespace App
{
    /// <summary>
    /// Main Program class for Application
    /// Author: William Smith
    /// Date: 20/11/21
    /// </summary>
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // DECLARE AND INSTANTIATE an IApplicationStart as a new Controller(), name it '_controller':
            IApplicationStart _controller = new Controller();

            // CALL 'RunApplication()' on Controller object:
            _controller.RunApplication();
        }
    }
}
