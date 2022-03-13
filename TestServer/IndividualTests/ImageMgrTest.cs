using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;
using Server.Exceptions;
using Server.GeneralInterfaces;
using Server.InitialisingInterfaces;

namespace TestServer.IndividualTests
{
    /// <summary>
    /// Test Class for methods within the 'ImageMgr' class
    /// Author: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 13/03/22
    /// </summary>
    [TestClass]
    public class ImageMgrTest
    {
        #region FIELD VARIABLES

        // DECLARE an IManageImg, name it '_imgMgr':
        private IManageImg _imgMgr;

        // DECLARE an IList<string>, name it '_tempList':
        private IList<string> _tempList;

        #endregion


        #region FILTERED LIST TESTS

        #region PASS

        /// <summary>
        /// Test Method for ReturnFilteredList, with two different image file paths to PASS test
        /// </summary>
        [TestMethod]
        public void ReturnFilteredListPass()
        {
            #region ARRANGE

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
        /// Test Method for ReturnImg(string), with one file path added to dictionary and retrieved in a temporary image to PASS test
        /// </summary>
        [TestMethod]
        public void ReturnImgOneParamPass()
        {
            #region ARRANGE

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
        /// Test Method for ReturnImg(string), with one file path added to dictionary, with one NOT added and retrieved in a temporary image to FAIL test
        /// </summary>
        [TestMethod]
        public void ReturnImgOneParamFail()
        {
            #region ARRANGE

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
        /// Test Method for ReturnImg(string, int, int), with one file path added to dictionary and retrieved in a temporary image to PASS test
        /// </summary>
        [TestMethod]
        public void ReturnImgThreeParamPass()
        {
            #region ARRANGE

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
        /// Test Method for ReturnImg(string, int, int), with one file path added to dictionary, with one NOT added and retrieved in a temporary image to FAIL test
        /// </summary>
        [TestMethod]
        public void ReturnImgThreeParamFail()
        {
            #region ARRANGE

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


        #region SETUP METHODS

        [TestInitialize]
        public void Setup()
        {
            // INSTANTIATE _imgMgr as a new ImageMgr():
            _imgMgr = new ImageMgr();

            // INITIALISE _imgMgr with a new Dictionary<string, Image>():
            (_imgMgr as IInitialiseParam<IDictionary<string, Image>>).Initialise(new Dictionary<string, Image>());

            // INSTANTIATE _tempList as a new List<string>():
            _tempList = new List<string>();
        }

        #endregion
    }
}
