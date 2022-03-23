using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server;
using Server.GeneralInterfaces;
using Server.InitialisingInterfaces;
using Server.CustomEventArgs;

namespace TestServer.IndividualTests
{
    /// <summary>
    /// Test Class which checks if ImageServer is behaving as expected
    /// Authors: William Smith, William Eardley & Declan Kerby-Collins
    /// Date: 13/03/22
    /// </summary>
    [TestClass]
    public class ImageServerTest 
    {
        #region FIELD VARIABLES

        // DECLARE an IServer, name it '_imageServer':
        private IServer _imageServer;

        // DECLARE an IDictionary<string, EventArgs>, name it '_mockEventArgsDict':
        private Mock<IDictionary<string, EventArgs>> _mockEventArgsDict;

        // DECLARE a Mock<IEditImg>, name it '_mockImageEditor':
        private Mock<IEditImg> _mockImageEditor;

        // DECLARE a Mock<IManagerImg>, name it '_mockImageMgr':
        private Mock<IManageImg> _mockImageMgr;

        // DECLARE a Mock<IEventListener<ImageEventArgs>>, name it '_mockEventListener':
        private Mock<IEventListener<ImageEventArgs>> _mockEventListener;

        // DECLARE a Mock<ImageEventArgs>, name it '_mockImgEventArgs':
        private Mock<ImageEventArgs> _mockImgEventArgs;

        // DECLARE a Mock<ImageEventArgs>, name it '_mockStringListEventArgs':
        private Mock<StringListEventArgs> _mockStringListEventArgs;

        #endregion


        #region LOAD IMAGE TEST

        /// <summary>
        /// Checks if all methods required by ImageServer are called to store new images from their file path names
        /// </summary>
        [TestMethod]
        public void Call_Load_Method()
        {
            #region ARRANGE

            // DECLARE & INSTANTIATE a new Mock<IList<string>>(), name it '_mockList':
            Mock<IList<string>> _mockList = new Mock<IList<string>>();

            // DECLARE & INITIALISE a bool, name it '_pass', set to true so test passes if no exception is thrown:
            bool _pass = true;

            #endregion


            #region ACT

            // CALL Load() on _imageServer, passing _mockList.Object and an StringListEventArgs Event as a parameter:
            _imageServer.Load(_mockList.Object, _mockEventListener.As<IEventListener<StringListEventArgs>>().Object.OnEvent);

            #endregion


            #region ASSERT

            // TRY checking if Verify() throws a MockException:
            try
            {
                // VERIFY that _mockImageMgr.ReturnFilteredList() has been called ONCE, makes sure that method is not called twice or more:
                _mockImageMgr.Verify(_mock => _mock.ReturnFilteredList(_mockList.Object), Times.Once);
            }
            // CATCH a MockException from Verify():
            catch (MockException)
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

            // DECLARE & INITIALISE a bool, name it '_pass', set to true so test passes if no exception is thrown:
            bool _pass = true;

            #endregion


            #region ACT

            // CALL GetImage() on _imageServer, passing a blank string, two integers and an ImageEventArgs Event as parameters:
            _imageServer.GetImage("", 1, 1, _mockEventListener.Object.OnEvent);

            #endregion


            #region ASSERT

            // TRY checking if Verify() throws a MockException:
            try
            {
                // VERIFY that _mockImageMgr.ReturnImg() has been called ONCE, makes sure that method is not called twice or more:
                _mockImageMgr.Verify(_mock => _mock.ReturnImg("", 1, 1), Times.Once);
            }
            // CATCH a MockException from Verify():
            catch (MockException)
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

            // CALL HorizontalFlipImage() on _imageServer, passing a blank string as a parameter:
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
            catch (MockException)
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

            // CALL VerticalFlipImage() on _imageServer, passing a blank string as a parameter:
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
            catch (MockException)
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

            // CALL RotateImage() on _imageServer, passing a blank string as a parameter:
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
            catch (MockException)
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

            // CALL ACRotateImage() on _imageServer, passing a blank string as a parameter:
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
            catch (MockException)
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
            #region INSTANTIATIONS

            // INSTANTIATE _imageServer as a new ImageServer():
            _imageServer = new ImageServer();

            // INSTANTIATE _mockEventArgsDict as a new Mock<IDictionary<string, EventArgs>>():
            _mockEventArgsDict = new Mock<IDictionary<string, EventArgs>>();

            // INSTANTIATE _mockImageEditor as a new Mock<IEditImg>():
            _mockImageEditor = new Mock<IEditImg>();

            // INSTANTIATE _mockImageMgr as a new Mock<IManageImg>():
            _mockImageMgr = new Mock<IManageImg>();

            // INSTANTIATE _mockEventListener as a new Mock<IEventListener<ImageEventArgs>>():
            _mockEventListener = new Mock<IEventListener<ImageEventArgs>>();

            // INSTANTIATE _mockImgEventArgs as a new Mock<ImageEventArgs>():
            _mockImgEventArgs = new Mock<ImageEventArgs>();

            // INSTANTIATE _mockStringListEventArgs as a new Mock<StringListEventArgs>():
            _mockStringListEventArgs = new Mock<StringListEventArgs>();

            #endregion


            #region IMPLEMENTATIONS

            // INIITIALISE _imageServer with a reference to _mockImageEditor.Object:
            (_imageServer as IInitialiseParam<IEditImg>).Initialise(_mockImageEditor.Object);

            // INIITIALISE _imageServer with a reference to _mockImageMgr.Object:
            (_imageServer as IInitialiseParam<IManageImg>).Initialise(_mockImageMgr.Object);

            // INITIALISE _imageServer with a reference to _mockEventArgsDict.Object:
            (_imageServer as IInitialiseParam<IDictionary<string, EventArgs>>).Initialise(_mockEventArgsDict.Object);

            // SETUP _mockEventListener so that it implements IEventListener<StringListEventArgs>:
            _mockEventListener.As<IEventListener<StringListEventArgs>>();

            // SETUP _mockEventArgsDict so that it returns _mockImgEventArgs.Object when "Image" is addressed:
            _mockEventArgsDict.Setup(_mock => _mock["Image"]).Returns(_mockImgEventArgs.Object);

            // SETUP _mockEventArgsDict so that it returns _mockStringListEventArgs.Object when "StringList" is addressed:
            _mockEventArgsDict.Setup(_mock => _mock["StringList"]).Returns(_mockStringListEventArgs.Object);

            #endregion
        }

        #endregion
    }
}
