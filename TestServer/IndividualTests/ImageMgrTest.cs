using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;
using Server.Exceptions;
using Server.GeneralInterfaces;

namespace TestServer.IndividualTests
{
    /// <summary>
    /// Test Class for methods within the 'ImageMgr' class
    /// Author: William Smith
    /// Date: 03/12/21
    /// </summary>
    [TestClass]
    public class ImageMgrTest
    {
        #region FILTERED LIST TESTS

        #region PASS

        /// <summary>
        /// Test Method for ReturnFilteredList, with two different image file paths to PASS test
        /// </summary>
        [TestMethod]
        public void ReturnFilteredListPass()
        {
            #region ARRANGE

            // DECLARE & INSTANTIATE an IManageImg as a new ImageMgr, name it _imgMgr:
            IManageImg _imgMgr = new ImageMgr();

            // DECLARE & INSTANTIATE an IList<String> as a new List<String>, name it '_tempList':
            IList<String> _tempList = new List<String>();

            // ADD 1st string to _tempList:
            _tempList.Add("..\\..\\..\\..\\Server\\Displayables\\FishAssets\\JavaFish.png");

            // ADD 2nd string to _tempList:
            _tempList.Add("..\\..\\..\\..\\Server\\Displayables\\FishAssets\\OrangeFish.png");

            #endregion

            #region ACT

            // TRY checking if ReturnFilteredList() throws an exception:
            try
            {
                // CALL & STORE result from _imgMgr.ReturnFilteredList, passing initial _tempList as a parameter:
                _tempList = _imgMgr.ReturnFilteredList(_tempList);
            }

            #endregion

            #region ASSERT

            // CATCH FileAlreadyStoredException from ReturnFilteredList():
            catch (FileAlreadyStoredException pException)
            {
                // FAIL test, passing exception message as a parameter:
                Assert.Fail(pException.Message);
            }

            #endregion
        }

        #endregion


        #region FAIL

        /// <summary>
        /// Test Method for ReturnFilteredList, with two of the same image file paths to FAIL test
        /// </summary>
        [TestMethod]
        public void ReturnFilteredListFail()
        {
            #region ARRANGE

            // DECLARE & INSTANTIATE an IManageImg as a new ImageMgr, name it _imgMgr:
            IManageImg _imgMgr = new ImageMgr();

            // DECLARE & INSTANTIATE an IList<String> as a new List<String>, name it '_tempList':
            IList<String> _tempList = new List<String>();

            // DECLARE & INITIALISE a bool, name it '_fail', give value of 'false' to change to 'true' if failed:
            bool _fail = false;

            // ADD 1st string to _tempList:
            _tempList.Add("..\\..\\..\\..\\Server\\Displayables\\FishAssets\\JavaFish.png");

            // ADD 2nd string to _tempList:
            _tempList.Add("..\\..\\..\\..\\Server\\Displayables\\FishAssets\\JavaFish.png");

            #endregion

            #region ACT

            // TRY checking if ReturnFilteredList() throws an exception:
            try
            {
                // CALL & STORE result from _imgMgr.ReturnFilteredList, passing initial _tempList as a parameter:
                _tempList = _imgMgr.ReturnFilteredList(_tempList);
            }

            #endregion

            #region ASSERT

            // CATCH FileAlreadyStoredException from ReturnFilteredList():
            catch (FileAlreadyStoredException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);

                // SET _fail to true:
                _fail = true;
            }

            // ASSERT that test fail is true, and PASS the test:
            Assert.IsTrue(_fail, "FileAlreadyStoredException NOT thrown for test fail!");

            #endregion
        }

        #endregion

        #endregion


        #region RETURN IMAGE REFERENCE TESTS

        #region PASS

        /// <summary>
        /// Test Method for ReturnImg(String), with one file path added to dictionary and retrieved in a temporary image to PASS test
        /// </summary>
        [TestMethod]
        public void ReturnImgOneParamPass()
        {
            #region ARRANGE

            // DECLARE & INSTANTIATE an IManageImg as a new ImageMgr, name it _imgMgr:
            IManageImg _imgMgr = new ImageMgr();

            // DECLARE & INSTANTIATE an IList<String> as a new List<String>, name it '_tempList':
            IList<String> _tempList = new List<String>();

            // DECLARE an Image, name it '_tempImage':
            Image _tempImage;

            // ADD 1st string to _tempList:
            _tempList.Add("..\\..\\..\\..\\Server\\Displayables\\FishAssets\\JavaFish.png");

            // CALL & STORE result from _imgMgr.ReturnFilteredList, passing initial _tempList as a parameter:
            _tempList = _imgMgr.ReturnFilteredList(_tempList);

            #endregion

            #region ACT

            // TRY checking if ReturnImg() throws an exception:
            try
            {
                // CALL ReturnImg, passing index 0 of _tempList, store in _tempImage:
                _tempImage = _imgMgr.ReturnImg(_tempList[0]);
            }

            #endregion

            #region ASSERT

            // CATCH InvalidStringException from ReturnImg():
            catch (InvalidStringException pException)
            {
                // FAIL test, passing exception message as a parameter:
                Assert.Fail(pException.Message);
            }

            #endregion
        }

        #endregion


        #region FAIL

        /// <summary>
        /// Test Method for ReturnImg(String), with one file path added to dictionary, with one NOT added and retrieved in a temporary image to FAIL test
        /// </summary>
        [TestMethod]
        public void ReturnImgOneParamFail()
        {
            #region ARRANGE

            // DECLARE & INSTANTIATE an IManageImg as a new ImageMgr, name it _imgMgr:
            IManageImg _imgMgr = new ImageMgr();

            // DECLARE & INSTANTIATE an IList<String> as a new List<String>, name it '_tempList':
            IList<String> _tempList = new List<String>();

            // DECLARE & INITIALISE a bool, name it '_fail', give value of 'false' to change to 'true' if failed:
            bool _fail = false;

            // DECLARE an Image, name it '_tempImage':
            Image _tempImage;

            // ADD 1st string to _tempList:
            _tempList.Add("..\\..\\..\\..\\Server\\Displayables\\FishAssets\\JavaFish.png");

            // CALL & STORE result from _imgMgr.ReturnFilteredList, passing initial _tempList as a parameter:
            _tempList = _imgMgr.ReturnFilteredList(_tempList);

            // ADD 2nd string to _tempList, not added to _imgMgr dictionary:
            _tempList.Add("..\\..\\..\\..\\Server\\Displayables\\FishAssets\\OrangeFish.png");

            #endregion

            #region ACT

            // TRY checking if ReturnImg() throws an exception:
            try
            {
                // CALL ReturnImg, passing index 1 of _tempList, store in _tempImage:
                _tempImage = _imgMgr.ReturnImg(_tempList[1]);
            }

            #endregion

            #region ASSERT

            // CATCH InvalidStringException from ReturnImg():
            catch (InvalidStringException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);

                // SET _fail to true:
                _fail = true;
            }

            // ASSERT that test fail is true, and PASS the test:
            Assert.IsTrue(_fail, "InvalidStringException NOT thrown for test fail!");

            #endregion
        }

        #endregion

        #endregion


        #region RETURN MODIFIED IMAGE TESTS

        #region PASS

        /// <summary>
        /// Test Method for ReturnImg(String, int, int), with one file path added to dictionary and retrieved in a temporary image to PASS test
        /// </summary>
        [TestMethod]
        public void ReturnImgThreeParamPass()
        {
            #region ARRANGE

            // DECLARE & INSTANTIATE an IManageImg as a new ImageMgr, name it _imgMgr:
            IManageImg _imgMgr = new ImageMgr();

            // DECLARE & INSTANTIATE an IList<String> as a new List<String>, name it '_tempList':
            IList<String> _tempList = new List<String>();

            // DECLARE an Image, name it '_tempImage':
            Image _tempImage;

            // ADD 1st string to _tempList:
            _tempList.Add("..\\..\\..\\..\\Server\\Displayables\\FishAssets\\JavaFish.png");

            // CALL & STORE result from _imgMgr.ReturnFilteredList, passing initial _tempList as a parameter:
            _tempList = _imgMgr.ReturnFilteredList(_tempList);

            #endregion

            #region ACT

            // TRY checking if ReturnImg() throws an exception:
            try
            {
                // CALL ReturnImg, passing index 0 of _tempList, width and height, store in _tempImage:
                _tempImage = _imgMgr.ReturnImg(_tempList[0], 300, 300);
            }

            #endregion

            #region ASSERT

            // CATCH InvalidStringException from ReturnImg():
            catch (InvalidStringException pException)
            {
                // FAIL test, passing exception message as a parameter:
                Assert.Fail(pException.Message);
            }

            #endregion
        }

        #endregion


        #region FAIL

        /// <summary>
        /// Test Method for ReturnImg(String, int, int), with one file path added to dictionary, with one NOT added and retrieved in a temporary image to FAIL test
        /// </summary>
        [TestMethod]
        public void ReturnImgThreeParamFail()
        {
            #region ARRANGE

            // DECLARE & INSTANTIATE an IManageImg as a new ImageMgr, name it _imgMgr:
            IManageImg _imgMgr = new ImageMgr();

            // DECLARE & INSTANTIATE an IList<String> as a new List<String>, name it '_tempList':
            IList<String> _tempList = new List<String>();

            // DECLARE & INITIALISE a bool, name it '_fail', give value of 'false' to change to 'true' if failed:
            bool _fail = false;

            // DECLARE an Image, name it '_tempImage':
            Image _tempImage;

            // ADD 1st string to _tempList:
            _tempList.Add("..\\..\\..\\..\\Server\\Displayables\\FishAssets\\JavaFish.png");

            // CALL & STORE result from _imgMgr.ReturnFilteredList, passing initial _tempList as a parameter:
            _tempList = _imgMgr.ReturnFilteredList(_tempList);

            // ADD 2nd string to _tempList, not added to _imgMgr dictionary:
            _tempList.Add("..\\..\\..\\..\\Server\\Displayables\\FishAssets\\OrangeFish.png");

            #endregion

            #region ACT

            // TRY checking if ReturnImg() throws an exception:
            try
            {
                // CALL ReturnImg, passing index 1 of _tempList, width and height, store in _tempImage:
                _tempImage = _imgMgr.ReturnImg(_tempList[1], 300, 300);
            }

            #endregion

            #region ASSERT

            // CATCH InvalidStringException from ReturnImg():
            catch (InvalidStringException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);

                // SET _fail to true:
                _fail = true;
            }

            // ASSERT that test fail is true, and PASS the test:
            Assert.IsTrue(_fail, "InvalidStringException NOT thrown for test fail!");

            #endregion
        }

        #endregion

        #endregion
    }
}