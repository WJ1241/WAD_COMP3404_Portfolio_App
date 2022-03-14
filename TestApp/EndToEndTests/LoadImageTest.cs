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
using GUI.Logic;
using GUI.Logic.Interfaces;
using Server;
using Server.Commands;
using Server.CustomEventArgs;
using Server.GeneralInterfaces;
using Server.InitialisingInterfaces;
using TestGUI.Interfaces;
using TestApp.MockClasses;
using System.Drawing;

namespace TestApp.EndToEndTests
{
    /// <summary>
    /// Test Class which checks if all necessary classes work together to allow the user to load an image
    /// Takes the Role of 'Program' due to creating and initialising EVERY required class
    /// Authors: William Smith, William Eardley & Declan Kerby-Collins
    /// Date: 14/03/22
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
    public class LoadImageTest
    {
        #region FIELD VARIABLES

        // DECLARE an IDictionary<int, IDisposable>, name it '_formDictionary':
        private IDictionary<int, IDisposable> _formDictionary;

        // DECLARE an IServiceLocator, name it '_serviceLocator':
        private IServiceLocator _serviceLocator;

        // DECLARE an ISetupApplication, name it '_controller':
        private ISetupApplication  _controller;

        // DECLARE a Mock<IFactory<IService>>, name it '_mockServiceFactory':
        Mock<IFactory<IService>> _mockServiceFactory;

        // DECLARE a Mock<IOpenImage>, name it '_mockOpenImage':
        private Mock<IOpenImage> _mockOpenImage;

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


        #region CALL IOPENIMAGE OPENIMAGE() TEST

        /// <summary>
        /// Checks if IOpenImage's OpenImage() method is called when user clicks Load Button successfully
        /// </summary>
        [TestMethod]
        public void Call_IOpenImage_OpenImage()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it '_pass', set to true so test passes if not changed:
            bool _pass = true;

            #endregion


            #region ACT

            // CALL SetupApplication() on _controller:
            _controller.SetupApplication();

             // CALL LoadBttn_Click() on _mockFishyHome, passing this class, and a new EventArgs() as parameters:
            (_formDictionary[0] as IMockFishyHome).LoadBttn_Click(this, (_serviceLocator.GetService<Factory<EventArgs>>() as IFactory<EventArgs>).Create<EventArgs>());

            #endregion


            #region ASSERT

            // TRY checking if _mockOpenImage.OpenImage() was called:
            try
            {
                // VERIFY that OpenImage() has been called at least once, due to errors with passing Mock<IOpenImage> results:
                _mockOpenImage.Verify(_mock => _mock.OpenImage(), Times.AtLeastOnce);
            }
            // CATCH MockException from Verify():
            catch (MockException)
            {
                // SET _pass to false, so that test fails:
                _pass = false;
            }
            // FINALISE try and catch block with test pass/fail:
            finally
            {
                // ASSERT if test has passed or failed depending on the value of _pass:
                Assert.IsTrue(_pass, "ERROR: _mockOpenImage.OpenImage() has not been called!");
            }

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
            #region INSTANTIATIONS

            // INSTANTIATE _mockServiceFactory as a new Mock<IFactory<IService>>():
            _mockServiceFactory = new Mock<IFactory<IService>>();

            // DECLARE & INSTANTIATE a new Mock<IFactory<IDisposable>>, name it '_mockDisposableFactory':
            Mock<IFactory<IDisposable>> _mockDisposableFactory = new Mock<IFactory<IDisposable>>();

            // DECLARE & INSTANTIATE a new Mock<IFactory<IEnumerable>>, name it '_mockEnumerableFactory':
            Mock<IFactory<IEnumerable>> _mockEnumerableFactory = new Mock<IFactory<IEnumerable>>();

            // DECLARE & INSTANTIATE a new Mock<IFactory<ILogic>>, name it '_mockLogicFactory':
            Mock<IFactory<ILogic>> _mockLogicFactory = new Mock<IFactory<ILogic>>();

            // DECLARE & INSTANTIATE a new Mock<IFactory<IEnumerable>>, name it '_mockEnumerableFactory':
            Mock<IFactory<ICommand>> _mockCommandFactory = new Mock<IFactory<ICommand>>();

            // DECLARE & INSTANTIATE a new Mock<IFactory<EventArgs>>, name it '_mockEventArgsFactory':
            Mock<IFactory<EventArgs>> _mockEventArgsFactory = new Mock<IFactory<EventArgs>>();

            // INSTANTIATE _mockOpenImage as a new Mock<IOpenImage>():
            _mockOpenImage = new Mock<IOpenImage>();

            // SETUP _mockOpenImage so that it can initialised with a new IList<string> object:
            _mockOpenImage.As<IInitialiseParam<IList<string>>>().Setup(_mock => _mock.Initialise(_mockEnumerableFactory.Object.Create<List<string>>() as IList<string>));

            #endregion


            #region FACTORY SETUP

            // SETUP _mockServiceFactory to create a new Factory<IDisposable>() and return _mockDisposableFactory.Object instead:
            _mockServiceFactory.Setup(_mock => _mock.Create<Factory<IDisposable>>()).Returns(_mockDisposableFactory.Object);

            // SETUP _mockServiceFactory to create a new Factory<IEnumerable>() and return _mockEnumerableFactory.Object instead:
            _mockServiceFactory.Setup(_mock => _mock.Create<Factory<IEnumerable>>()).Returns(_mockEnumerableFactory.Object);

            // SETUP _mockServiceFactory to create a new Factory<IEnumerable>() and return _mockEnumerableFactory.Object instead:
            _mockServiceFactory.Setup(_mock => _mock.Create<Factory<ILogic>>()).Returns(_mockLogicFactory.Object);

            // SETUP _mockServiceFactory to create a new Factory<ICommand>() and return _mockCommandFactory.Object instead:
            _mockServiceFactory.Setup(_mock => _mock.Create<Factory<ICommand>>()).Returns(_mockCommandFactory.Object);

            // SETUP _mockServiceFactory to create a new Factory<EventArgs>() and return _mockEventArgsFactory.Object instead:
            _mockServiceFactory.Setup(_mock => _mock.Create<Factory<EventArgs>>()).Returns(_mockEventArgsFactory.Object);

            // SETUP _mockServiceFactory to create a new CommandInvoker():
            _mockServiceFactory.Setup(_mock => _mock.Create<CommandInvoker>()).Returns(new CommandInvoker());

            // SETUP _mockServiceFactory to create a new ServiceLocator():
            _mockServiceFactory.Setup(_mock => _mock.Create<ServiceLocator>()).Returns(new ServiceLocator());

            // SETUP _mockServiceFactory to create a new ServiceLocator():
            _mockServiceFactory.Setup(_mock => _mock.Create<ImageServer>()).Returns(new ImageServer());

            // SETUP _mockServiceFactory to create a new ImageMgr():
            _mockServiceFactory.Setup(_mock => _mock.Create<ImageMgr>()).Returns(new ImageMgr());

            // SETUP _mockServiceFactory to create a new ImageEditor():
            _mockServiceFactory.Setup(_mock => _mock.Create<ImageEditor>()).Returns(new ImageEditor());

            // SETUP _mockDisposableFactory to create a new FishyHome() and return a new MockFishyHome() instead:
            _mockDisposableFactory.Setup(_mock => _mock.Create<FishyHome>()).Returns(new MockFishyHome());

            // SETUP _mockEnumerableFactory to create a new Dictionary<int, IDisposable>():
            _mockEnumerableFactory.Setup(_mock => _mock.Create<Dictionary<int, IDisposable>>()).Returns(new Dictionary<int, IDisposable>());

            // SETUP _mockEnumerableFactory to create a new Dictionary<string, ICommand>():
            _mockEnumerableFactory.Setup(_mock => _mock.Create<Dictionary<string, ICommand>>()).Returns(new Dictionary<string, ICommand>());

            // SETUP _mockEnumerableFactory to create a new Dictionary<string, EventArgs>():
            _mockEnumerableFactory.Setup(_mock => _mock.Create<Dictionary<string, EventArgs>>()).Returns(new Dictionary<string, EventArgs>());

            // SETUP _mockEnumerableFactory to create a new Dictionary<string, Image>():
            _mockEnumerableFactory.Setup(_mock => _mock.Create<Dictionary<string, Image>>()).Returns(new Dictionary<string, Image>());

            // SETUP _mockEnumerableFactory to create a new List<string>():
            _mockEnumerableFactory.Setup(_mock => _mock.Create<List<string>>()).Returns(new List<string>());

            // SETUP _mockServiceFactory to create a new OpenLogic() and return _mockOpenImage.Object instead:
            _mockLogicFactory.Setup(_mock => _mock.Create<OpenLogic>()).Returns(_mockOpenImage.Object);

            // SETUP _mockServiceFactory to create a new CommandParam<string>():
            _mockCommandFactory.Setup(_mock => _mock.Create<CommandParam<string>>()).Returns(new CommandParam<string>());

            // SETUP _mockServiceFactory to create a new CommandParam<IList<string>>():
            _mockCommandFactory.Setup(_mock => _mock.Create<CommandParam<IList<string>>>()).Returns(new CommandParam<IList<string>>());

            // SETUP _mockServiceFactory to create a new CommandParam<string, int, int>():
            _mockCommandFactory.Setup(_mock => _mock.Create<CommandParam<string, int, int>>()).Returns(new CommandParam<string, int, int>());

            // SETUP _mockServiceFactory to create a new CommandParam<IDisposable>():
            _mockCommandFactory.Setup(_mock => _mock.Create<CommandParam<IDisposable>>()).Returns(new CommandParam<IDisposable>());

            // SETUP _mockServiceFactory to create a new CommandParam<int>():
            _mockCommandFactory.Setup(_mock => _mock.Create<CommandParam<int>>()).Returns(new CommandParam<int>());

            // SETUP _mockEventArgsFactory to create a new EventArgs():
            _mockEventArgsFactory.Setup(_mock => _mock.Create<EventArgs>()).Returns(new EventArgs());

            // SETUP _mockEventArgsFactory to create a new ImageEventArgs():
            _mockEventArgsFactory.Setup(_mock => _mock.Create<ImageEventArgs>()).Returns(new ImageEventArgs());

            // SETUP _mockEventArgsFactory to create a new StringEventArgs():
            _mockEventArgsFactory.Setup(_mock => _mock.Create<StringListEventArgs>()).Returns(new StringListEventArgs());

            #endregion


            #region SERVICE LOCATOR

            // INSTANTIATE _serviceLocator as a new ServiceLocator():
            _serviceLocator = _mockServiceFactory.Object.Create<ServiceLocator>() as IServiceLocator;

            // INITIALISE _serviceLocator with reference to _mockServiceFactory.Object:
            (_serviceLocator as IInitialiseParam<IFactory<IService>>).Initialise(_mockServiceFactory.Object);

            #endregion


            #region OPEN IMAGE

            // DECLARE & INSTANTIATE an IList<string> as a new List<string>():
            IList<string> _tempList = _mockEnumerableFactory.Object.Create<List<string>>() as IList<string>;

            // ADD a file path to _tempList:
            _tempList.Add("..\\..\\..\\..\\Server\\Displayables\\FishAssets\\JavaFish.png");

            // SETUP _mockOpenImage so that OpenImage() returns a reference to _tempList:
            _mockOpenImage.Setup(_mock => _mock.OpenImage()).Returns(_tempList);

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

            // INSTANTIATE _formDictionary as a new Dictionary<int, IDisposable>():
            _formDictionary = _mockEnumerableFactory.Object.Create<Dictionary<int, IDisposable>>() as IDictionary<int, IDisposable>;

            // INITIALISE _controller with reference to _serviceLocator:
            (_controller as IInitialiseParam<IServiceLocator>).Initialise(_serviceLocator);

            // INITIALISE _controller with reference to _formDictionary:
            (_controller as IInitialiseParam<IDictionary<int, IDisposable>>).Initialise(_formDictionary);

            #endregion
        }

        #endregion
    }
}
