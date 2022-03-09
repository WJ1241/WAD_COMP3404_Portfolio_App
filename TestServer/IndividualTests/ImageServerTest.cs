using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.GeneralInterfaces;
using Server;
using Moq;
using Server.InitialisingInterfaces;

namespace TestServer.IndividualTests
{
    /// <summary>
    /// CLASS 'ImageServerTest'
    /// Authors: William Eardley, William Smith & Declan Kerby-Collins
    /// Date: 07/03/22
    /// </summary>
    [TestClass]
    public class ImageServerTest 
    {
        #region FIELD VARIABLES

        /*
          Changes to make to the OO Program TODAY

        - Get Controller initialised with MockFishyHome (Needed for RunApplicationTest to pass otherwise an actual Form will be used)
        - (MAYBE, INSTEAD CALL GETSERVICE() FIRST AND STORE REFERENCE TO IT) Get Controller initialised with ImageServer
        - Get RunApplicationTest End2End to Pass
        - Get everything so far Command Invoked

        */

        // DECLARE an IServer, name it '_imageServer':
        private IServer _imageServer;

        // DECLARE a Mock<IEditImg>, name it '_mockImageEditor':
        private Mock<IEditImg> _mockImageEditor;

        // DECLARE a Mock<IManagerImg>, name it '_mockImageMgr':
        private Mock<IManageImg> _mockImageMgr;

        #endregion


        #region LOAD IMAGE TEST

        /// <summary>
        /// Checks if all methods required by ImageServer are called to store new images from their file path names
        /// </summary>
        [TestMethod]
        public void Call_Load_Method()
        {
            #region ARRANGE

            // DECLARE & INSTANTIATE a new Mock<IList<String>>(), name it '_mockList':
            Mock<IList<String>> _mockList = new Mock<IList<String>>();

            // DECLARE an IList<String>, name it '_fpList':
            // ONLY USED TO STORE RESULT OF METHOD
            IList<String> _fpList;

            // DECLARE & INITIALISE a bool, name it '_pass', set to true so test passes if no exception is thrown:
            bool _pass = true;

            #endregion


            #region ACT

            // INITIALISE _fpList with return value of _imageServer.Load(), passing a blank string as a parameter:
            _fpList = _imageServer.Load(_mockList.Object);

            #endregion


            #region ASSERT

            // TRY checking if Verify() throws a MockException:
            try
            {
                // VERIFY that _mockImageMgr.ReturnFilteredList() has been called ONCE, makes sure that method is not called twice or more:
                _mockImageMgr.Verify(_mock => _mock.ReturnFilteredList(_mockList.Object), Times.Once);
            }
            // CATCH a MockException from Verify():
            catch (MockException e)
            {
                // SET _pass to false to state that test has failed:
                _pass = false;
            }
            // CALL 'Finally' regardless of PASS or FAIL:
            finally
            {
                // ASSERT that test has passed or failed, with corresponding message if failed:
                Assert.IsTrue(_pass, "ERROR: _imageServer did not call _mockImageManager.ReturnFilteredList()!");
            }

            #endregion
        }

        #endregion


        #region GET IMAGE TEST

        /// <summary>
        /// Checks if all methods required by ImageServer are called to get an Image object
        /// </summary>
        [TestMethod]
        public void Call_Get_Image_Method()
        {
            #region ARRANGE

            // DECLARE an Image, name it '_image':
            // CANNOT BE MOCKED DUE TO NOT HAVING A PARAMETERLESS CONSTRUCTOR, THEREFORE CANNOT BE MOCKED
            // ONLY USED TO STORE RESULT OF GETIMAGE() METHOD
            Image _image;

            // DECLARE & INITIALISE a bool, name it '_pass', set to true so test passes if no exception is thrown:
            bool _pass = true;

            #endregion


            #region ACT

            // INITIALISE _image with return value of _imageServer.Load(), passing a blank string, and two integers as parameters:
            _image = _imageServer.GetImage("", 1, 1);

            #endregion


            #region ASSERT

            // TRY checking if Verify() throws a MockException:
            try
            {
                // VERIFY that _mockImageMgr.ReturnImg() has been called ONCE, makes sure that method is not called twice or more:
                _mockImageMgr.Verify(_mock => _mock.ReturnImg("", 1, 1), Times.Once);
            }
            // CATCH a MockException from Verify():
            catch (MockException e)
            {
                // SET _pass to false to state that test has failed:
                _pass = false;
            }
            // CALL 'Finally' regardless of PASS or FAIL:
            finally
            {
                // ASSERT that test has passed or failed, with corresponding message if failed:
                Assert.IsTrue(_pass, "ERROR: _imageServer did not call _mockImageManager.ReturnImg()!");
            }

            #endregion
        }

        #endregion


        #region IMAGE FLIP TESTS

        /// <summary>
        /// Checks if all methods required by ImageServer are called to flip an image horizontally
        /// </summary>
        [TestMethod]
        public void Call_Horizontal_Flip_Method()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it '_pass', set to true so test passes if no exception is thrown:
            bool _pass = true;

            #endregion


            #region ACT

            // CALL _imageServer.HorizontalFlipImage(), passing a blank string as a parameter:
            _imageServer.HorizontalFlipImage("");

            #endregion


            #region ASSERT

            // TRY checking if Verify() throws a MockException:
            try
            {
                // VERIFY that _mockImageEditor.ImgFlipXAxis() has been called ONCE, makes sure that method is not called twice or more:
                _mockImageEditor.Verify(_mock => _mock.ImgFlipXAxis(_mockImageMgr.Object.ReturnImg("")), Times.Once);
            }
            // CATCH a MockException from Verify():
            catch (MockException e)
            {
                // SET _pass to false to state that test has failed:
                _pass = false;
            }
            // CALL 'Finally' regardless of PASS or FAIL:
            finally
            {
                // ASSERT that test has passed or failed, with corresponding message if failed:
                Assert.IsTrue(_pass, "ERROR: _imageServer did not call _mockImageEditor.ImgFlipXAxis(), which also did not call _mockImageMgr.ReturnImg()!");
            }

            #endregion
        }

        /// <summary>
        /// Checks if all methods required by ImageServer are called to flip an image vertically
        /// </summary>
        [TestMethod]
        public void Call_Vertical_Flip_Method()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it '_pass', set to true so test passes if no exception is thrown:
            bool _pass = true;

            #endregion


            #region ACT

            // CALL _imageServer.VerticalFlipImage(), passing a blank string as a parameter:
            _imageServer.VerticalFlipImage("");

            #endregion


            #region ASSERT

            // TRY checking if Verify() throws a MockException:
            try
            {
                // VERIFY that _mockImageEditor.ImgFlipYAxis has been called ONCE, makes sure that method is not called twice or more:
                _mockImageEditor.Verify(_mock => _mock.ImgFlipYAxis(_mockImageMgr.Object.ReturnImg("")), Times.Once);
            }
            // CATCH a MockException from Verify():
            catch (MockException e)
            {
                // SET _pass to false to state that test has failed:
                _pass = false;
            }
            // CALL 'Finally' regardless of PASS or FAIL:
            finally
            {
                // ASSERT that test has passed or failed, with corresponding message if failed:
                Assert.IsTrue(_pass, "ERROR: _imageServer did not call _mockImageEditor.ImgFlipYAxis(), which also did not call _mockImageMgr.ReturnImg()!");
            }

            #endregion
        }

        #endregion


        #region IMAGE ROTATION TESTS

        /// <summary>
        /// Checks if all methods required by ImageServer are called to rotate an image clockwise
        /// </summary>
        [TestMethod]
        public void Call_Rotate_Clockwise_Method()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it '_pass', set to true so test passes if no exception is thrown:
            bool _pass = true;

            #endregion


            #region ACT

            // CALL _imageServer.RotateImage(), passing a blank string as a parameter:
            _imageServer.RotateImage("");

            #endregion


            #region ASSERT

            // TRY checking if Verify() throws a MockException:
            try
            {
                // VERIFY that _mockImageEditor.ImgRotateClockwise() has been called ONCE, makes sure that method is not called twice or more:
                _mockImageEditor.Verify(_mock => _mock.ImgRotateClockwise(_mockImageMgr.Object.ReturnImg("")), Times.Once);
            }
            // CATCH a MockException from Verify():
            catch (MockException e)
            {
                // SET _pass to false to state that test has failed:
                _pass = false;
            }
            // CALL 'Finally' regardless of PASS or FAIL:
            finally
            {
                // ASSERT that test has passed or failed, with corresponding message if failed:
                Assert.IsTrue(_pass, "ERROR: _imageServer did not call _mockImageEditor.ImgRotateClockwise(), which also did not call _mockImageMgr.ReturnImg()!");
            }

            #endregion
        }

        /// <summary>
        /// Checks if all methods required by ImageServer are called to rotate an image anti-clockwise
        /// </summary>
        [TestMethod]
        public void Call_Rotate_AntiClockwise_Method()
        {
            #region ARRANGE

            // DECLARE & INITIALISE a bool, name it '_pass', set to true so test passes if no exception is thrown:
            bool _pass = true;

            #endregion


            #region ACT

            // CALL _imageServer.ACRotateImage(), passing a blank string as a parameter:
            (_imageServer as IACRotate).ACRotateImage("");

            #endregion


            #region ASSERT

            // TRY checking if Verify() throws a MockException:
            try
            {
                // VERIFY that _mockImageEditor.ImgRotateAntiClockwise() has been called ONCE, makes sure that method is not called twice or more:
                _mockImageEditor.Verify(_mock => _mock.ImgRotateAntiClockwise(_mockImageMgr.Object.ReturnImg("")), Times.Once);
            }
            // CATCH a MockException from Verify():
            catch (MockException e)
            {
                // SET _pass to false to state that test has failed:
                _pass = false;
            }
            // CALL 'Finally' regardless of PASS or FAIL:
            finally
            {
                // ASSERT that test has passed or failed, with corresponding message if failed:
                Assert.IsTrue(_pass, "ERROR: _imageServer did not call _mockImageEditor.ImgRotateAntiClockwise(), which also did not call _mockImageMgr.ReturnImg()!");
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
            // INSTANTIATE _imageServer as a new ImageServer():
            _imageServer = new ImageServer();

            // INSTANTIATE _mockImageEditor as a new Mock<IEditImg>():
            _mockImageEditor = new Mock<IEditImg>();

            // INSTANTIATE _mockImageMgr as a new Mock<IManageImg>():
            _mockImageMgr = new Mock<IManageImg>();

            // INIITIALISE _imageServer with a reference to _mockImageEditor.Object:
            (_imageServer as IInitialiseParam<IEditImg>).Initialise(_mockImageEditor.Object);

            // INIITIALISE _imageServer with a reference to _mockImageMgr.Object:
            (_imageServer as IInitialiseParam<IManageImg>).Initialise(_mockImageMgr.Object); 
        }

        #endregion
    }
}
