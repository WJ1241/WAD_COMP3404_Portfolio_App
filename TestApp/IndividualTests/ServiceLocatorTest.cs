using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using App.Services;
using App.Services.Factories;
using App.Services.Factories.Interfaces;
using App.Services.Interfaces;
using Server.GeneralInterfaces;
using Server.InitialisingInterfaces;

namespace TestApp.IndividualTests
{
    /// <summary>
    /// Test Class which checks if ServiceLocator is behaving as expected
    /// Authors: William Smith, William Eardley & Declan Kerby-Collins
    /// Date: 07/03/22
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


        #region INITIALISE FACTORY

        /// <summary>
        /// Checks if CommandInvoker calls 'Execute()' on an ICommand successfully
        /// </summary>
        [TestMethod]
        public void Call_Create_On_IService_Factory()
        {
            #region ARRANGE

            // DECLARE an IService, name it 'tempService':
            IService tempService;

            // DECLARE & INITIALISE a bool, name it 'pass', set to true so test passes if not changed:
            bool pass = true;

            #endregion


            #region ACT

            // CALL _serviceLocator.GetService() and store return value in tempService:
            tempService = _serviceLocator.GetService<Factory<IServiceLocator>>();

            #endregion


            #region ASSERT

            // TRY checking if _mockServiceFactory.Create<Factory<IServiceLocator>> was called:
            try
            {
                // VERIFY that _mockServiceFactory.Create<Factory<IServiceLocator>>() has been called ONCE, makes sure that method is not called more than once:
                _mockServiceFactory.Verify(_mockServiceFactory => _mockServiceFactory.Create<Factory<IServiceLocator>>(), Times.Once);
            }
            // CATCH MockException from Verify():
            catch (MockException)
            {
                // SET pass to false, so that test fails:
                pass = false;
            }
            // FINALISE try and catch block with test pass/fail:
            {
                // ASSERT if test has passed, and give corresponding message if pass is false:
                Assert.IsTrue(pass, "ERROR: _mockServiceFactory.Create<Factory<IServiceLocator>>() has not been called!");
            }

            #endregion
        }

        #endregion


        #region RETURN SPECIFIED SERVICE

        /// <summary>
        /// Checks if a returned service is an active instance as well as an IService implementation
        /// </summary>
        [TestMethod]
        public void Return_Specified_Service()
        {
            #region ARRANGE

            // DECLARE an IService, name it 'tempService':
            IService tempService;

            #endregion


            #region ACT

            // CALL _serviceLocator.GetService() and store return value in tempService:
            tempService = _serviceLocator.GetService<Factory<IServiceLocator>>();

            #endregion


            #region ASSERT

            // IF tempService DOES NOT HAVE an active instance AND DOES NOT implement IService:
            if (tempService == null || !(tempService is IService))
            {
                // IF tempService DOES NOT HAVE an active instance:
                if (tempService == null)
                {
                    // ASSERT a fail due to tempService being a null instance:
                    Assert.Fail("ERROR: ServiceLocator has not returned an active instance of the specified service!");
                }
                // IF tempService DOES NOT implement IService:
                else if (!(tempService is IService))
                {
                    // ASSERT a fail due to tempService being a null instance:
                    Assert.Fail("ERROR: ServiceLocator has returned an object that does not implement IService!");
                }
            }
            // IF tempService DOES HAVE an active instance AND DOES implement IService:
            else if (tempService != null && tempService is IService)
            {
                // WRITE to console that _serviceLocator has returned an active instance of IService:
                System.Console.WriteLine("ServiceLocator has successfully returned an active instance that implements IService!");
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
            // INSTANTIATE _mockServiceFactory as a new Mock<IFactory<IService>>():
            _mockServiceFactory = new Mock<IFactory<IService>>();

            // SETUP _mockServiceFactory.Create(), so that it can return a new ServiceLocator():
            _mockServiceFactory.Setup(mock => mock.Create<ServiceLocator>()).Returns(new ServiceLocator());

            // SETUP _mockServiceFactory.Create(), so that it can return a new Factory<IServiceLocator>>():
            // USED FOR TESTING WHETHER GETSERIVCE() RETURNS AN ACTIVE INSTANCE
            _mockServiceFactory.Setup(_mockServiceFactory => _mockServiceFactory.Create<Factory<IServiceLocator>>()).Returns(new Factory<IServiceLocator>());

            // INSTANTIATE _serviceLocator as a new ServiceLocator():
            _serviceLocator = _mockServiceFactory.Object.Create<ServiceLocator>() as IServiceLocator;

            // INITIALISE _serviceLocator with a reference to _mockServiceFactory.Object:
            (_serviceLocator as IInitialiseParam<IFactory<IService>>).Initialise(_mockServiceFactory.Object);
        }

        #endregion
    }
}