using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GUI.Forms.Interfaces;
using Server.Commands;
using Server.CustomEventArgs;
using TestApp.MockClasses;
using TestGUI.Interfaces;

namespace TestGUI.IndividualTests
{
    /// <summary>
    /// Test Class which checks if MockFishyHome is behaving as expected
    /// Authors: Declan Kerby-Collins, William Smith & William Eardley
    /// Date: 11/03/22
    /// </summary>
    [TestClass]
    public class MockFishyHomeTest
    {
        // DECLARE an IMockFishyHome, name it '_mockFishyHome':
        private IMockFishyHome _mockFishyHome;

        // DECLARE a Mock<ImageEventArgs>, name it '_imgEventArgs':
        private Mock<ImageEventArgs> _imgEventArgs;

        // DECLARE a Mock<StringListEventArgs>, name it '_stringListEventArgs':
        private Mock<StringListEventArgs> _stringListEventArgs;

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

        /// <summary>
        /// Creates and Initialises this class' dependencies
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            // INSTANTIATE _mockFishyHome as new MockFishyHome():
            _mockFishyHome = new MockFishyHome();

            // INSTANTIATE _imgEventArgs as a new Mock<ImageEventArgs>():
            _imgEventArgs = new Mock<ImageEventArgs>();

            // INSTANTIATE _stringListEventArgs as a new Mock<StringListEventArgs>():
            _stringListEventArgs = new Mock<StringListEventArgs>();
        }
    }
}
