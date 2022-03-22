using System;
using System.Drawing;

namespace TestGUI.Interfaces
{
    /// <summary>
    /// Interface which allows implementations to have accessible bool Properties to ensure that EventHandlers are being used correctly
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 13/03/22
    /// </summary>
    public interface IMockFishyHome
    {
        #region EVENTS

        /// <summary>
        /// Event Method which is invoked when a user clicks on the 'Load' button
        /// THIS IS FOR TESTING PURPOSES ONLY, IN PRODUCTION CODE, THIS WILL BE BUILT INTO WINDOWS FORMS
        /// </summary>
        /// <param name="pSource"> Object calling this method </param>
        /// <param name="pArgs"> Necessary arguments in order complete behaviour </param>
        void LoadBttn_Click(object pSource, EventArgs pArgs);

        #endregion


        #region PROPERTIES

        /// <summary>
        /// Property which allows read access to an Image currently displayed
        /// </summary>
        Image ImgDisplay { get; set; }

        /// <summary>
        /// Property which allows read access to a boolean to test if ImgChangeEvent was called
        /// </summary>
        bool ImgChangeEventCalled { get; }

        /// <summary>
        /// Property which allows read access to a boolean to test if StringListEvent was called
        /// </summary>
        bool StringListEventCalled { get; }

        #endregion
    }
}

