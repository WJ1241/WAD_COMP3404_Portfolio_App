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

        - Finish Testing ImageServer
        - Get Controller initialised with Dictionary
        - Get Controller initialised with MockFishyHome (Needed for RunApplicationTest to pass otherwise an actual Form will be used)
        - (MAYBE, INSTEAD CALL GETSERVICE() FIRST AND STORE REFERENCE TO IT) Get Controller initialised with ImageServer
        */

        // DECLARE an IServer, name it '_imageServer':
        private IServer _imageServer;

        // DECLARE a Mock<IEditImg>, name it '_mockImageEditor':
        private Mock<IEditImg> _mockImageEditor;

        // DECLARE a Mock<IManagerImg>, name it '_mockImageMgr':
        private Mock<IManageImg> _mockImageMgr;

        #endregion 


        #region IMAGESERVERTEST
        /// <summary>
        /// Checks if a returned service is an active instance as well as an IService implementation
        /// </summary>
        [TestMethod]
        public void Call_Rotate_Clockwise_Method()
        { 
            #region ARRANGE

            // DECLARE variable '_pass' as type bool - set to TRUE
            bool _pass = true;

            #endregion


            #region ACT

            // CALL _imageServer.RotateImage(), passing a blank string as a parameter:
            _imageServer.RotateImage("..\\..\\..\\..\\Server\\FishAssets\\OrangeFish.png");

            #endregion


            #region ASSERT

            // TRY checking if 
            try
            {
                // VERIFY that _mockImageEditor has been called ONCE, makes sure that method is not called twice or more:
                _mockImageEditor.Verify(_mock => _mock.ImgRotateClockwise(Image.FromFile("..\\..\\..\\..\\Server\\Displayables\\FishAssets\\OrangeFish.png")), Times.Once);
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

                Assert.IsTrue(_pass, "ERROR: ");
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
