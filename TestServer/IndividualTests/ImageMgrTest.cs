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
    /// Date: 14/03/22
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


        #region RETURN IMAGE REFERENCE TESTS

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


        #region RETURN MODIFIED IMAGE TESTS

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


        #region SETUP METHODS

        /// <summary>
        /// Creates and Initialises this class' dependencies
        /// </summary>
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
