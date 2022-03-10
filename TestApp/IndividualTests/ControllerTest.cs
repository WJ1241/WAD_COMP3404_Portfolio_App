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
using Server.GeneralInterfaces;
using Server.InitialisingInterfaces;
using System.Drawing;

namespace TestApp.IndividualTests
{
    /// <summary>
    /// Test Class which checks if Controller is behaving as expected
    /// Authors: William Smith, William Eardley & Declan Kerby-Collins
    /// Date: 10/03/22
    /// </summary>
    [TestClass]
    public class ControllerTest
    {
        /*
                    TASKS
        
        - Test MockFishyHome (Friday)
        - Test MockFishyEdit (Friday)
        - Test the entirety of Controller so far (Saturday)
        - Controller should initialise the ImageServer with Event Handlers for the Form methods (Sunday)

        */

        #region FIELD VARIABLES

        // DECLARE an ISetupApplication, name it '_controller':
        private ISetupApplication _controller;

        // DECLARE a Mock<IDictionary<int, IDisposable>>, name it '_mockDisposableDict':
        private Mock<IDictionary<int, IDisposable>> _mockDisposableDict;

        // DECLARE a Mock<IServiceLocator>, name it '_mockServiceLocator':
        private Mock<IServiceLocator> _mockServiceLocator;

        // DECLARE a Mock<IFactory<ICommand>>, name it '_mockCommandFactory':
        private Mock<IFactory<ICommand>> _mockCommandFactory;

        // DECLARE a Mock<IFactory<IDisposable>>, name it '_mockDisposableFactory':
        private Mock<IFactory<IDisposable>> _mockDisposableFactory;

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

        // DECLARE a Mock<IOpenImage>, name it '_mockOpenImage':
        private Mock<IOpenImage> _mockOpenImage;

        // DECLARE a Mock<ISaveImage>, name it '_mockSaveImage':
        private Mock<ISaveImage> _mockSaveImage;

        // DECLARE a Mock<IDisposable>, name it '_mockFishyHome':
        private Mock<IDisposable> _mockFishyHome;

        // DECLARE a Mock<ICommandInvoker>, name it '_mockCommandInvoker':
        private Mock<ICommandInvoker> _mockCommandInvoker;

        // DECLARE a Mock<ICommandParam<string>>, name it '_createMockEditScrnCmd':
        private Mock<ICommandParam<string>> _mockCreateEditScrnCmd;

        // DECLARE a Mock<ICommandZeroParam>, name it '_mockRemoveDisposableCmd':
        private Mock<ICommandZeroParam> _mockRemoveDisposableCmd;

        #endregion


        #region GETTING SERVICES FROM SERVICE LOCATOR TESTS

        /// <summary>
        /// Checks if Controller retrieves a service from an IServiceLocator successfully
        /// </summary>
        [TestMethod]
        public void Retrieve_Service_From_IServiceLocator()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it '_pass', set to true so test passes if not changed:
            bool _pass = true;

            #endregion


            #region ACT

            // CALL SetupApplication() on Controller:
            _controller.SetupApplication();

            #endregion


            #region ASSERT

            // TRY checking if _mockServiceLocator.GetService<Factory<IDisposable>>() was called:
            try
            {
                // VERIFY that _mockServiceLocator.GetService<Factory<IDisposable>>() has been called ONCE, makes sure that method is not called more than once:
                _mockServiceLocator.Verify(_mock => _mock.GetService<Factory<IDisposable>>(), Times.Once);
            }
            // CATCH MockException from Verify():
            catch (MockException e)
            {
                // SET _pass to false, so that test fails:
                _pass = false;
            }
            // FINALISE try and catch block with test pass/fail:
            finally
            {
                // ASSERT if test has passed, and give corresponding message if _pass is false:
                Assert.IsTrue(_pass, "ERROR: _mockServiceLocator.GetService<Factory<IDisposable>>() has not been called!");
            }

            #endregion

        }

        #endregion


        #region INITIALISE IMAGE SERVER TESTS

        /// <summary>
        /// Checks if Controller initialises an ImageServer with a reference to an IEditImg object successfully
        /// </summary>
        [TestMethod]
        public void Initialise_ImageServer_With_IManageImg()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it '_pass', set to true so test passes if not changed:
            bool _pass = true;

            #endregion


            #region ACT

            // CALL SetupApplication() on Controller:
            _controller.SetupApplication();

            #endregion


            #region ASSERT

            // TRY checking if _mockImageServer.Initialise(_mockImageMgr.Object) was called:
            try
            {
                // VERIFY that _mockImageServer.Initialise(_mockImageMgr.Object) has been called ONCE, makes sure that method is not called more than once:
                _mockImageServer.As<IInitialiseParam<IManageImg>>().Verify(_mock => _mock.Initialise(_mockImageMgr.Object), Times.Once);
            }
            // CATCH MockException from Verify():
            catch (MockException e)
            {
                // SET _pass to false, so that test fails:
                _pass = false;
            }
            // FINALISE try and catch block with test pass/fail:
            finally
            {
                // ASSERT if test has passed, and give corresponding message if _pass is false:
                Assert.IsTrue(_pass, "ERROR: _mockImageServer.Initialise(_mockImageMgr.Object) has not been called!");
            }

            #endregion
        }

        /// <summary>
        /// Checks if Controller initialises an ImageServer with a reference to an IEditImg object successfully
        /// </summary>
        [TestMethod]
        public void Initialise_ImageServer_With_IEditImg()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it '_pass', set to true so test passes if not changed:
            bool _pass = true;

            #endregion


            #region ACT

            // CALL SetupApplication() on Controller:
            _controller.SetupApplication();

            #endregion


            #region ASSERT

            // TRY checking if _mockImageServer.Initialise(_mockImageEditor.Object) was called:
            try
            {
                // VERIFY that Initialise(_mockImageEditor.Object) has been called ONCE, makes sure that method is not called more than once:
                _mockImageServer.As<IInitialiseParam<IEditImg>>().Verify(_mock => _mock.Initialise(_mockImageEditor.Object), Times.Once);
            }
            // CATCH MockException from Verify():
            catch (MockException e)
            {
                // SET _pass to false, so that test fails:
                _pass = false;
            }
            // FINALISE try and catch block with test pass/fail:
            finally
            {
                // ASSERT if test has passed, and give corresponding message if _pass is false:
                Assert.IsTrue(_pass, "ERROR: _mockImageServer.Initialise(_mockImageEditor.Object) has not been called!");
            }

            #endregion
        }

        #endregion


        #region INITIALISE IMAGE MANAGER TESTS


        #endregion


        #region INITIALISE MOCKFISHYHOME TESTS

        /// <summary>
        /// Checks if Controller initialises a MockFishyHome with a reference to an IOpenImage object successfully
        /// </summary>
        [TestMethod]
        public void Initialise_MockFishyHome_With_IOpenImage()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it '_pass', set to true so test passes if not changed:
            bool _pass = true;

            #endregion


            #region ACT

            // CALL SetupApplication() on Controller:
            _controller.SetupApplication();

            #endregion


            #region ASSERT

            // TRY checking if _mockFishyHome.Initialise(_mockOpenImage.Object) was called:
            try
            {
                // VERIFY that Initialise(_mockOpenImage.Object) has been called ONCE, makes sure that method is not called more than once:
                _mockFishyHome.As<IInitialiseParam<IOpenImage>>().Verify(_mock => _mock.Initialise(_mockOpenImage.Object), Times.Once);
            }
            // CATCH MockException from Verify():
            catch (MockException e)
            {
                // SET _pass to false, so that test fails:
                _pass = false;
            }
            // FINALISE try and catch block with test pass/fail:
            finally
            {
                // ASSERT if test has passed, and give corresponding message if _pass is false:
                Assert.IsTrue(_pass, "ERROR: _mockFishyHome.Initialise(_mockOpenImage.Object) has not been called!");
            }

            #endregion
        }


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
            #region OBJECT INSTANTIATIONS (DONE FIRST TO PREVENT REFERENCING ERRORS)

            // INSTANTIATE _mockCommandFactory as a new Mock<IFactory<ICommand>>():
            _mockCommandFactory = new Mock<IFactory<ICommand>>();

            // INSTANTIATE _mockDisposableFactory as a new Mock<IFactory<IDisposable>>():
            _mockDisposableFactory = new Mock<IFactory<IDisposable>>();

            // INSTANTIATE _mockEnumerableFactory as a new Mock<IFactory<IEnumerable>>():
            _mockEnumerableFactory = new Mock<IFactory<IEnumerable>>();

            // INSTANTIATE _mockLogicFactory as a new Mock<IFactory<ILogic>>():
            _mockLogicFactory = new Mock<IFactory<ILogic>>();

            // INSTANTIATE _mockImageServer as a new Mock<IServer>():
            _mockImageServer = new Mock<IServer>();

            // INSTANTIATE _mockImageMgr as a new Mock<IManageImg>():
            _mockImageMgr = new Mock<IManageImg>();

            // SETUP _mockImageMgr to implement IInitialiseParam<IDictionary<String, Image>>:
            _mockImageMgr.As<IInitialiseParam<IDictionary<String, Image>>>();

            // INSTANTIATE _mockImageEditor as a new Mock<IEditImg>():
            _mockImageEditor = new Mock<IEditImg>();

            // INSTANTIATE _mockServiceLocator as a new Mock<IServiceLocator>():
            _mockServiceLocator = new Mock<IServiceLocator>();

            // INSTANTIATE _commandInvoker as a new Mock<ICommandInvoker>():
            _mockCommandInvoker = new Mock<ICommandInvoker>();

            #endregion


            #region MOCK COMMAND INVOKER



            #endregion

            #region MOCK COMMAND FACTORY

            // DECLARE & INSTANTIATE a new Mock<ICommandZeroParam>(), name it '_mockCmd':
            Mock<ICommandZeroParam> _mockCmd = new Mock<ICommandZeroParam>();

            // DECLARE & INSTANTIATE a new Mock<ICommandOneParam<string>>(), name it '_mockStringCmd':
            Mock<ICommandParam<string>> _mockStringCmd = new Mock<ICommandParam<string>>();

            // DECLARE & INSTANTIATE a new Mock<ICommandOneParam<int>>(), name it '_mockIntCmd':
            Mock<ICommandParam<int>> _mockIntCmd = new Mock<ICommandParam<int>>();

            // SETUP _mockCommandFactory so that it can return _mockCmd.Object when Create<CommandZeroParam>() is called:
            _mockCommandFactory.Setup(_mock => _mock.Create<CommandZeroParam>()).Returns(_mockCmd.Object);
            
            // SETUP _mockCommandFactory so that it can return _mockStringCmd.Object when Create<CommandOneParam<string>>() is called:
            _mockCommandFactory.Setup(_mock => _mock.Create<CommandParam<string>>()).Returns(_mockStringCmd.Object);

            // SETUP _mockCommandFactory so that it can return _mockIntCmd.Object when Create<CommandOneParam<int>>() is called:
            _mockCommandFactory.Setup(_mock => _mock.Create<CommandParam<int>>()).Returns(_mockIntCmd.Object);

            #endregion


            #region MOCK FISHY HOME

            // INSTANTIATE _mockFishyHome as a new Mock<IDisposable>():
            _mockFishyHome = new Mock<IDisposable>();

            // INSTANTIATE _mockOpenImage as a new Mock<IOpenImage>():
            _mockOpenImage = new Mock<IOpenImage>();

            // SETUP _mockFishyHome so that it can be initialised with a reference to _mockOpenImage.Object:
            _mockFishyHome.As<IInitialiseParam<IOpenImage>>().Setup(_mock => _mock.Initialise(_mockOpenImage.Object));

            #endregion


            #region MOCK DISPOSABLE FACTORY

            // SETUP _mockDisposableFactory so that it can return _mockFishyHome.Object when Create<FishyHome>() is called:
            _mockDisposableFactory.Setup(_mock => _mock.Create<FishyHome>()).Returns(_mockFishyHome.Object);

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

            // INSTANTIATE _mockSaveImage as a new Mock<ISaveImage>():
            _mockSaveImage = new Mock<ISaveImage>();

            // SETUP _mockLogicFactory so that it can return _mockOpenImage.Object when Create<OpenLogic>() is called:
            _mockLogicFactory.Setup(_mock => _mock.Create<OpenLogic>()).Returns(_mockOpenImage.Object);

            // SETUP _mockLogicFactory so that it can return _mockSaveImage.Object when Create<SaveLogic>() is called:
            _mockLogicFactory.Setup(_mock => _mock.Create<SaveLogic>()).Returns(_mockSaveImage.Object);

            #endregion


            #region MOCK IMAGE SERVER

            // SETUP _mockImageServer so that it can be initialised with a reference to _mockImageMgr.Object:
            _mockImageServer.As<IInitialiseParam<IManageImg>>().Setup(_mock => _mock.Initialise(_mockImageMgr.Object));

            // SETUP _mockImageServer so that it can be initialised with a reference to _mockImageEditor.Object:
            _mockImageServer.As<IInitialiseParam<IEditImg>>().Setup(_mock => _mock.Initialise(_mockImageEditor.Object));

            #endregion


            #region MOCK IMAGE MANAGER

            // SETUP _mockImageMgr so that it can be initialised with an IDictionary<String, Image>():
            _mockImageMgr.As<IInitialiseParam<IDictionary<String, Image>>>().Setup(_mock => _mock.Initialise(_mockEnumerableFactory.Object.Create<Dictionary<String, Image>>() as IDictionary<String, Image>));

            #endregion


            #region MOCK SERVICE LOCATOR

            // SETUP _mockServiceLocator to return _mockCommandFactory.Object when GetService<Factory<ICommand>>() is called:
            _mockServiceLocator.Setup(_mock => _mock.GetService<Factory<ICommand>>()).Returns(_mockCommandFactory.Object);

            // SETUP _mockServiceLocator to return _mockDisposableFactory.Object when GetService<Factory<IDisposable>>() is called:
            _mockServiceLocator.Setup(_mock => _mock.GetService<Factory<IDisposable>>()).Returns(_mockDisposableFactory.Object);

            // SETUP _mockServiceLocator to return _mockLogicFactory.Object when GetService<Factory<ILogic>>() is called:
            _mockServiceLocator.Setup(_mock => _mock.GetService<Factory<ILogic>>()).Returns(_mockLogicFactory.Object);

            // SETUP _mockServiceLocator to return _mockImageServer.Object when GetService<ImageServer>() is called:
            _mockServiceLocator.Setup(_mock => _mock.GetService<ImageServer>()).Returns(_mockImageServer.Object);

            // SETUP _mockServiceLocator to return _mockImageMgr.Object when GetService<ImageMgr>() is called:
            _mockServiceLocator.Setup(_mock => _mock.GetService<ImageMgr>()).Returns(_mockImageMgr.Object);

            // SETUP _mockServiceLocator to return _mockImageEditor.Object when GetService<ImageEditor>() is called:
            _mockServiceLocator.Setup(_mock => _mock.GetService<ImageEditor>()).Returns(_mockImageEditor.Object);

            // SETUP _mockServiceLocator to return _mockCommandInvoker.Object when GetService<CommandInvoker>() is called:
            _mockServiceLocator.Setup(_mock => _mock.GetService<CommandInvoker>()).Returns(_mockCommandInvoker.Object);

            #endregion


            #region CONTROLLER

            // INSTANTIATE _controller as a new Controller():
            _controller = new Controller();

            // INITIALISE _controller with reference to _mockServiceLocator.Object:
            (_controller as IInitialiseParam<IServiceLocator>).Initialise(_mockServiceLocator.Object);

            // INITIALISE _controller with reference to _mockDisposableDict.Object:
            (_controller as IInitialiseParam<IDictionary<int, IDisposable>>).Initialise(_mockDisposableDict.Object);

            // DO THE REST OF INITIALISING

            #endregion
        }

        #endregion
    }
}
