using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.GeneralInterfaces;
using Server;
using Server.Exceptions;
using System.Text;
using Moq;
using Server.InitialisingInterfaces;

namespace TestServer.IndividualTests
{
    /// <summary>
    /// CLASS 'ImageServerTest'
    /// </summary>
    [TestClass]
    public class ImageServerTest 
    {
        // DECLARE...
        private IServer _imageServer;

        private Mock<IEditImg> _imageEditor;

        private Mock<IManageImg> _imageManager;

        Mock<Image> _image = new Mock<Image>();

        #region IMAGESERVERTEST
        /// <summary>
        /// TEST METHOD: Creats a MOCK of the CreateImageServer class
        /// </summary>
        [TestMethod]
        public void CreateImageServer()
        { 
            #region ARRANGE
            
            

            // DECLARE variable '_pass' as type bool - set to TRUE
            bool _pass = true;



            #endregion


            #region ACT

            // TRY CATCH BLOCK
            // TRY To Execute
            try
            {
                _imageServer.RotateImage();
            }
           
            #endregion


            #region ASSERT

            // CATCH 'MockException' exception
            catch (MockException e)
            {
                _pass = false;
            }
            // CALL 'Finally' regardless of PASS or FAIL
            finally
            {
                Assert.IsTrue(_pass, "ERROR: ");
            }

            #endregion

        }
        #endregion

        #region SETUPMETHODS

        /// <summary>
        /// 
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            // INSTANTIATE a new ImageEditor called '_imageEditor'
            _imageServer = new ImageServer();

            _imageEditor = new Mock<IEditImg>();

            _imageManager = new Mock<IManageImg>();

            (_imageServer as IInitialiseParam<IEditImg>).Initialise(_imageEditor.Object);

            (_imageServer as IInitialiseParam<IManageImg>).Initialise(_imageManager.Object);
        }

        #endregion

    }
}
