using GUI.Forms.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server.Commands;
using Server.CustomEventArgs;
using TestApp.MockClasses;

namespace TestGUI
{
    /// <summary>
    /// Test Class which checks if MockFishyHome is behaving as expected
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 03/03/22
    /// </summary>
    [TestClass]
    public class MockFishyHomeTest
    {
        #region FIELD VARIABLES

        // DECLARE an IEventListener<ImageEventArgs>, name it '_mockFishyEdit':
        private IEventListener<ImageEventArgs> _mockFishyEdit;

        #endregion


        #region TEST METHODS

        #region SETTING IMAGE

        /// <summary>
        /// Checks if MockFishyHome is given an Image successfully
        /// </summary>
        [TestMethod]
        public void Set_Image_Of_MockFishyHome()
        {
            #region ARRANGE



            #endregion


            #region ACT



            #endregion


            #region ASSERT



            #endregion
        }

        #endregion


        #region CREATING MOCKFISHYEDIT

        /// <summary>
        /// Checks if MockFishyHome is given an Image successfully
        /// </summary>
        [TestMethod]
        public void Check_If_MockFishyEdit_Is_Active()
        {
            #region ARRANGE

            // DECLARE & INSTANTIATE a IEventListener<ImageEventArgs>(), name it '_mockFishyHome':
            IEventListener<ImageEventArgs> _mockFishyHome = new MockFishyHome();

            // DECLARE & INSTANTIATE a new Mock<ICommandZeroParam>, name it '_mockCmd':
            Mock<ICommandZeroParam> _mockCmd = new Mock<ICommandZeroParam>();


            _mockCmd.Setup(_mockCmd => _mockCmd.Action);


            _mockCmd.Setup(_mockCmd => _mockCmd.ExecuteMethod()).Callback(_mockCmd.Object.Action);

            #endregion


            #region ACT

            // INVOKE _createEditScrn ICommand:


            #endregion


            #region ASSERT

            // IF _mockFishyEdit DOES NOT have an active instance:
            if (_mockFishyEdit == null)
            {
                // ASSERT that the test has failed due to _mockFishyEdit not having an active instance:
                Assert.IsTrue(false, "_mockFishyEdit does not have an active instance!");
            }

            #endregion
        }

        #endregion

        #endregion


        #region PRIVATE METHODS

        #region CREATE MOCKFISHYEDIT


        private void CreateMockFishyEdit()
        {
            // INSTANTIATE _mockFishyEdit as a new MockFishyEdit():
            _mockFishyEdit = new MockFishyEdit();
        }

        #endregion

        #endregion
    }
}
