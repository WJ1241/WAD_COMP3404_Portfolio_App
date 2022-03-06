using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using App.Services;
using Server.GeneralInterfaces;

namespace TestApp.IndividualTests
{
    /// <summary>
    /// Test Class which checks if CommandInvoker is behaving as expected
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 06/03/22
    /// </summary>
    [TestClass]
    public class ServiceLocatorTest
    {
        #region FIELD VARIABLES

        // DECLARE an IServiceLocator, name it '_serviceLocator':
        private IServiceLocator _serviceLocator;

        // DECLARE a Mock<IFactory<IService>>, name it: _mockServiceFactory:
        private Mock<IFactory<IService>> _mockServiceFactory;

        #endregion


        #region RETURN SPECIFIED SERVICE

        /// <summary>
        /// Returns an active instance of a specified IService implementation
        /// </summary>
        [TestMethod]
        private void ReturnSpecifiedService()
        {
            #region ARRANGE



            #endregion


            #region ACT



            #endregion


            #region ASSERT

            // ASSERT that 

            #endregion
        }

        #endregion


        #region SETUP METHODS

        /// <summary>
        /// Creates and Initialises this class' dependencies
        /// </summary>
        [TestInitialize]
        private void SetupApplication()
        {

        }

        #endregion
    }
}
