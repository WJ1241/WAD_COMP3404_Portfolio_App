using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageProcessor;
using Moq;
using App;
using App.GeneralInterfaces;
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


namespace TestApp.IndividualTests
{
    /// <summary>
    /// Test Class which checks if Controller is behaving as expected
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 23/03/22
    /// 
    /// Services Needed:
    /// - IServiceLocator
    /// - IFactory<ICommand>
    /// - IFactory<EventArgs>
    /// - IFactory<IDisposable>
    /// - IFactory<IEnumerable>
    /// - IFactory<ILogic>
    /// - IServer
    /// - IManageImg
    /// - IEditImg
    /// - ICommandInvoker
    /// 
    /// Creates:
    /// - IDictionary<int, IDisposable>
    /// - IDictionary<int, string>>
    /// - IDictionary<string, EventArgs>
    /// - IDictionary<string, Image>
    /// - IDictionary<string, ICommand>
    /// - IList<string>
    /// - IOpenImage
    /// - IDisposable
    /// - ICommandParam<string>
    /// - ICommandParam<string, int, int>
    /// - ICommandParam<IList<string>>
    /// - ICommandParam<IDisposable>
    /// - ICommandParam<int>
    /// - ImageEventArgs
    /// - StringListEventArgs
    /// 
    /// Initialises:
    /// - MockFishyHome:
    ///     - IDictionary<int, string>
    ///     - IDictionary<string, iCommand>
    ///     - IDictionary<int, string>
    ///     - InvokeCommand Property
    ///     - IOpenImage
    ///     - ICommand
    /// - IOpenImage:
    ///     - IList<string>
    /// - IServer:
    ///     - IDictionary<string, EventArgs>
    ///     - IEditImg
    ///     - IManageImg
    ///     - string & EventArgs
    /// - IManageImg:
    ///     - IDictionary<string, Image>
    /// - Commands:
    ///     - Methods needed
    ///
    /// Subscribes:
    /// - IServer:
    ///     - ImageEventArgs Event
    ///     - StringListEventArgs Event
    /// </summary>
    [TestClass]
    public class ControllerTest
    {
        #region FIELD VARIABLES

        // DECLARE an ISetupApplication, name it '_controller':
        private ISetupApplication _controller;

        // DECLARE a Mock<IDictionary<int, IDisposable>>, name it '_mockDisposableDict':
        private Mock<IDictionary<int, IDisposable>> _mockDisposableDict;

        // DECLARE a Mock<IDictionary<int, string>>, name it '_mockStringDict':
        private Mock<IDictionary<int, string>> _mockStringDict;

        // DECLARE a Mock<IDictionary<string, EventArgs>>, name it '_mockEventArgsDict':
        private Mock<IDictionary<string, EventArgs>> _mockEventArgsDict;

        // DECLARE a Mock<IDictionary<string, Image>>, name it '_mockImageDict':
        private Mock<IDictionary<string, Image>> _mockImageDict;

        // DECLARE a Mock<IDictionary<string, ICommand>>, name it '_mockCommandDict':
        private Mock<IDictionary<string, ICommand>> _mockCommandDict;

        // DECLARE a Mock<IList<string>>, name it '_mockStringList':
        private Mock<IList<string>> _mockStringList;

        // DECLARE a Mock<IServiceLocator>, name it '_mockServiceLocator':
        private Mock<IServiceLocator> _mockServiceLocator;

        // DECLARE a Mock<IFactory<ICommand>>, name it '_mockCommandFactory':
        private Mock<IFactory<ICommand>> _mockCommandFactory;

        // DECLARE a Mock<IFactory<EventArgs>>, name it '_mockEventArgsFactory':
        private Mock<IFactory<EventArgs>> _mockEventArgsFactory;

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

        // DECLARE a Mock<IDisposable>, name it '_mockFishyHome':
        private Mock<IDisposable> _mockFishyHome;

        // DECLARE a Mock<ICommandInvoker>, name it '_mockCommandInvoker':
        private Mock<ICommandInvoker> _mockCommandInvoker;

        // DECLARE a Mock<ICommandParam<string>>, name it '_mockCreateEditScrnCmd':
        private Mock<ICommandParam<string>> _mockCreateEditScrnCmd;

        // DECLARE a Mock<ICommandParam<string, int, int, EventHandler<ImageEventArgs>>>, name it '_mockGetImgCmd':
        private Mock<ICommandParam<string, int, int, EventHandler<ImageEventArgs>>> _mockGetImgCmd;

        // DECLARE a Mock<ICommandParam<IList<string>, EventHandler<StringListEventArgs>>>, name it '_mockLoadCmd':
        private Mock<ICommandParam<IList<string>, EventHandler<StringListEventArgs>>> _mockLoadCmd;

        // DECLARE a Mock<ICommandParam<IDisposable>>, name it '_mockRemoveDisposableCmd':
        private Mock<ICommandParam<IDisposable>> _mockRemoveDisposableCmd;

        // DECLARE a Mock<ICommandParam<int>>, name it '_mockRemoveDisposableIntCmd':
        private Mock<ICommandParam<int>> _mockRemoveDisposableIntCmd;

        // DECLARE a Mock<ImageEventArgs>, name it '_mockImageEventArgs':
        private Mock<ImageEventArgs> _mockImageEventArgs;

        // DECLARE a Mock<StringListEventArgs>, name it '_mockStringListEventArgs':
        private Mock<StringListEventArgs> _mockStringListEventArgs;

        #endregion


        #region GETTING SERVICES FROM SERVICE LOCATOR TESTS

        /// <summary>
        /// Checks if Controller retrieves a service from an IServiceLocator successfully
        /// </summary>
        [TestMethod]
        public void Retrieve_Service_From_IServiceLocator()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it 'pass', set to true so test passes if not changed:
            bool pass = true;

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
                _mockServiceLocator.Verify(mock => mock.GetService<Factory<IDisposable>>(), Times.Once);
            }
            // CATCH MockException from Verify():
            catch (MockException)
            {
                // SET pass to false, so that test fails:
                pass = false;
            }
            // FINALISE try and catch block with test pass/fail:
            finally
            {
                // ASSERT if test has passed, and give corresponding message if pass is false:
                Assert.IsTrue(pass, "ERROR: _mockServiceLocator.GetService<Factory<IDisposable>>() has not been called!");
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

            // DECLARE & INITIALISE a bool, name it 'pass', set to true so test passes if not changed:
            bool pass = true;

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
                _mockImageServer.As<IInitialiseParam<IManageImg>>().Verify(mock => mock.Initialise(_mockImageMgr.Object), Times.Once);
            }
            // CATCH MockException from Verify():
            catch (MockException)
            {
                // SET pass to false, so that test fails:
                pass = false;
            }
            // FINALISE try and catch block with test pass/fail:
            finally
            {
                // ASSERT if test has passed, and give corresponding message if pass is false:
                Assert.IsTrue(pass, "ERROR: _mockImageServer.Initialise(_mockImageMgr.Object) has not been called!");
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

            // DECLARE & INITIALISE a bool, name it 'pass', set to true so test passes if not changed:
            bool pass = true;

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
                _mockImageServer.As<IInitialiseParam<IEditImg>>().Verify(mock => mock.Initialise(_mockImageEditor.Object), Times.Once);
            }
            // CATCH MockException from Verify():
            catch (MockException)
            {
                // SET pass to false, so that test fails:
                pass = false;
            }
            // FINALISE try and catch block with test pass/fail:
            finally
            {
                // ASSERT if test has passed, and give corresponding message if pass is false:
                Assert.IsTrue(pass, "ERROR: _mockImageServer.Initialise(_mockImageEditor.Object) has not been called!");
            }

            #endregion
        }

        /// <summary>
        /// Checks if Controller initialises an ImageServer with a reference to an IDictionary<string, EventArgs> object successfully
        /// </summary>
        [TestMethod]
        public void Initialise_ImageServer_With_EventArgs_Dictionary()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it 'pass', set to true so test passes if not changed:
            bool pass = true;

            #endregion


            #region ACT

            // CALL SetupApplication() on Controller:
            _controller.SetupApplication();

            #endregion


            #region ASSERT

            // TRY checking if _mockImageServer.Initialise(_mockImageEventArgs.Object) was called:
            try
            {
                // VERIFY that Initialise(_mockEventArgsDict.Object) has been called ONCE, makes sure that method is not called more than once:
                _mockImageServer.As<IInitialiseParam<IDictionary<string, EventArgs>>>().Verify(mock => mock.Initialise(_mockEventArgsDict.Object), Times.Once);
            }
            // CATCH MockException from Verify():
            catch (MockException)
            {
                // SET pass to false, so that test fails:
                pass = false;
            }
            // FINALISE try and catch block with test pass/fail:
            finally
            {
                // ASSERT if test has passed, and give corresponding message if pass is false:
                Assert.IsTrue(pass, "ERROR: _mockImageServer.Initialise(_mockImageEventArgs.Object) has not been called!");
            }

            #endregion
        }

        /// <summary>
        /// Checks if Controller initialises an ImageServer with a reference to an EventArgs object successfully
        /// </summary>
        [TestMethod]
        public void Initialise_ImageServer_With_EventArgs()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it 'pass', set to true so test passes if not changed:
            bool pass = true;

            #endregion


            #region ACT

            // CALL SetupApplication() on Controller:
            _controller.SetupApplication();

            #endregion


            #region ASSERT

            // TRY checking if _mockImageServer.Initialise(_mockImageEventArgs.Object) was called:
            try
            {
                // VERIFY that Initialise(_mockImageEventArgs.Object) has been called ONCE, makes sure that method is not called more than once:
                _mockImageServer.As<IInitialiseParam<string, EventArgs>>().Verify(mock => mock.Initialise("Image", _mockImageEventArgs.Object), Times.Once);
            }
            // CATCH MockException from Verify():
            catch (MockException)
            {
                // SET pass to false, so that test fails:
                pass = false;
            }
            // FINALISE try and catch block with test pass/fail:
            finally
            {
                // ASSERT if test has passed, and give corresponding message if pass is false:
                Assert.IsTrue(pass, "ERROR: _mockImageServer.Initialise('Image', _mockImageEventArgs.Object) has not been called!");
            }

            #endregion
        }

        #endregion


        #region INITIALISE IMAGE MANAGER TESTS

        /// <summary>
        /// Checks if Controller initialises an ImageMgr with a reference to an IDictionary<string, Image> object successfully
        /// </summary>
        [TestMethod]
        public void Initialise_ImageMgr_With_Image_Dictionary()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it 'pass', set to true so test passes if not changed:
            bool pass = true;

            #endregion


            #region ACT

            // CALL SetupApplication() on Controller:
            _controller.SetupApplication();

            #endregion


            #region ASSERT

            // TRY checking if _mockImageMgr.Initialise(_mockImageDict.Object) was called:
            try
            {
                // VERIFY that Initialise(_mockImageDict.Object) has been called ONCE, makes sure that method is not called more than once:
                _mockImageMgr.As<IInitialiseParam<IDictionary<string, Image>>>().Verify(mock => mock.Initialise(_mockImageDict.Object), Times.Once);
            }
            // CATCH MockException from Verify():
            catch (MockException)
            {
                // SET pass to false, so that test fails:
                pass = false;
            }
            // FINALISE try and catch block with test pass/fail:
            finally
            {
                // ASSERT if test has passed, and give corresponding message if pass is false:
                Assert.IsTrue(pass, "ERROR: _mockImageMgr.Initialise(_mockImageDict.Object) has not been called!");
            }

            #endregion
        }

        #endregion


        #region INITIALISE IMAGE EDITOR TESTS

        /// <summary>
        /// Checks if Controller initialises an ImageEditor with a reference to a ImageFactory object successfully
        /// </summary>
        [TestMethod]
        public void Initialise_ImageEditor_With_ImageFactory()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it 'pass', set to true so test passes if not changed:
            bool pass = true;

            #endregion


            #region ACT

            // CALL SetupApplication() on Controller:
            _controller.SetupApplication();

            #endregion


            #region ASSERT

            // TRY checking if _mockImageEditor.Initialise(It.IsAny<ImageFactory>()) was called:
            try
            {
                // VERIFY that Initialise(It.IsAny<ImageFactory>()) has been called ONCE, makes sure that method is not called more than once:
                _mockImageEditor.As<IInitialiseParam<ImageFactory>>().Verify(mock => mock.Initialise(It.IsAny<ImageFactory>()), Times.Once);
            }
            // CATCH MockException from Verify():
            catch (MockException)
            {
                // SET pass to false, so that test fails:
                pass = false;
            }
            // FINALISE try and catch block with test pass/fail:
            finally
            {
                // ASSERT if test has passed, and give corresponding message if pass is false:
                Assert.IsTrue(pass, "ERROR: _mockImageEditor.Initialise(It.IsAny<ImageFactory>()) has not been called!");
            }

            #endregion
        }

        #endregion


        #region INITIALISE MOCKFISHYHOME TESTS

        /// <summary>
        /// Checks if Controller initialises a MockFishyHome with a reference to an IOpenImage object successfully
        /// </summary>
        [TestMethod]
        public void Initialise_MockFishyHome_With_IOpenImage()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it 'pass', set to true so test passes if not changed:
            bool pass = true;

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
                _mockFishyHome.As<IInitialiseParam<IOpenImage>>().Verify(mock => mock.Initialise(_mockOpenImage.Object), Times.Once);
            }
            // CATCH MockException from Verify():
            catch (MockException)
            {
                // SET pass to false, so that test fails:
                pass = false;
            }
            // FINALISE try and catch block with test pass/fail:
            finally
            {
                // ASSERT if test has passed, and give corresponding message if pass is false:
                Assert.IsTrue(pass, "ERROR: _mockFishyHome.Initialise(_mockOpenImage.Object) has not been called!");
            }

            #endregion
        }

        /// <summary>
        /// Checks if Controller initialises a MockFishyHome with a reference to an IDictionary<int, string> object successfully
        /// </summary>
        [TestMethod]
        public void Initialise_MockFishyHome_With_String_Dictionary()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it 'pass', set to true so test passes if not changed:
            bool pass = true;

            #endregion


            #region ACT

            // CALL SetupApplication() on Controller:
            _controller.SetupApplication();

            #endregion


            #region ASSERT

            // TRY checking if _mockFishyHome.Initialise(_mockStringDict.Object) was called:
            try
            {
                // VERIFY that Initialise(_mockStringDict.Object) has been called ONCE, makes sure that method is not called more than once:
                _mockFishyHome.As<IInitialiseParam<IDictionary<int, string>>>().Verify(mock => mock.Initialise(_mockStringDict.Object), Times.Once);
            }
            // CATCH MockException from Verify():
            catch (MockException)
            {
                // SET pass to false, so that test fails:
                pass = false;
            }
            // FINALISE try and catch block with test pass/fail:
            finally
            {
                // ASSERT if test has passed, and give corresponding message if pass is false:
                Assert.IsTrue(pass, "ERROR: _mockFishyHome.Initialise(_mockStringDict.Object) has not been called!");
            }

            #endregion
        }

        /// <summary>
        /// Checks if Controller initialises a MockFishyHome with a reference to an ICommand<string, int, int> object successfully
        /// </summary>
        [TestMethod]
        public void Initialise_MockFishyHome_With_String_Int_Int_Command()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it 'pass', set to true so test passes if not changed:
            bool pass = true;

            #endregion


            #region ACT

            // CALL SetupApplication() on Controller:
            _controller.SetupApplication();

            #endregion


            #region ASSERT

            // TRY checking if _mockFishyHome.Initialise(_mockGetImgCmd.Object) was called:
            try
            {
                // VERIFY that Initialise(_mockStringDict.Object) has been called ONCE, makes sure that method is not called more than once:
                _mockFishyHome.As<IInitialiseParam<ICommand>>().Verify(mock => mock.Initialise(_mockGetImgCmd.Object), Times.Once);
            }
            // CATCH MockException from Verify():
            catch (MockException)
            {
                // SET pass to false, so that test fails:
                pass = false;
            }
            // FINALISE try and catch block with test pass/fail:
            finally
            {
                // ASSERT if test has passed, and give corresponding message if pass is false:
                Assert.IsTrue(pass, "ERROR: _mockFishyHome.Initialise(_mockGetImgCmd.Object) has not been called!");
            }

            #endregion
        }

        /// <summary>
        /// Checks if Controller sets MockFishyHome's InvokeCommand Property successfully
        /// </summary>
        [TestMethod]
        public void Set_InvokeCommand_Property_Of_MockFishyHome()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it 'pass', set to true so test passes if not changed:
            bool pass = true;

            #endregion


            #region ACT

            // CALL SetupApplication() on Controller:
            _controller.SetupApplication();

            #endregion


            #region ASSERT

            // TRY checking if _mockFishyHome.InvokeCommand was set:
            try
            {
                // VERIFY that InvokeCommand.Set has been set ONCE, makes sure that method is not set more than once:
                _mockFishyHome.As<ICommandSender>().VerifySet(mock => mock.InvokeCommand = _mockCommandInvoker.Object.InvokeCommand, Times.Once);
            }
            // CATCH MockException from Verify():
            catch (MockException)
            {
                // SET pass to false, so that test fails:
                pass = false;
            }
            // FINALISE try and catch block with test pass/fail:
            finally
            {
                // ASSERT if test has passed, and give corresponding message if pass is false:
                Assert.IsTrue(pass, "ERROR: _mockFishyHome.InvokeCommand has not been set!");
            }

            #endregion
        }

        #endregion


        #region INITIALISE IOPENIMAGE TESTS

        /// <summary>
        /// Checks if Controller initialises an IOpenImage with a reference to an IList<string> object successfully
        /// </summary>
        [TestMethod]
        public void Initialise_IOpenImage_With_String_List()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it 'pass', set to true so test passes if not changed:
            bool pass = true;

            #endregion


            #region ACT

            // CALL SetupApplication() on Controller:
            _controller.SetupApplication();

            #endregion


            #region ASSERT

            // TRY checking if _mockOpenImage.Initialise(_mockStringList.Object) was called:
            try
            {
                // VERIFY that Initialise(_mockStringList.Object) has been called ONCE, makes sure that method is not called more than once:
                _mockOpenImage.As<IInitialiseParam<IList<string>>>().Verify(mock => mock.Initialise(_mockStringList.Object), Times.Once);
            }
            // CATCH MockException from Verify():
            catch (MockException)
            {
                // SET pass to false, so that test fails:
                pass = false;
            }
            // FINALISE try and catch block with test pass/fail:
            finally
            {
                // ASSERT if test has passed, and give corresponding message if pass is false:
                Assert.IsTrue(pass, "ERROR: _mockOpenImage.Initialise(_mockStringList.Object) has not been called!");
            }

            #endregion
        }

        #endregion


        #region SETTING UP COMMAND TESTS

        /// <summary>
        /// Checks if Controller sets ICommandParam's MethodRef Property successfully
        /// </summary>
        [TestMethod]
        public void Set_MethodRef_Property_Of_ICommandParam()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it 'pass', set to true so test passes if not changed:
            bool pass = true;

            #endregion


            #region ACT

            // CALL SetupApplication() on Controller:
            _controller.SetupApplication();

            #endregion


            #region ASSERT

            // TRY checking if _mockGetImgCmd.MethodRef was set:
            try
            {
                // VERIFY that MethodRef.Set has been set ONCE, makes sure that method is not set more than once:
                _mockGetImgCmd.VerifySet(mock => mock.MethodRef = _mockImageServer.Object.GetImage, Times.Once);
            }
            // CATCH MockException from Verify():
            catch (MockException)
            {
                // SET pass to false, so that test fails:
                pass = false;
            }
            // FINALISE try and catch block with test pass/fail:
            finally
            {
                // ASSERT if test has passed, and give corresponding message if pass is false:
                Assert.IsTrue(pass, "ERROR: _mockGetImgCmd.MethodRef has not been set!");
            }

            #endregion
        }

        /// <summary>
        /// Checks if Controller sets IName's Name Property successfully
        /// </summary>
        [TestMethod]
        public void Set_Name_Property_Of_IName()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it 'pass', set to true so test passes if not changed:
            bool pass = true;

            #endregion


            #region ACT

            // CALL SetupApplication() on Controller:
            _controller.SetupApplication();

            #endregion


            #region ASSERT

            // TRY checking if _mockGetImgCmd.Name was set:
            try
            {
                // VERIFY that MethodRef.Set has been set ONCE, makes sure that method is not set more than once:
                _mockGetImgCmd.As<IName>().VerifySet(mock => mock.Name = "GetImage", Times.Once);
            }
            // CATCH MockException from Verify():
            catch (MockException)
            {
                // SET pass to false, so that test fails:
                pass = false;
            }
            // FINALISE try and catch block with test pass/fail:
            finally
            {
                // ASSERT if test has passed, and give corresponding message if pass is false:
                Assert.IsTrue(pass, "ERROR: _mockGetImgCmd.Name has not been set!");
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
            #region OBJECT INSTANTIATIONS (DONE FIRST TO PREVENT REFERENCING ERRORS)

            //// SOME OBJECTS ARE INSTANTIATED EARLIER THAN OTHERS, THIS IS DUE
            //// TO MOCKS IMPLEMENTING AN INTERFACE TO HAPPEN BEFORE AN OBJECT IS REFERENCED

            // INSTANTIATE _controller as a new Controller():
            _controller = new Controller();

            // INSTANTIATE _mockCommandFactory as a new Mock<IFactory<ICommand>>():
            _mockCommandFactory = new Mock<IFactory<ICommand>>();

            // INSTANTIATE _mockCommandFactory as a new Mock<IFactory<EventArgs>>():
            _mockEventArgsFactory = new Mock<IFactory<EventArgs>>();

            // INSTANTIATE _mockDisposableFactory as a new Mock<IFactory<IDisposable>>():
            _mockDisposableFactory = new Mock<IFactory<IDisposable>>();

            // INSTANTIATE _mockEnumerableFactory as a new Mock<IFactory<IEnumerable>>():
            _mockEnumerableFactory = new Mock<IFactory<IEnumerable>>();

            // INSTANTIATE _mockLogicFactory as a new Mock<IFactory<ILogic>>():
            _mockLogicFactory = new Mock<IFactory<ILogic>>();


            #region IMAGE SERVER 

            // INSTANTIATE _mockImageServer as a new Mock<IServer>():
            _mockImageServer = new Mock<IServer>();

            // SETUP _mockImageServer to implement IInitialiseParam<IManageImg>:
            _mockImageServer.As<IInitialiseParam<IManageImg>>();

            // SETUP _mockImageServer to implement IInitialiseParam<IEditImg>:
            _mockImageServer.As<IInitialiseParam<IEditImg>>();

            // SETUP _mockImageServer to implement IInitialiseParam<IDictionary<string, EventArgs>>:
            _mockImageServer.As<IInitialiseParam<IDictionary<string, EventArgs>>>();

            // SETUP _mockImageServer to implement IInitialiseParam<string, EventArgs>:
            _mockImageServer.As<IInitialiseParam<string, EventArgs>>();

            #endregion


            // INSTANTIATE _mockImageEditor as a new Mock<IEditImg>():
            _mockImageEditor = new Mock<IEditImg>();

            // INSTANTIATE _mockServiceLocator as a new Mock<IServiceLocator>():
            _mockServiceLocator = new Mock<IServiceLocator>();

            // INSTANTIATE _commandInvoker as a new Mock<ICommandInvoker>():
            _mockCommandInvoker = new Mock<ICommandInvoker>();

            // INSTANTIATE _mockStringDict as a new Mock<IDictionary<int, string>>(): 
            _mockStringDict = new Mock<IDictionary<int, string>>();

            // INSTANTIATE _mockEventArgsDict as a new Mock<IDictionary<string, EventArgs>>(): 
            _mockEventArgsDict = new Mock<IDictionary<string, EventArgs>>();

            // INSTANTIATE _mockCommandDict as a new Mock<IDictionary<string, ICommand>>(): 
            _mockCommandDict = new Mock<IDictionary<string, ICommand>>();

            // INSTANTIATE _mockStringList as a new Mock<IList<string>>(): 
            _mockStringList = new Mock<IList<string>>();

            #endregion


            #region MOCK COMMAND FACTORY

            // INSTANTIATE _mockStringCmd as a new Mock<ICommandOneParam<string>>():
            _mockCreateEditScrnCmd = new Mock<ICommandParam<string>>();

            // SETUP _mockCreateEditScrnCmd so that its Name Property can be given a string value:
            _mockCreateEditScrnCmd.As<IName>().SetupSet(mock => mock.Name = "");

            // SETUP _mockCreateEditScrnCmd so that its MethodRef Property holds reference to _controller.CreateEditScrn():
            _mockCreateEditScrnCmd.SetupSet(mock => mock.MethodRef = (_controller as IController).CreateEditScrn).Verifiable();

            // INSTANTIATE _mockGetImgCmd as a new Mock<ICommandParam<string, int, int, EventHandler<ImageEventArgs>>>():
            _mockGetImgCmd = new Mock<ICommandParam<string, int, int, EventHandler<ImageEventArgs>>>();

            // SETUP _mockGetImgCmd so that its Name Property can be given a string value:
            _mockGetImgCmd.As<IName>().SetupSet(mock => mock.Name = "GetImage");

            // SETUP _mockGetImgCmd so that its MethodRef Property holds reference to _mockImageServer.Object.GetImage():
            _mockGetImgCmd.SetupSet(mock => mock.MethodRef = _mockImageServer.Object.GetImage);

            // INSTANTIATE _mockLoadCmd as a new Mock<ICommandParam<IList<string>, EventHandler<StringListEventArgs>>>():
            _mockLoadCmd = new Mock<ICommandParam<IList<string>, EventHandler<StringListEventArgs>>>();

            // SETUP _mockLoadCmd so that its Name Property can be given a string value:
            _mockLoadCmd.As<IName>().SetupSet(mock => mock.Name = "Load");

            // SETUP _mockLoadCmd so that its MethodRef Property holds reference to _mockImageServer.Object.Load:
            _mockLoadCmd.SetupSet(mock => mock.MethodRef = _mockImageServer.Object.Load);

            // INSTANTIATE _mockRemoveDisposableCmd as a new Mock<ICommandParam<IDisposable>>():
            _mockRemoveDisposableCmd = new Mock<ICommandParam<IDisposable>>();

            // SETUP _mockRemoveDisposableCmd so that its Name Property can be given a string value:
            _mockRemoveDisposableCmd.As<IName>().SetupSet(mock => mock.Name = "");

            // SETUP _mockRemoveDisposableCmd so that its MethodRef Property holds reference to _controller.DisposableRemoval(IDisposable):
            _mockRemoveDisposableCmd.SetupSet(mock => mock.MethodRef = (_controller as IController).DisposableRemoval);

            // INSTANTIATE _mockRemoveDisposableIntCmd as a new Mock<ICommandParam<int>>():
            _mockRemoveDisposableIntCmd = new Mock<ICommandParam<int>>();

            // SETUP _mockRemoveDisposableIntCmd so that its Name Property can be given a string value:
            _mockRemoveDisposableIntCmd.As<IName>().SetupSet(mock => mock.Name = "");

            // SETUP _mockRemoveDisposableIntCmd so that its MethodRef Property holds reference to _controller.DisposableRemoval(int):
            _mockRemoveDisposableIntCmd.SetupSet(mock => mock.MethodRef = (_controller as IController).DisposableRemoval);

            // SETUP _mockCommandFactory so that it can return _mockCreateEditScrnCmd.Object when Create<CommandParam<string>>() is called:
            _mockCommandFactory.Setup(mock => mock.Create<CommandParam<string>>()).Returns(_mockCreateEditScrnCmd.Object);

            // SETUP _mockCommandFactory so that it can return _mockGetImgCmd.Object when Create<CommandParam<string, int, int, EventHandler<ImageEventArgs>>>() is called:
            _mockCommandFactory.Setup(mock => mock.Create<CommandParam<string, int, int, EventHandler<ImageEventArgs>>>()).Returns(_mockGetImgCmd.Object);

            // SETUP _mockCommandFactory so that it can return _mockLoadCmd.Object when Create<CommandParam<IList<string>, EventHandler<StringListEventArgs>>>() is called:
            _mockCommandFactory.Setup(mock => mock.Create<CommandParam<IList<string>, EventHandler<StringListEventArgs>>>()).Returns(_mockLoadCmd.Object);

            // SETUP _mockCommandFactory so that it can return _mockRemoveDisposableCmd.Object when Create<CommandParam<IDisposable>>() is called:
            _mockCommandFactory.Setup(mock => mock.Create<CommandParam<IDisposable>>()).Returns(_mockRemoveDisposableCmd.Object);

            // SETUP _mockCommandFactory so that it can return _mockRemoveDisposableIntCmd.Object when Create<CommandParam<int>>() is called:
            _mockCommandFactory.Setup(mock => mock.Create<CommandParam<int>>()).Returns(_mockRemoveDisposableIntCmd.Object);

            #endregion


            #region MOCK OPEN IMAGE

            // INSTANTIATE _mockOpenImage as a new Mock<IOpenImage>():
            _mockOpenImage = new Mock<IOpenImage>();

            // SETUP _mockOpenImage so that it can be initialised with a reference to _mockStringList.Object:
            _mockOpenImage.As<IInitialiseParam<IList<string>>>().Setup(mock => mock.Initialise(_mockStringList.Object));

            #endregion


            #region MOCK FISHY HOME

            // INSTANTIATE _mockFishyHome as a new Mock<IDisposable>():
            _mockFishyHome = new Mock<IDisposable>();

            // SETUP mockFishyHome so that it implements IEventListener<ImageEventArgs>:
            _mockFishyHome.As<IEventListener<ImageEventArgs>>();

            // SETUP mockFishyHome so that it implements IEventListener<StringListEventArgs>:
            _mockFishyHome.As<IEventListener<StringListEventArgs>>();

            // SETUP _mockFishyHome so that its InvokeCommand Property holds reference to _mockCommandInvoker.Object.InvokeCommand():
            _mockFishyHome.As<ICommandSender>().SetupSet(mock => mock.InvokeCommand = _mockCommandInvoker.Object.InvokeCommand);

            // SETUP _mockFishyHome so that it can be initialised with a reference to _mockOpenImage.Object:
            _mockFishyHome.As<IInitialiseParam<IOpenImage>>().Setup(mock => mock.Initialise(_mockOpenImage.Object));

            // SETUP _mockFishyHome so that it can be initialised with a reference to _mockStringDict.Object:
            _mockFishyHome.As<IInitialiseParam<IDictionary<int, string>>>().Setup(mock => mock.Initialise(_mockStringDict.Object));

            // SETUP _mockFishyHome so that it can be initialised with a reference to _mockCommandDict.Object:
            _mockFishyHome.As<IInitialiseParam<IDictionary<string, ICommand>>>().Setup(mock => mock.Initialise(_mockCommandDict.Object));

            // SETUP _mockFishyHome so that it can be initialised with a reference to _mockCreateEditScrnCmd.Object:
            _mockFishyHome.As<IInitialiseParam<ICommand>>().Setup(mock => mock.Initialise(_mockCreateEditScrnCmd.Object));

            #endregion


            #region MOCK EVENTARGS FACTORY

            // INSTANTIATE _mockStringListEventArgs as a new Mock<ImageEventArgs>():
            _mockImageEventArgs = new Mock<ImageEventArgs>();

            // INSTANTIATE _mockStringListEventArgs as a new Mock<StringListEventArgs>():
            _mockStringListEventArgs = new Mock<StringListEventArgs>();

            // SETUP _mockEventArgsFactory so that it can return _mockImageEventArgs.Object when Create<ImageEventArgs>() is called:
            _mockEventArgsFactory.Setup(mock => mock.Create<ImageEventArgs>()).Returns(_mockImageEventArgs.Object);

            // SETUP _mockEventArgsFactory so that it can return _mockStringListEventArgs.Object when Create<StringListEventArgs>() is called:
            _mockEventArgsFactory.Setup(mock => mock.Create<StringListEventArgs>()).Returns(_mockStringListEventArgs.Object);

            #endregion


            #region MOCK DISPOSABLE FACTORY

            // SETUP _mockDisposableFactory so that it can return _mockFishyHome.Object when Create<FishyHome>() is called:
            _mockDisposableFactory.Setup(mock => mock.Create<FishyHome>()).Returns(_mockFishyHome.Object);

            #endregion


            #region MOCK ENUMERABLE FACTORY

            // INSTANTIATE _mockDisposableDict as a new Mock<IDictionary<int, IDisposable>>():
            _mockDisposableDict = new Mock<IDictionary<int, IDisposable>>();

            // SETUP _mockDisposableDict so that it adds _mockFishyHome.Object at index 0:
            _mockDisposableDict.Setup(mock => mock[0]).Returns(_mockFishyHome.Object);

            // INSTANTIATE _mockImageDict as a new Mock<IDictionary<string, Image>>(): 
            _mockImageDict = new Mock<IDictionary<string, Image>>();

            // SETUP _mockEnumerableFactory so that it can return _mockDisposableDict.Object when Create<Dictionary<int, IDisposable>>() is called:
            _mockEnumerableFactory.Setup(mock => mock.Create<Dictionary<int, IDisposable>>()).Returns(_mockDisposableDict.Object);

            // SETUP _mockEnumerableFactory so that it can return _mockEventArgsDict.Object when Create<Dictionary<string, EventArgs>>() is called:
            _mockEnumerableFactory.Setup(mock => mock.Create<Dictionary<string, EventArgs>>()).Returns(_mockEventArgsDict.Object);

            // SETUP _mockEnumerableFactory so that it can return _mockStringDict.Object when Create<Dictionary<int, string>>() is called:
            _mockEnumerableFactory.Setup(mock => mock.Create<Dictionary<int, string>>()).Returns(_mockStringDict.Object);

            // SETUP _mockEnumerableFactory so that it can return _mockCommandDict when Create<Dictionary<string, ICommand>>() is called:
            _mockEnumerableFactory.Setup(mock => mock.Create<Dictionary<string, ICommand>>()).Returns(_mockCommandDict.Object);

            // SETUP _mockEnumerableFactory so that it can return _mockImageDict.Object when Create<Dictionary<String, Image>>() is called:
            _mockEnumerableFactory.Setup(mock => mock.Create<Dictionary<string, Image>>()).Returns(_mockImageDict.Object);

            // SETUP _mockEnumerableFactory so that it can return _mockStringList.Object when Create<List<string>>() is called:
            _mockEnumerableFactory.Setup(mock => mock.Create<List<string>>()).Returns(_mockStringList.Object);

            #endregion


            #region MOCK LOGIC FACTORY

            // SETUP _mockLogicFactory so that it can return _mockOpenImage.Object when Create<OpenLogic>() is called:
            _mockLogicFactory.Setup(mock => mock.Create<OpenLogic>()).Returns(_mockOpenImage.Object);

            #endregion


            #region MOCK IMAGE SERVER

            // INSTANTIATE _mockImageMgr as a new Mock<IManageImg>():
            _mockImageMgr = new Mock<IManageImg>();

            // SETUP _mockImageMgr to implement IInitialiseParam<IDictionary<string, Image>>:
            _mockImageMgr.As<IInitialiseParam<IDictionary<string, Image>>>();

            // SETUP _mockImageMgr to implement IInitialiseParam<ImageFactory>:
            _mockImageEditor.As<IInitialiseParam<ImageFactory>>();

            // SETUP _mockImageServer so that it can be initialised with a reference to _mockImageMgr.Object:
            _mockImageServer.As<IInitialiseParam<IManageImg>>().Setup(mock => mock.Initialise(_mockImageMgr.Object));

            // SETUP _mockImageServer so that it can be initialised with a reference to _mockImageEditor.Object:
            _mockImageServer.As<IInitialiseParam<IEditImg>>().Setup(mock => mock.Initialise(_mockImageEditor.Object));

            // SETUP _mockImageServer so that it can be initialised with a reference to _mockEventArgsDict.Object:
            _mockImageServer.As<IInitialiseParam<IDictionary<string, EventArgs>>>().Setup(mock => mock.Initialise(_mockEventArgsDict.Object));

            // SETUP _mockImageServer so that it can be initialised with a string and a reference to _mockImageEventArgs.Object:
            _mockImageServer.As<IInitialiseParam<string, EventArgs>>().Setup(mock => mock.Initialise("", _mockImageEventArgs.Object));

            // SETUP _mockImageServer so that it can be initialised with a string and a reference to _mockStringListEventArgs.Object:
            _mockImageServer.As<IInitialiseParam<string, EventArgs>>().Setup(mock => mock.Initialise("", _mockStringListEventArgs.Object));

            #endregion


            #region MOCK IMAGE MANAGER

            // SETUP _mockImageMgr so that it can be initialised with an IDictionary<String, Image>():
            _mockImageMgr.As<IInitialiseParam<IDictionary<string, Image>>>().Setup(mock => mock.Initialise(_mockImageDict.Object));

            #endregion


            #region MOCK IMAGE EDITOR

            // SETUP _mockImageMgr so that it can be initialised with a new ImageFactory object:
            // USING IMAGE PROCESSOR API, DOES NOT HAVE PARAMETERLESS CONSTRUCTOR THEREFORE IT NEEDS ACTUAL OBJECT RATHER THAN MOCK
            _mockImageEditor.As<IInitialiseParam<ImageFactory>>().Setup(mock => mock.Initialise(new ImageFactory(false)));

            #endregion


            #region MOCK SERVICE LOCATOR

            // SETUP _mockServiceLocator to return _mockCommandFactory.Object when GetService<Factory<ICommand>>() is called:
            _mockServiceLocator.Setup(mock => mock.GetService<Factory<ICommand>>()).Returns(_mockCommandFactory.Object);

            // SETUP _mockServiceLocator to return _mockEventArgsFactory.Object when GetService<Factory<EventArgs>>() is called:
            _mockServiceLocator.Setup(mock => mock.GetService<Factory<EventArgs>>()).Returns(_mockEventArgsFactory.Object);

            // SETUP _mockServiceLocator to return _mockDisposableFactory.Object when GetService<Factory<IDisposable>>() is called:
            _mockServiceLocator.Setup(mock => mock.GetService<Factory<IDisposable>>()).Returns(_mockDisposableFactory.Object);

            // SETUP _mockServiceLocator to return _mockEnumerableFactory.Object when GetService<Factory<IEnumerable>>() is called:
            _mockServiceLocator.Setup(mock => mock.GetService<Factory<IEnumerable>>()).Returns(_mockEnumerableFactory.Object);

            // SETUP _mockServiceLocator to return _mockLogicFactory.Object when GetService<Factory<ILogic>>() is called:
            _mockServiceLocator.Setup(mock => mock.GetService<Factory<ILogic>>()).Returns(_mockLogicFactory.Object);

            // SETUP _mockServiceLocator to return _mockImageServer.Object when GetService<ImageServer>() is called:
            _mockServiceLocator.Setup(mock => mock.GetService<ImageServer>()).Returns(_mockImageServer.Object);

            // SETUP _mockServiceLocator to return _mockImageMgr.Object when GetService<ImageMgr>() is called:
            _mockServiceLocator.Setup(mock => mock.GetService<ImageMgr>()).Returns(_mockImageMgr.Object);

            // SETUP _mockServiceLocator to return _mockImageEditor.Object when GetService<ImageEditor>() is called:
            _mockServiceLocator.Setup(mock => mock.GetService<ImageEditor>()).Returns(_mockImageEditor.Object);

            // SETUP _mockServiceLocator to return _mockCommandInvoker.Object when GetService<CommandInvoker>() is called:
            _mockServiceLocator.Setup(mock => mock.GetService<CommandInvoker>()).Returns(_mockCommandInvoker.Object);

            #endregion


            #region CONTROLLER

            // INITIALISE _controller with reference to _mockServiceLocator.Object:
            (_controller as IInitialiseParam<IServiceLocator>).Initialise(_mockServiceLocator.Object);

            // INITIALISE _controller with reference to _mockDisposableDict.Object:
            (_controller as IInitialiseParam<IDictionary<int, IDisposable>>).Initialise(_mockDisposableDict.Object);

            #endregion
        }

        #endregion
    }
}