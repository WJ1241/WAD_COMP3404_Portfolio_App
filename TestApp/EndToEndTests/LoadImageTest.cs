using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using App;
using App.GeneralInterfaces;
using App.Services;
using App.Services.Factories;
using App.Services.Factories.Interfaces;
using App.Services.Interfaces;
using GUI;
using GUI.Logic;
using GUI.Logic.Interfaces;
using Server;
using Server.Commands;
using Server.Commands.Interfaces;
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
    /// Date: 22/03/22
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


        #region CHECK IF MOCKFISHYHOME HAS VALID IMAGE

        /// <summary>
        /// Checks if Controller creates a FishyHome successfully
        /// </summary>
        [TestMethod]
        public void Check_If_MockFishyHome_Has_Valid_Image()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it '_pass', set to true so test passes if not changed:
            bool _pass = true;

            // CALL SetupApplication() on _controller:
            _controller.SetupApplication();

            #endregion


            #region ACT

            // CALL LoadBttn_Click() Event passing this class and a new EventArgs() as parameters:
            (_formDictionary[0] as IMockFishyHome).LoadBttn_Click(this, (_serviceLocator.GetService<Factory<EventArgs>>() as IFactory<EventArgs>).Create<EventArgs>());

            #endregion


            #region ASSERT

            // IF _formDictionary.ImgDisplay DOES NOT HAVE a displayable image:
            if ((_formDictionary[0] as IMockFishyHome).ImgDisplay == null)
            {
                // SET _pass to false:
                _pass = false;
            }

            // ASSERT if test has passed, and give corresponding message if _pass is false:
            Assert.IsTrue(_pass, "ERROR: MockFishyHome does not have a displayable image!");

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

            // DECLARE & INSTANTIATE a new Mock<IFactory<IDisposable>>, name it 'mockDisposableFactory':
            Mock<IFactory<IDisposable>> mockDisposableFactory = new Mock<IFactory<IDisposable>>();

            // DECLARE & INSTANTIATE a new Mock<IFactory<IEnumerable>>, name it 'mockEnumerableFactory':
            Mock<IFactory<IEnumerable>> mockEnumerableFactory = new Mock<IFactory<IEnumerable>>();

            // DECLARE & INSTANTIATE a new Mock<IFactory<ILogic>>, name it 'mockLogicFactory':
            Mock<IFactory<ILogic>> mockLogicFactory = new Mock<IFactory<ILogic>>();

            // DECLARE & INSTANTIATE a new Mock<IFactory<ICommand>>, name it 'mockCommandFactory':
            Mock<IFactory<ICommand>> mockCommandFactory = new Mock<IFactory<ICommand>>();

            // DECLARE & INSTANTIATE a new Mock<IFactory<EventArgs>>, name it 'mockEventArgsFactory':
            Mock<IFactory<EventArgs>> mockEventArgsFactory = new Mock<IFactory<EventArgs>>();

            // INSTANTIATE _mockOpenImage as a new Mock<IOpenImage>():
            _mockOpenImage = new Mock<IOpenImage>();

            // SETUP _mockOpenImage so that it can initialised with a new IList<string> object:
            _mockOpenImage.As<IInitialiseParam<IList<string>>>().Setup(mock => mock.Initialise(mockEnumerableFactory.Object.Create<List<string>>() as IList<string>));

            #endregion


            #region FACTORY SETUP

            // SETUP _mockServiceFactory to create a new Factory<IDisposable>() and return mockDisposableFactory.Object instead:
            _mockServiceFactory.Setup(mock => mock.Create<Factory<IDisposable>>()).Returns(mockDisposableFactory.Object);

            // SETUP _mockServiceFactory to create a new Factory<IEnumerable>() and return mockEnumerableFactory.Object instead:
            _mockServiceFactory.Setup(mock => mock.Create<Factory<IEnumerable>>()).Returns(mockEnumerableFactory.Object);

            // SETUP _mockServiceFactory to create a new Factory<IEnumerable>() and return mockEnumerableFactory.Object instead:
            _mockServiceFactory.Setup(mock => mock.Create<Factory<ILogic>>()).Returns(mockLogicFactory.Object);

            // SETUP _mockServiceFactory to create a new Factory<ICommand>() and return mockCommandFactory.Object instead:
            _mockServiceFactory.Setup(mock => mock.Create<Factory<ICommand>>()).Returns(mockCommandFactory.Object);

            // SETUP _mockServiceFactory to create a new Factory<EventArgs>() and return mockEventArgsFactory.Object instead:
            _mockServiceFactory.Setup(mock => mock.Create<Factory<EventArgs>>()).Returns(mockEventArgsFactory.Object);

            // SETUP _mockServiceFactory to create a new CommandInvoker():
            _mockServiceFactory.Setup(mock => mock.Create<CommandInvoker>()).Returns(new CommandInvoker());

            // SETUP _mockServiceFactory to create a new ServiceLocator():
            _mockServiceFactory.Setup(mock => mock.Create<ServiceLocator>()).Returns(new ServiceLocator());

            // SETUP _mockServiceFactory to create a new ServiceLocator():
            _mockServiceFactory.Setup(mock => mock.Create<ImageServer>()).Returns(new ImageServer());

            // SETUP _mockServiceFactory to create a new ImageMgr():
            _mockServiceFactory.Setup(mock => mock.Create<ImageMgr>()).Returns(new ImageMgr());

            // SETUP _mockServiceFactory to create a new ImageEditor():
            _mockServiceFactory.Setup(mock => mock.Create<ImageEditor>()).Returns(new ImageEditor());

            // SETUP mockDisposableFactory to create a new FishyHome() and return a new MockFishyHome() instead:
            mockDisposableFactory.Setup(mock => mock.Create<FishyHome>()).Returns(new MockFishyHome());

            // SETUP mockEnumerableFactory to create a new Dictionary<int, IDisposable>():
            mockEnumerableFactory.Setup(mock => mock.Create<Dictionary<int, IDisposable>>()).Returns(new Dictionary<int, IDisposable>());

            // SETUP mockEnumerableFactory to create a new Dictionary<int, string>():
            mockEnumerableFactory.Setup(mock => mock.Create<Dictionary<int, string>>()).Returns(new Dictionary<int, string>());

            // SETUP mockEnumerableFactory to create a new Dictionary<string, ICommand>():
            mockEnumerableFactory.Setup(mock => mock.Create<Dictionary<string, ICommand>>()).Returns(new Dictionary<string, ICommand>());

            // SETUP mockEnumerableFactory to create a new Dictionary<string, EventArgs>():
            mockEnumerableFactory.Setup(mock => mock.Create<Dictionary<string, EventArgs>>()).Returns(new Dictionary<string, EventArgs>());

            // SETUP mockEnumerableFactory to create a new Dictionary<string, Image>():
            mockEnumerableFactory.Setup(mock => mock.Create<Dictionary<string, Image>>()).Returns(new Dictionary<string, Image>());

            // SETUP mockEnumerableFactory to create a new List<string>():
            mockEnumerableFactory.Setup(mock => mock.Create<List<string>>()).Returns(new List<string>());

            // SETUP _mockServiceFactory to create a new OpenLogic() and return _mockOpenImage.Object instead:
            mockLogicFactory.Setup(mock => mock.Create<OpenLogic>()).Returns(_mockOpenImage.Object);

            // SETUP _mockServiceFactory to create a new CommandParam<string>():
            mockCommandFactory.Setup(mock => mock.Create<CommandParam<string>>()).Returns(new CommandParam<string>());

            // SETUP _mockServiceFactory to create a new CommandParam<IList<string>, EventHandler<StringListEventArgs>():
            mockCommandFactory.Setup(mock => mock.Create<CommandParam<IList<string>, EventHandler<StringListEventArgs>>>()).Returns(new CommandParam<IList<string>, EventHandler<StringListEventArgs>>());

            // SETUP _mockServiceFactory to create a new CommandParam<string, int, int, EventHandler<ImageEventArgs>():
            mockCommandFactory.Setup(mock => mock.Create<CommandParam<string, int, int, EventHandler<ImageEventArgs>>>()).Returns(new CommandParam<string, int, int, EventHandler<ImageEventArgs>>());

            // SETUP _mockServiceFactory to create a new CommandParam<IDisposable>():
            mockCommandFactory.Setup(mock => mock.Create<CommandParam<IDisposable>>()).Returns(new CommandParam<IDisposable>());

            // SETUP _mockServiceFactory to create a new CommandParam<int>():
            mockCommandFactory.Setup(mock => mock.Create<CommandParam<int>>()).Returns(new CommandParam<int>());

            // SETUP mockEventArgsFactory to create a new EventArgs():
            mockEventArgsFactory.Setup(mock => mock.Create<EventArgs>()).Returns(new EventArgs());

            // SETUP mockEventArgsFactory to create a new ImageEventArgs():
            mockEventArgsFactory.Setup(mock => mock.Create<ImageEventArgs>()).Returns(new ImageEventArgs());

            // SETUP mockEventArgsFactory to create a new StringEventArgs():
            mockEventArgsFactory.Setup(mock => mock.Create<StringListEventArgs>()).Returns(new StringListEventArgs());

            #endregion


            #region SERVICE LOCATOR

            // INSTANTIATE _serviceLocator as a new ServiceLocator():
            _serviceLocator = _mockServiceFactory.Object.Create<ServiceLocator>() as IServiceLocator;

            // INITIALISE _serviceLocator with reference to _mockServiceFactory.Object:
            (_serviceLocator as IInitialiseParam<IFactory<IService>>).Initialise(_mockServiceFactory.Object);

            #endregion


            #region OPEN IMAGE

            // DECLARE & INSTANTIATE an IList<string> as a new List<string>():
            IList<string> _tempList = mockEnumerableFactory.Object.Create<List<string>>() as IList<string>;

            // ADD a file path to _tempList:
            _tempList.Add("..\\..\\..\\..\\Server\\Displayables\\FishAssets\\JavaFish.png");

            // SETUP _mockOpenImage so that OpenImage() returns a reference to _tempList:
            _mockOpenImage.Setup(mock => mock.OpenImage()).Returns(_tempList);

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
            _formDictionary = mockEnumerableFactory.Object.Create<Dictionary<int, IDisposable>>() as IDictionary<int, IDisposable>;

            // INITIALISE _controller with reference to _serviceLocator:
            (_controller as IInitialiseParam<IServiceLocator>).Initialise(_serviceLocator);

            // INITIALISE _controller with reference to _formDictionary:
            (_controller as IInitialiseParam<IDictionary<int, IDisposable>>).Initialise(_formDictionary);

            #endregion
        }

        #endregion
    }
}
