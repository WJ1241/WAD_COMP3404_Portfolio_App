using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GUI.Forms.Interfaces;
using GUI.Logic.Interfaces;
using Server.Commands.Interfaces;
using Server.CustomEventArgs;
using Server.GeneralInterfaces;
using Server.InitialisingInterfaces;
using TestApp.MockClasses;
using TestGUI.Interfaces;

namespace TestGUI.IndividualTests
{
    /// <summary>
    /// Test Class which checks if MockFishyHome is behaving as expected
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 23/03/22
    /// </summary>
    [TestClass]
    public class MockFishyHomeTest
    {
        #region FIELD VARIABLES

        // DECLARE an IMockFishyHome, name it '_mockFishyHome':
        private IMockFishyHome _mockFishyHome;

        // DECLARE a Mock<IDictionary<int, string>>, name it '_mockImgFPDict':
        private Mock<IDictionary<int, string>> _mockImgFPDict;

        // DECLARE a Mock<IDictionary<string, ICommand>>, name it '_mockCommandDict':
        private Mock<IDictionary<string, ICommand>> _mockCommandDict;

        // DECLARE a Mock<IOpenImage>, name it '_mockOpenImage':
        private Mock<IOpenImage> _mockOpenImage;

        // DECLARE a Mock<IServer>, name it '_mockServer':
        private Mock<IServer> _mockServer;

        // DECLARE a Mock<ICommandInvoker>, name it '_mockCommandInvoker':
        private Mock<ICommandInvoker> _mockCommandInvoker;

        // DECLARE a Mock<ICommandParam<string, int, int, EventHandler<ImageEventArgs>>>, name it '_mockGetImgCmd':
        private Mock<ICommandParam<string, int, int, EventHandler<ImageEventArgs>>> _mockGetImgCmd;

        // DECLARE a Mock<ICommandParam<IList<string>, EventHandler<StringListEventArgs>>>, name it '_mockLoadCmd':
        private Mock<ICommandParam<IList<string>, EventHandler<StringListEventArgs>>> _mockLoadCmd;

        // DECLARE a Mock<ImageEventArgs>, name it '_mockImgEventArgs':
        private Mock<ImageEventArgs> _mockImgEventArgs;

        // DECLARE a Mock<StringListEventArgs>, name it '_mockStringListEventArgs':
        private Mock<StringListEventArgs> _mockStringListEventArgs;

        #endregion


        #region EVENT TESTS

        /// <summary>
        /// Checks if MockFishyHome's OnEvent() (ImageEventArgs) event method is called successfully
        /// </summary>
        [TestMethod]
        public void Invoke_Image_Change_Event_Handler()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it '_pass', set to true so test passes if not changed:
            bool _pass = true;

            #endregion


            #region ACT

            // CALL OnEvent() (ImageEventArgs) on _mockFishyHome:
            (_mockFishyHome as IEventListener<ImageEventArgs>).OnEvent(this, _mockImgEventArgs.Object);

            #endregion


            #region ASSERT

            // IF _mockFishyHome.ImgChangeEventCalled is false:
            if (!_mockFishyHome.ImgChangeEventCalled)
            {
                // ASSIGNMENT _pass becomes false:
                _pass = false;
            }

            // ASSERT if test has passed, display error message
            Assert.IsTrue(_pass, "ERROR: Image Event Handler Not Called!");

            #endregion
        }

        /// <summary>
        /// Checks if MockFishyHome's OnEvent() (StringListEventArgs) event method is called successfully
        /// </summary>
        [TestMethod]
        public void Invoke_String_List_Event_Handler()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it '_pass', set to true so test passes if not changed:
            bool _pass = true;

            #endregion


            #region ACT

            // CALL OnEvent() (StringListEventArgs) on _mockFishyHome:
            (_mockFishyHome as IEventListener<StringListEventArgs>).OnEvent(this, _mockStringListEventArgs.Object);

            #endregion


            #region ASSERT

            // IF _mockFishyHome.StringListEventCalled is false:
            if (!_mockFishyHome.StringListEventCalled)
            {
                // ASSIGNMENT _pass becomes false:
                _pass = false;
            }

            // ASSERT if test has passed, display error message
            Assert.IsTrue(_pass, "ERROR: String List Event Handler Not Called!");

            #endregion
        }

        #endregion


        #region COMMAND INVOKER TESTS

        /// <summary>
        /// Checks if MockFishyHome's OnEvent() (StringListEventArgs) event method is called successfully
        /// </summary>
        [TestMethod]
        public void Call_InvokeCommand_In_ChangeImg()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it '_pass', set to true so test passes if not changed:
            bool _pass = true;

            #endregion


            #region ACT

            // CALL ChangeImg() on _mockFishyHome:
            (_mockFishyHome as IChangeImg).ChangeImg();

            #endregion


            #region ASSERT

            // TRY checking if _mockCommandInvoker.InvokeCommand(_mockGetImgCmd.Object) has been called:
            try
            {
                // VERIFY that InvokeCommand(_mockGetImgCmd) was called ONCE, to ensure the same behaviour isn't performed twice or more:
                _mockCommandInvoker.Verify(_mock => _mock.InvokeCommand(_mockGetImgCmd.Object), Times.Once);
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
                Assert.IsTrue(_pass, "ERROR: MockFishyHome has not called InvokeCommand(_mockGetImgCmd.Object) on _mockCommandInvoker!");
            }

            #endregion
        }

        /// <summary>
        /// Checks if MockFishyHome's OnEvent() (StringListEventArgs) event method is called successfully
        /// </summary>
        [TestMethod]
        public void Call_InvokeCommand_In_LoadBttn_Click()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it '_pass', set to true so test passes if not changed:
            bool _pass = true;

            #endregion


            #region ACT

            // CALL LoadBttn_Click() on _mockFishyHome:
            _mockFishyHome.LoadBttn_Click(this, _mockImgEventArgs.Object);

            #endregion


            #region ASSERT

            // TRY checking if _mockCommandInvoker.InvokeCommand(_mockLoadCmd.Object) has been called:
            try
            {
                // VERIFY that InvokeCommand(_mockGetImgCmd) was called ONCE, to ensure the same behaviour isn't performed twice or more:
                _mockCommandInvoker.Verify(_mock => _mock.InvokeCommand(_mockLoadCmd.Object), Times.Once);
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
                Assert.IsTrue(_pass, "ERROR: MockFishyHome has not called InvokeCommand(_mockLoadCmd.Object) on _mockCommandInvoker!");
            }

            #endregion
        }

        /// <summary>
        /// Checks if CommandParam's FirstParam Property is set successfully
        /// </summary>
        [TestMethod]
        public void Set_First_Param_Of_CommandParam()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it '_pass', set to true so test passes if not changed:
            bool _pass = true;

            #endregion


            #region ACT

            // CALL LoadBttn_Click() on _mockFishyHome:
            _mockFishyHome.LoadBttn_Click(this, _mockImgEventArgs.Object);

            #endregion


            #region ASSERT

            // TRY checking if _mockLoadCmd.FirstParam was set:
            try
            {
                // VERIFY that FirstParam.Set has been set ONCE, makes sure that method is not set more than once:
                _mockLoadCmd.VerifySet(_mock => _mock.FirstParam = _mockOpenImage.Object.OpenImage(), Times.Once);
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
                Assert.IsTrue(_pass, "ERROR: _mockLoadCmd.FirstParam has not been set!");
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

            // INSTANTIATE _mockFishyHome as a new MockFishyHome():
            _mockFishyHome = new MockFishyHome();

            // INSTANTIATE _mockCommandDict as a new Mock<IDictionary<int, string>>():
            _mockImgFPDict = new Mock<IDictionary<int, string>>();

            // INSTANTIATE _mockCommandDict as a new Mock<IDictionary<string, ICommand>>():
            _mockCommandDict = new Mock<IDictionary<string, ICommand>>();

            // INSTANTIATE _mockOpenImage as a new Mock<IOpenImage>():
            _mockOpenImage = new Mock<IOpenImage>();

            // INSTANTIATE _mockServer as a new Mock<IServer>():
            _mockServer = new Mock<IServer>();

            // INSTANTIATE _mockCommandInvoker as a new Mock<ICommandInvoker>():
            _mockCommandInvoker = new Mock<ICommandInvoker>();

            // INSTANTIATE _mockImgEventArgs as a new Mock<ImageEventArgs>():
            _mockImgEventArgs = new Mock<ImageEventArgs>();

            // INSTANTIATE _mockStringListEventArgs as a new Mock<StringListEventArgs>():
            _mockStringListEventArgs = new Mock<StringListEventArgs>();

            // DECLARE & INSTANTIATE an IList<string> as a new List<string>(), name it '_stringList':
            IList<string> _stringList = new List<string>();

            #endregion


            #region IMAGE FILE PATH SETUP

            // SETUP _mockImgFPDict so that address '1' returns a valid image path:
            _mockImgFPDict.Setup(_mock => _mock[1]).Returns("..\\..\\..\\..\\Server\\Displayables\\FishAssets\\JavaFish.png");

            // ADD file path to _stringList:
            _stringList.Add("..\\..\\..\\..\\Server\\Displayables\\FishAssets\\JavaFish.png");

            // SETUP _mockImgEventArgs so that it returns a new image with a specified file path:
            _mockImgEventArgs.SetupGet(_mock => _mock.Img).Returns(Image.FromFile("..\\..\\..\\..\\Server\\Displayables\\FishAssets\\JavaFish.png"));

            // SETUP _mockStringListEventArgs so that it returns a reference to _stringList:
            _mockStringListEventArgs.SetupGet(_mock => _mock.List).Returns(_stringList);

            #endregion


            #region COMMANDS

            // INSTANTIATE _mockGetImgCmd as a new Mock<ICommandParam<string, int, int, EventHandler<ImageEventArgs>>>():
            _mockGetImgCmd = new Mock<ICommandParam<string, int, int, EventHandler<ImageEventArgs>>>();

            // SETUP _mockGetImgCmd so that its Name Property can be given a string value:
            _mockGetImgCmd.As<IName>().SetupSet(_mock => _mock.Name = "GetImage");

            // SETUP _mockGetImgCmd so that its MethodRef Property holds reference to _mockServer.Object.GetImage():
            _mockGetImgCmd.SetupSet(_mock => _mock.MethodRef = _mockServer.Object.GetImage);

            // INSTANTIATE _mockLoadCmd as a new Mock<ICommandParam<IList<string>, EventHandler<StringListEventArgs>>>():
            _mockLoadCmd = new Mock<ICommandParam<IList<string>, EventHandler<StringListEventArgs>>>();

            // SETUP _mockLoadCmd so that its Name Property can be given a string value:
            _mockLoadCmd.As<IName>().SetupSet(_mock => _mock.Name = "Load");

            // SETUP _mockLoadCmd so that its MethodRef Property holds reference to _mockServer.Object.Load:
            _mockLoadCmd.SetupSet(_mock => _mock.MethodRef = _mockServer.Object.Load);

            // SETUP _mockCommandDict["GetImage"] so that it returns _mockGetImgCmd.Object:
            _mockCommandDict.Setup(_mock => _mock["GetImage"]).Returns(_mockGetImgCmd.Object);

            // SETUP _mockCommandDict["Load"] so that it returns _mockLoadCmd.Object:
            _mockCommandDict.Setup(_mock => _mock["Load"]).Returns(_mockLoadCmd.Object);

            #endregion


            #region INITIALISATIONS

            // INITIALISE _mockFishyHome with a reference to _mockImgFPDict.Object:
            (_mockFishyHome as IInitialiseParam<IDictionary<int, string>>).Initialise(_mockImgFPDict.Object);

            // INITIALISE _mockFishyHome with a reference to _mockCommandDict.Object:
            (_mockFishyHome as IInitialiseParam<IDictionary<string, ICommand>>).Initialise(_mockCommandDict.Object);

            // INITIALISE _mockFishyHome with a reference to _mockOpenImage.Object:
            (_mockFishyHome as IInitialiseParam<IOpenImage>).Initialise(_mockOpenImage.Object);

            // INITIALISE _mockFishyHome with a reference to _mockGetImgCmd.Object:
            (_mockFishyHome as IInitialiseParam<ICommand>).Initialise(_mockGetImgCmd.Object);

            // INITIALISE _mockFishyHome with a reference to _mockLoadCmd.Object:
            (_mockFishyHome as IInitialiseParam<ICommand>).Initialise(_mockLoadCmd.Object);

            // SET InvokeCommand Property value of _mockFishyHome to reference to _mockCommandInvoker.Object.InvokeCommand():
            (_mockFishyHome as ICommandSender).InvokeCommand = _mockCommandInvoker.Object.InvokeCommand;

            #endregion
        }

        #endregion
    }
}
