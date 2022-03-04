using Microsoft.VisualStudio.TestTools.UnitTesting;
using GUI.Forms.Interfaces;
using Server.CustomEventArgs;

namespace TestApp
{
    /// <summary>
    /// Test Class which checks if all necessary classes work together to allow the app to start
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 04/03/22
    /// 
    /// 
    /// 
    /// </summary>
    [TestClass]
    public class RunApplicationTest
    {
        #region FIELD VARIABLES

        // DECLARE an IEventListener<ImageEventArgs>, name it '_mockFishyHome':
        private IEventListener<ImageEventArgs> _mockFishyHome;

        // DECLARE an IEventListener<ImageEventArgs>, name it '_mockFishyEdit':
        private IEventListener<ImageEventArgs> _mockFishyEdit;

        #endregion


        #region CREATE FISHYEDIT

        /// <summary>
        /// Checks if a FishyEdit object is created successfully
        /// </summary>
        [TestMethod]
        public void Create_FishyEdit()
        {
            #region ARRANGE

            // DECLARE 

            #endregion


            #region ACT

            // CALL EditButtonClick() on _mockFishyHome:

            #endregion


            #region ASSERT

            // ASSERT if _mockFishyEdit has an active instance:


            #endregion
        }

        #endregion
    }
}
