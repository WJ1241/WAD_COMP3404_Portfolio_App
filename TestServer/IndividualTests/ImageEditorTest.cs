using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;
using Server.Exceptions;
using Server.GeneralInterfaces;

namespace TestServer.IndividualTests
{
    /// <summary>
    /// Test Class for methods within the 'ImgEditor' class
    /// Author: William Smith, William Eardley & Declan Kerby-Collins
    /// Date: 03/12/21
    /// </summary>
    [TestClass]
    public class ImageEditorTest
    {
        #region CLOCKWISE IMAGE ROTATION TESTS

        #region PASS

        /// <summary>
        /// Test Method for ImgRotateClockwise, with an ACTIVE IMAGE INSTANCE to PASS test
        /// </summary>
        [TestMethod]
        public void ClockwiseImageRotPass()
        {
            #region ARRANGE

            // DECLARE & INSTANTIATE an IEditImg as a new ImageEditor(), name it _editImg:
            IEditImg _editImg = new ImageEditor();

            // DECLARE & INITIALISE an Image, name it '_image', give file path to an image:
            Image _image = Image.FromFile("..\\..\\..\\..\\Server\\Displayables\\FishAssets\\JavaFish.png");

            #endregion

            #region ACT

            // TRY checking if ImgRotateClockwise() throws an exception:
            try
            {
                // CALL ImgRotateClockwise, passing _image as a parameter:
                _editImg.ImgRotateClockwise(_image);
            }

            #endregion

            #region ASSERT

            // CATCH NullInstanceException from ImgRotateClockwise():
            catch (NullInstanceException pException)
            {
                // FAIL test, passing exception message as a parameter:
                Assert.Fail(pException.Message);
            }

            #endregion
        }

        #endregion


        #region FAIL

        /// <summary>
        /// Test Method for ImgRotateClockwise, with a NULL IMAGE INSTANCE to FAIL test
        /// </summary>
        [TestMethod]
        public void ClockwiseImageRotFail()
        {
            #region ARRANGE

            // DECLARE & INSTANTIATE an IEditImg as a new ImageEditor(), name it _editImg:
            IEditImg _editImg = new ImageEditor();

            // DECLARE & INITIALISE an Image, name it '_image', give null instance to fail test:
            Image _image = null;

            // DECLARE & INITIALISE a bool, name it '_fail', give value of 'false' to change to 'true' if failed:
            bool _fail = false;

            #endregion


            #region ACT

            // TRY checking if ImgRotateClockwise() throws an exception:
            try
            {
                // CALL ImgRotateClockwise, passing _image as a parameter:
                _editImg.ImgRotateClockwise(_image);
            }

            #endregion


            #region ASSERT

            // CATCH NullInstanceException from ImgRotateClockwise():
            catch (NullInstanceException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);

                // SET _fail to true:
                _fail = true;
            }

            // ASSERT that test fail is true, and PASS the test:
            Assert.IsTrue(_fail, "NullInstanceException thrown for test fail!");

            #endregion
        }

        #endregion

        #endregion


        #region ANTICLOCKWISE IMAGE ROTATION TESTS

        #region PASS

        /// <summary>
        /// Test Method for ImgRotateAntiClockwise, with an ACTIVE IMAGE INSTANCE to PASS test
        /// </summary>
        [TestMethod]
        public void AntiClockwiseImageRotPass()
        {
            #region ARRANGE

            // DECLARE & INSTANTIATE an IEditImg as a new ImageEditor(), name it _editImg:
            IEditImg _editImg = new ImageEditor();

            // DECLARE & INITIALISE an Image, name it '_image', give file path to an image:
            Image _image = Image.FromFile("..\\..\\..\\..\\Server\\Displayables\\FishAssets\\JavaFish.png");

            #endregion

            #region ACT

            // TRY checking if ImgRotateAntiClockwise() throws an exception:
            try
            {
                // CALL ImgRotateAntiClockwise, passing _image as a parameter:
                _editImg.ImgRotateAntiClockwise(_image);
            }

            #endregion

            #region ASSERT

            // CATCH NullInstanceException from ImgRotateAntiClockwise():
            catch (NullInstanceException pException)
            {
                // FAIL test, passing exception message as a parameter:
                Assert.Fail(pException.Message);
            }

            #endregion
        }

        #endregion


        #region FAIL

        /// <summary>
        /// Test Method for ImgRotateAntiClockwise, with a NULL IMAGE INSTANCE to FAIL test
        /// </summary>
        [TestMethod]
        public void AntiClockwiseImageRotFail()
        {
            #region ARRANGE

            // DECLARE & INSTANTIATE an IEditImg as a new ImageEditor(), name it _editImg:
            IEditImg _editImg = new ImageEditor();

            // DECLARE & INITIALISE an Image, name it '_image', give null instance to fail test:
            Image _image = null;

            // DECLARE & INITIALISE a bool, name it '_fail', give value of 'false' to change to 'true' if failed:
            bool _fail = false;

            #endregion


            #region ACT

            // TRY checking if ImgRotateAntiClockwise() throws an exception:
            try
            {
                // CALL ImgRotateAntiClockwise, passing _image as a parameter:
                _editImg.ImgRotateAntiClockwise(_image);
            }

            #endregion


            #region ASSERT

            // CATCH NullInstanceException from ImgRotateAntiClockwise():
            catch (NullInstanceException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);

                // SET _fail to true:
                _fail = true;
            }

            // ASSERT that test fail is true, and PASS the test:
            Assert.IsTrue(_fail, "NullInstanceException thrown for test fail!");

            #endregion
        }

        #endregion

        #endregion


        #region IMAGE X AXIS FLIP TESTS

        #region PASS

        /// <summary>
        /// Test Method for ImgFlipXAxis, with an ACTIVE IMAGE INSTANCE to PASS test
        /// </summary>
        [TestMethod]
        public void ImageFlipXPass()
        {
            #region ARRANGE

            // DECLARE & INSTANTIATE an IEditImg as a new ImageEditor(), name it _editImg:
            IEditImg _editImg = new ImageEditor();

            // DECLARE & INITIALISE an Image, name it '_image', give file path to an image:
            Image _image = Image.FromFile("..\\..\\..\\..\\Server\\Displayables\\FishAssets\\JavaFish.png");

            #endregion

            #region ACT

            // TRY checking if ImgFlipXAxis() throws an exception:
            try
            {
                // CALL ImgFlipXAxis, passing _image as a parameter:
                _editImg.ImgFlipXAxis(_image);
            }

            #endregion

            #region ASSERT

            // CATCH NullInstanceException from ImgFlipXAxis():
            catch (NullInstanceException pException)
            {
                // FAIL test, passing exception message as a parameter:
                Assert.Fail(pException.Message);
            }

            #endregion
        }

        #endregion


        #region FAIL

        /// <summary>
        /// Test Method for ImgFlipXAxis, with a NULL IMAGE INSTANCE to FAIL test
        /// </summary>
        [TestMethod]
        public void ImageFlipXFail()
        {
            #region ARRANGE

            // DECLARE & INSTANTIATE an IEditImg as a new ImageEditor(), name it _editImg:
            IEditImg _editImg = new ImageEditor();

            // DECLARE & INITIALISE an Image, name it '_image', give null instance to fail test:
            Image _image = null;

            // DECLARE & INITIALISE a bool, name it '_fail', give value of 'false' to change to 'true' if failed:
            bool _fail = false;

            #endregion


            #region ACT

            // TRY checking if ImgFlipXAxis() throws an exception:
            try
            {
                // CALL ImgFlipXAxis, passing _image as a parameter:
                _editImg.ImgFlipXAxis(_image);
            }

            #endregion


            #region ASSERT

            // CATCH NullInstanceException from ImgFlipXAxis():
            catch (NullInstanceException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);

                // SET _fail to true:
                _fail = true;
            }

            // ASSERT that test fail is true, and PASS the test:
            Assert.IsTrue(_fail, "NullInstanceException thrown for test fail!");

            #endregion
        }

        #endregion

        #endregion


        #region IMAGE Y AXIS FLIP TESTS

        #region PASS

        /// <summary>
        /// Test Method for ImgFlipYAxis, with an ACTIVE IMAGE INSTANCE to PASS test
        /// </summary>
        [TestMethod]
        public void ImageFlipYPass()
        {
            #region ARRANGE

            // DECLARE & INSTANTIATE an IEditImg as a new ImageEditor(), name it _editImg:
            IEditImg _editImg = new ImageEditor();

            // DECLARE & INITIALISE an Image, name it '_image', give file path to an image:
            Image _image = Image.FromFile("..\\..\\..\\..\\Server\\Displayables\\FishAssets\\JavaFish.png");

            #endregion

            #region ACT

            // TRY checking if ImgFlipYAxis() throws an exception:
            try
            {
                // CALL ImgFlipYAxis, passing _image as a parameter:
                _editImg.ImgFlipYAxis(_image);
            }

            #endregion

            #region ASSERT

            // CATCH NullInstanceException from ImgFlipYAxis():
            catch (NullInstanceException pException)
            {
                // FAIL test, passing exception message as a parameter:
                Assert.Fail(pException.Message);
            }

            #endregion
        }

        #endregion


        #region FAIL

        /// <summary>
        /// Test Method for ImgFlipYAxis, with a NULL IMAGE INSTANCE to FAIL test
        /// </summary>
        [TestMethod]
        public void ImageFlipYFail()
        {
            #region ARRANGE

            // DECLARE & INSTANTIATE an IEditImg as a new ImageEditor(), name it _editImg:
            IEditImg _editImg = new ImageEditor();

            // DECLARE & INITIALISE an Image, name it '_image', give null instance to fail test:
            Image _image = null;

            // DECLARE & INITIALISE a bool, name it '_fail', give value of 'false' to change to 'true' if failed:
            bool _fail = false;

            #endregion


            #region ACT

            // TRY checking if ImgFlipYAxis() throws an exception:
            try
            {
                // CALL ImgFlipYAxis, passing _image as a parameter:
                _editImg.ImgFlipYAxis(_image);
            }

            #endregion


            #region ASSERT

            // CATCH NullInstanceException from ImgFlipYAxis():
            catch (NullInstanceException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);

                // SET _fail to true:
                _fail = true;
            }

            // ASSERT that test fail is true, and PASS the test:
            Assert.IsTrue(_fail, "NullInstanceException thrown for test fail!");

            #endregion
        }

        #endregion

        #endregion
    }
}
