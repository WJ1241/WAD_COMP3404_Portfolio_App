using System;
using System.Collections;
using System.Collections.Generic;
using App.GeneralInterfaces;
using App.Services;
using App.Services.Factories;
using App.Services.Factories.Interfaces;
using App.Services.Interfaces;
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
            // DECLARE & INSTANTIATE an ISetupApplication as a new Controller(), name it 'controller':
            ISetupApplication controller = new Controller();

            // DECLARE & INSTANTIATE an IFactory<IService> as a new Factory<IService>():
            IFactory<IService> serviceFactory = new Factory<IService>();

            // TRY checking if ClassDoesNotExistException OR NullInstanceException are thrown:
            try
            {
                // DECLARE & INSTANTIATE an IServiceLocator as a new ServiceLocator(), name it 'serviceLocator':
                IServiceLocator serviceLocator = serviceFactory.Create<ServiceLocator>() as IServiceLocator;

                // INITIALISE serviceLocator with reference to serviceFactory:
                (serviceLocator as IInitialiseParam<IFactory<IService>>).Initialise(serviceFactory);

                // INITIALISE controller with reference to serviceLocator:
                (controller as IInitialiseParam<IServiceLocator>).Initialise(serviceLocator);

                // INITIALISE controller with a new IDictionary<int, IDisposable>() object:
                (controller as IInitialiseParam<IDictionary<int, IDisposable>>).Initialise(
                    (serviceLocator.GetService<Factory<IEnumerable>>() as IFactory<IEnumerable>).Create<Dictionary<int, IDisposable>>() as IDictionary<int, IDisposable>);
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

            // CALL SetupApplication() on controller:
            controller.SetupApplication();

            // CALL RunApplication() on controller:
            controller.RunApplication();
        }
    }
}
