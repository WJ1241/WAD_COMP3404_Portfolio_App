using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;
using Server.Exceptions;
using Server.GeneralInterfaces;

namespace TestServer.IndividualTests
{
    /// <summary>
    /// Test Class for methods within the 'ImgEditor' class
    /// Author: William Eardley, William Smith & Declan Kerby-Collins
    /// Date: 14/03/22
    /// </summary>
    [TestClass]
    public class ImageEditorTest
    {
        #region CLOCKWISE IMAGE ROTATION TEST

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


        #region ANTICLOCKWISE IMAGE ROTATION TESTS

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


        #region IMAGE X AXIS FLIP TESTS


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

            // TRY checking if ImgHFlip() throws an exception:
            try
            {
                // CALL ImgHFlip(), passing _image as a parameter:
                _editImg.ImgHFlip(_image);
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


        #region IMAGE Y AXIS FLIP TESTS

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

            // TRY checking if ImgVFlip() throws an exception:
            try
            {
                // CALL ImgVFlip(), passing _image as a parameter:
                _editImg.ImgVFlip(_image);
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
    }
}
