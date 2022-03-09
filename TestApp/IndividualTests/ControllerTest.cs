using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using App.GeneralInterfaces;
using App.Services;

namespace TestApp.IndividualTests
{
    /// <summary>
    /// Test Class which checks if Controller is behaving as expected
    /// Authors: William Smith, William Eardley & Declan Kerby-Collins
    /// Date: 09/03/22
    /// </summary>
    public class ControllerTest
    {
        #region FIELD VARIABLES

        // DECLARE an IController, name it '_controller':
        private IController _controller;

        // DECLARE a Mock<IDictionary<int, IDisposable>>, name it '_mockDisposableDict':
        private Mock<IDictionary<int, IDisposable>> _mockDisposableDict;

        // DECLARE a Mock<IServiceLocator>, name it '_mockServiceLocator':
        private Mock<IServiceLocator> _mockServiceLocator;

        // DECLARE a Mock<IDisposable>, name it '_mockFishyHome':
        private Mock<IDisposable> _mockFishyHome;

        #endregion


        #region INITIALISE SERVER TESTS


        #endregion


        #region INITIALISING MOCKFISHYHOME TESTS



        #endregion


        #region CREATING MOCKFISHYEDIT TESTS


        #endregion


        #region INITIALISING FISHYEDIT TESTS


        #endregion


        #region REMOVE DISPOSABLE


        #endregion


        #region SETUP METHODS

        /// <summary>
        /// Creates and Initialises this class' dependencies
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _mockServiceLocator.Setup(_mock => _mock.GetService<>);
        }

        #endregion
    }
}
