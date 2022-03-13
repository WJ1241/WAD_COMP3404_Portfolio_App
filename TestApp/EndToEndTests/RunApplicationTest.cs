using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using App;
using App.GeneralInterfaces;
using App.Services;
using App.Services.Factories;
using GUI;
using GUI.Logic.Interfaces;
using Server.Commands;
using Server.CustomEventArgs;
using Server.GeneralInterfaces;
using Server.InitialisingInterfaces;
using TestApp.MockClasses;

namespace TestApp.EndToEndTests
{
    /// <summary>
    /// Test Class which checks if all necessary classes work together to allow the app to start
    /// Takes the Role of 'Program' due to creating and initialising EVERY required class
    /// Authors: William Smith, William Eardley & Declan Kerby-Collins
    /// Date: 13/03/22
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
    /// - Initialise Server
    /// - Create 
    /// - Create MockFishyHome
    /// - Initialise MockFishyHome
    /// - Create Commands
    /// - Initialise Commands
    ///
    ///        FishyHome
    /// - User Clicks Load Image Button
    /// - Use OpenFileDialog to allow User to choose image, and return list to form
    /// - List is sent to server via command
    /// 
    ///         Server
    /// - Filters List in Image Manager
    /// - Invoke List Change
    /// - Calls Get Image on Server via Command
    /// - Manager returns Image and Invokes Change Command to update image
    /// 
    /// </summary>
    [TestClass]
    public class RunApplicationTest
    {
        #region FIELD VARIABLES

        // DECLARE an IDictionary<int, IDisposable>, name it '_formDictionary':
        private IDictionary<int, IDisposable> _formDictionary;

        // DECLARE an IServiceLocator, name it '_serviceLocator':
        private IServiceLocator _serviceLocator;

        // DECLARE an ISetupApplication, name it '_controller':
        private ISetupApplication  _controller;

        // DECLARE an IEventListener<ImageEventArgs>, name it '_mockFishyHome':
        private IEventListener<ImageEventArgs> _mockFishyHome;

        // DECLARE an IEventListener<ImageEventArgs>, name it '_mockFishyEdit':
        private IEventListener<ImageEventArgs> _mockFishyEdit;

        #endregion


        #region MOCKFISHYHOME CREATION TEST

        /// <summary>
        /// Checks if Controller creates a FishyHome successfully
        /// </summary>
        [TestMethod]
        public void Create_FishyHome()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it '_pass', set to true so test passes if not changed:
            bool _pass = true;

            #endregion


            #region ACT

            // CALL SetupApplication() on _controller:
            _controller.SetupApplication();

            #endregion


            #region ASSERT

            // IF _formDictionary DOES NOT contain an IDisposable at index '0':
            if (_formDictionary[0] == null)
            {
                // SET _pass to false:
                _pass = false;
            }

            // ASSERT if test has passed, and give corresponding message if _pass is false:
            Assert.IsTrue(_pass, "ERROR: Controller has not created a FishyHome object!");

            #endregion
        }

        #endregion

        #region SETUP METHODS

        /// <summary>
        /// Creates and Initialises this class' dependencies
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            #region FACTORY SETUP

            // DECLARE a Mock<IFactory<IService>>, name it '_mockServiceFactory':
            Mock<IFactory<IService>> _mockServiceFactory = new Mock<IFactory<IService>>();

            // DECLARE a Mock<IFactory<IDisposable>>, name it '_mockDisposableFactory':
            Mock<IFactory<IDisposable>> _mockDisposableFactory = new Mock<IFactory<IDisposable>>();

            // DECLARE a Mock<IFactory<IEnumerable>>, name it '_mockEnumerableFactory':
            Mock<IFactory<IEnumerable>> _mockEnumerableFactory = new Mock<IFactory<IEnumerable>>();

            // DECLARE a Mock<IFactory<ILogic>>, name it '_mockLogicFactory':
            Mock<IFactory<ILogic>> _mockLogicFactory = new Mock<IFactory<ILogic>>();

            // DECLARE a Mock<IFactory<IEnumerable>>, name it '_mockEnumerableFactory':
            Mock<IFactory<ICommand>> _mockCommandFactory = new Mock<IFactory<ICommand>>();

            // SETUP _mockServiceFactory to create a new Factory<IDisposable>() and return _mockDisposableFactory.Object instead:
            _mockServiceFactory.Setup(_mock => _mock.Create<Factory<IDisposable>>()).Returns(_mockDisposableFactory.Object);

            // SETUP _mockServiceFactory to create a new Factory<IEnumerable>() and return _mockEnumerableFactory.Object instead:
            _mockServiceFactory.Setup(_mock => _mock.Create<Factory<IEnumerable>>()).Returns(_mockEnumerableFactory.Object);

            // SETUP _mockServiceFactory to create a new Factory<ICommand>() and return _mockCommandFactory.Object instead:
            _mockServiceFactory.Setup(_mock => _mock.Create<Factory<ICommand>>()).Returns(_mockCommandFactory.Object);

            // SETUP _mockServiceFactory to create a new CommandInvoker():
            _mockServiceFactory.Setup(_mock => _mock.Create<CommandInvoker>()).Returns(new CommandInvoker());

            // SETUP _mockServiceFactory to create a new ServiceLocator():
            _mockServiceFactory.Setup(_mock => _mock.Create<ServiceLocator>()).Returns(new ServiceLocator());

            // SETUP _mockDisposableFactory to create a new FishyHome() and return a new MockFishyHome() instead:
            _mockDisposableFactory.Setup(_mock => _mock.Create<FishyHome>()).Returns(new MockFishyHome());

            // SETUP _mockEnumerableFactory to create a new Dictionary<int, IDisposable>():
            _mockEnumerableFactory.Setup(_mock => _mock.Create<Dictionary<int, IDisposable>>()).Returns(new Dictionary<int, IDisposable>());
            #endregion


            #region SERVICE LOCATOR

            // INSTANTIATE _serviceLocator as a new ServiceLocator():
            _serviceLocator = _mockServiceFactory.Object.Create<ServiceLocator>() as IServiceLocator;

            // INITIALISE _serviceLocator with reference to _mockServiceFactory.Object:
            (_serviceLocator as IInitialiseParam<IFactory<IService>>).Initialise(_mockServiceFactory.Object);

            #endregion


            #region CREATION

            // DECLARE & INSTANTIATE an ICommandInvoker as a new CommandInvoker, name it '_commandInvoker'():
            ICommandInvoker _commandInvoker = _mockServiceFactory.Object.Create<CommandInvoker>() as ICommandInvoker;

            // INSTANTIATE _controller as a new Controller():
            _controller = new Controller();

            #endregion


            #region INITIALISATION

            // INITIALISE _serviceLocator with reference to _mockServiceFactory.Object:
            (_serviceLocator as IInitialiseParam<IFactory<IService>>).Initialise(_mockServiceFactory.Object);

            // INITIALISE _controller with reference to _serviceLocator:
            (_controller as IInitialiseParam<IServiceLocator>).Initialise(_serviceLocator);


            (_controller as IInitialiseParam<IDictionary<int, IDisposable>>).Initialise(_mockEnumerableFactory.Object.Create<Dictionary<int, IDisposable>>() as IDictionary<int, IDisposable>);

            #endregion
        }

        #endregion
    }
}
