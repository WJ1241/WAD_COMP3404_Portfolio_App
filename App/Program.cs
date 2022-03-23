using System;
using System.Collections;
using System.Collections.Generic;
using App.GeneralInterfaces;
using App.Services;
using App.Services.Factories;
using Server.Exceptions;
using Server.GeneralInterfaces;
using Server.InitialisingInterfaces;

namespace App
{
    /// <summary>
    /// Main Program class for Application
    /// Author: William Smith, Declan Kerby-Collins, William Eardley
    /// Date: 21/03/22
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // DECLARE & INSTANTIATE an ISetupApplication as a new Controller(), name it '_controller':
            ISetupApplication _controller = new Controller();

            // DECLARE & INSTANTIATE an IFactory<IService> as a new Factory<IService>():
            IFactory<IService> _serviceFactory = new Factory<IService>();

            // TRY checking if ClassDoesNotExistException OR NullInstanceException are thrown:
            try
            {
                // DECLARE & INSTANTIATE an IServiceLocator as a new ServiceLocator(), name it '_serviceLocator':
                IServiceLocator _serviceLocator = _serviceFactory.Create<ServiceLocator>() as IServiceLocator;

                // INITIALISE _serviceLocator with reference to _serviceFactory:
                (_serviceLocator as IInitialiseParam<IFactory<IService>>).Initialise(_serviceFactory);

                // INITIALISE _controller with reference to _serviceLocator:
                (_controller as IInitialiseParam<IServiceLocator>).Initialise(_serviceLocator);

                // INITIALISE _controller with a new IDictionary<int, IDisposable>() object:
                (_controller as IInitialiseParam<IDictionary<int, IDisposable>>).Initialise(
                    (_serviceLocator.GetService<Factory<IEnumerable>>() as IFactory<IEnumerable>).Create<Dictionary<int, IDisposable>>() as IDictionary<int, IDisposable>);
            }
            // CATCH ClassDoesNotExistException from Create():
            catch (ClassDoesNotExistException e)
            {
                // WRITE exception message to console:
                Console.WriteLine(e.Message);
            }
            // CATCH NullInstanceException from Create():
            catch (NullInstanceException e)
            {
                // WRITE exception message to console:
                Console.WriteLine(e.Message);
            }

            // CALL SetupApplication() on _controller:
            _controller.SetupApplication();

            // CALL RunApplication() on _controller:
            _controller.RunApplication();
        }
    }
}
