using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using App;
using App.GeneralInterfaces;
using App.Services;
using GUI.Forms.Interfaces;
using Server.Commands;
using Server.CustomEventArgs;
using Server.GeneralInterfaces;
using Server.InitialisingInterfaces;

namespace TestApp.EndToEndTests
{
    /// <summary>
    /// Test Class which checks if all necessary classes work together to allow the app to start
    /// Takes the Role of 'Program' due to creating and initialising EVERY required class
    /// Authors: William Smith, William Eardley & Declan Kerby-Collins
    /// Date: 06/03/22
    /// 
    ///	        Program
    ///	- Create IFactory<IService>
    ///	- Create ICommandInvoker
    /// - Create IServiceLocator
    /// - Initialise IServiceLocator with IFactory<IService>
    /// - Create IApplicationStart
    /// - Initialise IApplicationStart with IServiceLocator
    ///
    ///        Controller
    /// - Create Server
    /// - Create All individual classes which edit images
    /// - Create FishyHome
    /// - Initialise FishyHome with Action<ICommand>
    /// - Initialise FishyHome with ICommand(s) (Server Methods)
    ///
    ///        FishyHome
    /// - Load Image
    /// - Use OpenFileDialog to allow User to choose image, and return image back to User
    /// - User Clicks Edit
    /// - Call Action<ICommand> passing ICommand to activate Controller.CreateFishyEdit()
    ///
    ///         Server
    /// - Subscribe Editor Event Handler to pass image back through EventArgs
    /// - Edits Image
    /// - Invoke Image Change Event
    /// </summary>
    [TestClass]
    public class RunApplicationTest
    {
        #region FIELD VARIABLES

        // DECLARE an IDictionary<int, IDisposable>, name it '_formDictionary':
        private IDictionary<int, IDisposable> _formDictionary;

        // DECLARE an IServiceLocator, name it '_serviceLocator':
        private IServiceLocator _serviceLocator;

        // DECLARE an IApplicationStart, name it '_controller':
        private IApplicationStart _controller;

        // DECLARE an IEventListener<ImageEventArgs>, name it '_mockFishyHome':
        private IEventListener<ImageEventArgs> _mockFishyHome;

        // DECLARE an IEventListener<ImageEventArgs>, name it '_mockFishyEdit':
        private IEventListener<ImageEventArgs> _mockFishyEdit;

        #endregion


        #region TEST METHODS

        #region CREATE FISHYEDIT

        /// <summary>
        /// Checks if a FishyEdit object is created successfully
        /// </summary>
        [TestMethod]
        public void Create_MockFishyEdit()
        {
            #region ARRANGE



            #endregion


            #region ACT



            #endregion


            #region ASSERT

            // IF _mockFishyEdit DOES NOT HAVE an active instance:
            if (_mockFishyEdit == null)
            {
                // ASSERT that test has failed, with corresponding message:
                Assert.Fail("ERROR: _mockFishyEdit does not have an active instance!");
            }

            #endregion
        }

        #endregion

        #endregion


        #region SETUP METHODS

        /// <summary>
        /// Creates and Initialises this class' dependencies
        /// </summary>
        [TestInitialize]
        private void SetupApplication()
        {
            #region FACTORY SETUP

            // DECLARE a Mock<IFactory<IService>>, name it '_mockServiceFactory':
            Mock<IFactory<IService>> _mockServiceFactory = new Mock<IFactory<IService>>();

            // SETUP _mockServiceFactory to create a new CommandInvoker():
            _mockServiceFactory.Setup(_mock => _mock.Create<CommandInvoker>()).Returns(new CommandInvoker());

            // SETUP _mockServiceFactory to create a new ServiceLocator():
            _mockServiceFactory.Setup(_mock => _mock.Create<ServiceLocator>()).Returns(new ServiceLocator());

            #endregion


            #region CREATION

            // DECLARE & INSTANTIATE an ICommandInvoker as a new CommandInvoker, name it '_commandInvoker'():
            ICommandInvoker _commandInvoker = _mockServiceFactory.Object.Create<CommandInvoker>() as ICommandInvoker;

            // INSTANTIATE _serviceLocator as a new ServiceLocator():
            _serviceLocator = _mockServiceFactory.Object.Create<ServiceLocator>() as IServiceLocator;

            // INSTANTIATE _controller as a new Controller():
            _controller = new Controller();

            #endregion


            #region INITIALISATION

            // INITIALISE _serviceLocator with reference to _mockServiceFactory.Object:
            (_serviceLocator as IInitialiseParam<IFactory<IService>>).Initialise(_mockServiceFactory.Object);

            // INITIALISE _controller with reference to _serviceLocator:
            (_controller as IInitialiseParam<IServiceLocator>).Initialise(_serviceLocator);

            #endregion
        }

        #endregion
    }
}
