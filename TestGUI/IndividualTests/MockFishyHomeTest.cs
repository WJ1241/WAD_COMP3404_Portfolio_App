using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server.Commands;
using Server.CustomEventArgs;
using Server.GeneralInterfaces;
using TestApp.MockClasses;
using TestGUI.Interfaces;

namespace TestGUI.IndividualTests
{
    /// <summary>
    /// Test Class which checks if MockFishyHome is behaving as expected
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 13/03/22
    /// </summary>
    [TestClass]
    public class MockFishyHomeTest
    {
        #region FIELD VARIABLES

        // DECLARE an IMockFishyHome, name it '_mockFishyHome':
        private IMockFishyHome _mockFishyHome;

        // DECLARE a Mock<ICommandInvoker>, name it '_mockCommandInvoker':
        private Mock<ICommandInvoker> _mockCommandInvoker;

        // DECLARE a Mock<ImageEventArgs>, name it '_imgEventArgs':
        private Mock<ImageEventArgs> _imgEventArgs;

        // DECLARE a Mock<StringListEventArgs>, name it '_stringListEventArgs':
        private Mock<StringListEventArgs> _stringListEventArgs;

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

            // CALL OnEvent on _mockFishyHome:
            (_mockFishyHome as IEventListener<ImageEventArgs>).OnEvent(this, _imgEventArgs.Object);

            #endregion


            #region ASSERT

            // IF _mockFishyHome.ImgChangeEventCalled is false
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

            // CALL OnEvent on _mockFishyHome:
            (_mockFishyHome as IEventListener<StringListEventArgs>).OnEvent(this, _stringListEventArgs.Object);

            #endregion


            #region ASSERT

            // IF _mockFishyHome.StringListEventCalled is false
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


        #region SETUP METHODS

        /// <summary>
        /// Creates and Initialises this class' dependencies
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            #region INSTANTIATIONS

            // INSTANTIATE _mockFishyHome as new MockFishyHome():
            _mockFishyHome = new MockFishyHome();

            // INSTANTIATE _mockCommandInvoker as a new Mock<ICommandInvoker>():
            _mockCommandInvoker = new Mock<ICommandInvoker>();

            // INSTANTIATE _imgEventArgs as a new Mock<ImageEventArgs>():
            _imgEventArgs = new Mock<ImageEventArgs>();

            // INSTANTIATE _stringListEventArgs as a new Mock<StringListEventArgs>():
            _stringListEventArgs = new Mock<StringListEventArgs>();

            #endregion


            #region INITIALISATIONS


            (_mockFishyHome as ICommandSender).InvokeCommand = _mockCommandInvoker

            #endregion
        }

        #endregion
    }
}
