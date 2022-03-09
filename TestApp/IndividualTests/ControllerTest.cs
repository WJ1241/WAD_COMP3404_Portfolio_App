using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using App;
using App.GeneralInterfaces;
using App.Services;
using App.Services.Factories;
using GUI.Logic;
using GUI.Logic.Interfaces;
using Server;
using Server.Commands;
using Server.GeneralInterfaces;
using Server.InitialisingInterfaces;
using System.Drawing;

namespace TestApp.IndividualTests
{
    /// <summary>
    /// Test Class which checks if Controller is behaving as expected
    /// Authors: William Smith, William Eardley & Declan Kerby-Collins
    /// Date: 09/03/22
    /// </summary>
    public class ControllerTest
    {
        /*
                    TASKS
        
        - Setup Everything for Controller (MUST BE DONE TODAY)

        - Test MockFishyHome (Friday)
        - Test MockFishyEdit (Friday)
        - Test the entirety of Controller so far (Saturday)
        - Controller should initialise the ImageServer with Event Handlers for the Form methods (Sunday)

        */

        #region FIELD VARIABLES

        // DECLARE an IController, name it '_controller':
        private IController _controller;

        // DECLARE a Mock<IDictionary<int, IDisposable>>, name it '_mockDisposableDict':
        private Mock<IDictionary<int, IDisposable>> _mockDisposableDict;

        // DECLARE a Mock<IServiceLocator>, name it '_mockServiceLocator':
        private Mock<IServiceLocator> _mockServiceLocator;

        // DECLARE a Mock<IFactory<ICommand>>, name it '_mockCommandFactory':
        private Mock<IFactory<ICommand>> _mockCommandFactory;

        // DECLARE a Mock<IFactory<IFactory<IEnumerable>>, name it '_mockEnumerableFactory':
        private Mock<IFactory<IEnumerable>> _mockEnumerableFactory;

        // DECLARE a Mock<IFactory<ILogic>>, name it '_mockLogicFactory':
        private Mock<IFactory<ILogic>> _mockLogicFactory;

        // DECLARE a Mock<IServer>, name it '_mockImageServer':
        private Mock<IServer> _mockImageServer;

        // DECLARE a Mock<IManageImg>, name it '_mockImageMgr':
        private Mock<IManageImg> _mockImageMgr;

        // DECLARE a Mock<IEditImg>, name it '_mockImageEditor':
        private Mock<IEditImg> _mockImageEditor;

        // DECLARE a Mock<IDisposable>, name it '_mockFishyHome':
        private Mock<IDisposable> _mockFishyHome;

        // DECLARE a Mock<ICommandInvoker>, name it '_mockCommandInvoker':
        private Mock<ICommandInvoker> _mockCommandInvoker;

        // DECLARE a Mock<ICommandOneParam<string>>, name it '_createMockEditScrnCmd':
        private Mock<ICommandOneParam<string>> _mockCreateEditScrnCmd;

        // DECLARE a Mock<ICommandZeroParam>, name it '_mockRemoveDisposableCmd':
        private Mock<ICommandZeroParam> _mockRemoveDisposableCmd;

        #endregion


        #region INITIALISE IMAGE SERVER TESTS



        #endregion


        #region INITIALISE IMAGE MANAGER TESTS


        #endregion


        #region INITIALISE MOCKFISHYHOME TESTS



        #endregion


        #region CREATING MOCKFISHYEDIT TESTS



        #endregion


        #region INITIALISE MOCKFISHYEDIT TESTS



        #endregion


        #region REMOVE DISPOSABLE TESTS



        #endregion


        #region SETUP METHODS

        /// <summary>
        /// Creates and Initialises this class' dependencies
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            #region MOCK SERVICE LOCATOR

            // INSTANTIATE _mockServiceLocator as a new Mock<IServiceLocator>():
            _mockServiceLocator = new Mock<IServiceLocator>();

            // INSTANTIATE _mockCommandFactory as a new Mock<IFactory<ICommand>>():
            _mockCommandFactory = new Mock<IFactory<ICommand>>();

            // INSTANTIATE _mockEnumerableFactory as a new Mock<IFactory<IEnumerable>>():
            _mockEnumerableFactory = new Mock<IFactory<IEnumerable>>();

            // INSTANTIATE _mockLogicFactory as a new Mock<IFactory<ILogic>>():
            _mockLogicFactory = new Mock<IFactory<ILogic>>();

            // INSTANTIATE _mockImageServer as a new Mock<IServer>():
            _mockImageServer = new Mock<IServer>();

            // INSTANTIATE _mockImageMgr as a new Mock<IManageImg>():
            _mockImageMgr = new Mock<IManageImg>();

            // INSTANTIATE _mockImageEditor as a new Mock<IEditImg>():
            _mockImageEditor = new Mock<IEditImg>();

            // INSTANTIATE _commandInvoker as a new Mock<ICommandInvoker>():
            _mockCommandInvoker = new Mock<ICommandInvoker>();

            // SETUP _mockServiceLocator to return _mockCommandFactory when GetService<Factory<ICommand>>() is called:
            _mockServiceLocator.Setup(_mock => _mock.GetService<Factory<ICommand>>()).Returns(_mockCommandFactory.Object);

            // SETUP _mockServiceLocator to return _mockLogicFactory when GetService<Factory<ILogic>>() is called:
            _mockServiceLocator.Setup(_mock => _mock.GetService<Factory<ILogic>>()).Returns(_mockLogicFactory.Object);

            // SETUP _mockServiceLocator to return _mockImageServer when GetService<ImageServer>() is called:
            _mockServiceLocator.Setup(_mock => _mock.GetService<ImageServer>()).Returns(_mockImageServer.Object);

            // SETUP _mockServiceLocator to return _mockImageMgr when GetService<ImageMgr>() is called:
            _mockServiceLocator.Setup(_mock => _mock.GetService<ImageMgr>()).Returns(_mockImageMgr.Object);

            // SETUP _mockServiceLocator to return _mockImageEditor when GetService<ImageEditor>() is called:
            _mockServiceLocator.Setup(_mock => _mock.GetService<ImageEditor>()).Returns(_mockImageEditor.Object);

            // SETUP _mockServiceLocator to return _mockImageEditor when GetService<ImageEditor>() is called:
            _mockServiceLocator.Setup(_mock => _mock.GetService<CommandInvoker>()).Returns(_mockCommandInvoker.Object);

            #endregion


            #region MOCK COMMAND FACTORY

            // DECLARE & INSTANTIATE a new Mock<ICommandZeroParam>(), name it '_mockCmd':
            Mock<ICommandZeroParam> _mockCmd = new Mock<ICommandZeroParam>();

            // DECLARE & INSTANTIATE a new Mock<ICommandOneParam<string>>(), name it '_mockStringCmd':
            Mock<ICommandOneParam<string>> _mockStringCmd = new Mock<ICommandOneParam<string>>();

            // DECLARE & INSTANTIATE a new Mock<ICommandOneParam<int>>(), name it '_mockIntCmd':
            Mock<ICommandOneParam<int>> _mockIntCmd = new Mock<ICommandOneParam<int>>();

            // SETUP _mockCommandFactory so that it can return _mockCmd.Object when Create<CommandZeroParam>() is called:
            _mockCommandFactory.Setup(_mock => _mock.Create<CommandZeroParam>()).Returns(_mockCmd.Object);
            
            // SETUP _mockCommandFactory so that it can return _mockStringCmd.Object when Create<CommandOneParam<string>>() is called:
            _mockCommandFactory.Setup(_mock => _mock.Create<CommandOneParam<string>>()).Returns(_mockStringCmd.Object);

            // SETUP _mockCommandFactory so that it can return _mockIntCmd.Object when Create<CommandOneParam<int>>() is called:
            _mockCommandFactory.Setup(_mock => _mock.Create<CommandOneParam<int>>()).Returns(_mockIntCmd.Object);

            #endregion


            #region MOCK ENUMERABLE FACTORY

            // INSTANTIATE _mockDisposableDict as a new Mock<IDictionary<int, IDisposable>>():
            _mockDisposableDict = new Mock<IDictionary<int, IDisposable>>();

            // DECLARE & INSTANTIATE a new Mock<IDictionary<int, string>>(), name it '_mockFPDict':
            Mock<IDictionary<int, string>> _mockFPDict = new Mock<IDictionary<int, string>>();

            // DECLARE & INSTANTIATE a new Mock<IDictionary<String, Image>>(), name it '_mockImageDict':
            Mock<IDictionary<String, Image>> _mockImageDict = new Mock<IDictionary<string, Image>>();

            // SETUP _mockEnumerableFactory so that it can return _mockDisposableDict.Object when Create<Dictionary<int, IDisposable>>() is called:
            _mockEnumerableFactory.Setup(_mock => _mock.Create<Dictionary<int, IDisposable>>()).Returns(_mockDisposableDict.Object);

            // SETUP _mockEnumerableFactory so that it can return _mockFPDict.Object when Create<Dictionary<int, string>>() is called:
            _mockEnumerableFactory.Setup(_mock => _mock.Create<Dictionary<int, string>>()).Returns(_mockFPDict.Object);

            // SETUP _mockEnumerableFactory so that it can return _mockImageDict.Object when Create<Dictionary<String, Image>>() is called:
            _mockEnumerableFactory.Setup(_mock => _mock.Create<Dictionary<String, IDisposable>>()).Returns(_mockImageDict.Object);

            #endregion


            #region MOCK LOGIC FACTORY

            // DECLARE & INSTANTIATE a new Mock<IOpenImage>():
            Mock<IOpenImage> _mockOpenImage = new Mock<IOpenImage>();

            // DECLARE & INSTANTIATE a new Mock<ISaveImage>():
            Mock<ISaveImage> _mockSaveImage = new Mock<ISaveImage>();

            // SETUP _mockLogicFactory so that it can return _mockOpenImage.Object when Create<OpenLogic>() is called:
            _mockLogicFactory.Setup(_mock => _mock.Create<OpenLogic>()).Returns(_mockOpenImage.Object);

            // SETUP _mockLogicFactory so that it can return _mockSaveImage.Object when Create<SaveLogic>() is called:
            _mockLogicFactory.Setup(_mock => _mock.Create<SaveLogic>()).Returns(_mockSaveImage.Object);

            #endregion


            #region MOCK IMAGE SERVER

            // SETUP _mockImageServer so that it can be initialised with a reference to _mockImageMgr.Object:
            _mockImageServer.Setup(_mock => (_mock as IInitialiseParam<IManageImg>).Initialise(_mockImageMgr.Object));

            // SETUP _mockImageServer so that it can be initialised with a reference to _mockImageEditor.Object:
            _mockImageServer.Setup(_mock => (_mock as IInitialiseParam<IEditImg>).Initialise(_mockImageEditor.Object));

            #endregion


            #region MOCK IMAGE MANAGER

            // SETUP _mockImageMgr so that it can be initialised with an IDictionary<String, Image>():
            _mockImageMgr.Setup(_mock => (_mock as IInitialiseParam<IDictionary<String, Image>>).Initialise((_mockEnumerableFactory.Object.Create<Dictionary<String, Image>>() as Mock<IDictionary<String, Image>>).Object));

            #endregion


            #region CONTROLLER

            // INSTANTIATE _controller as a new Controller():
            _controller = new Controller();

            // DO THE REST OF INITIALISING

            #endregion
        }

        #endregion
    }
}
