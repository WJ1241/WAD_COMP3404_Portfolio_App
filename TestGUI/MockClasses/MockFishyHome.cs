using System;
using GUI.Forms.Interfaces;
using Server.Commands;
using Server.CustomEventArgs;
using TestGUI.Interfaces;

namespace TestApp.MockClasses
{
    /// <summary>
    /// Mock Class for 'FishyHome' due to errors with testing Windows Forms
    /// Authors: William Smith, William Eardley & Declan Kerby-Collins
    /// Date: 09/03/22
    /// </summary>
    public class MockFishyHome : IMockFishyHome, IEventListener<ImageEventArgs>, IEventListener<StringListEventArgs>
    {
        #region FIELD VARIABLES

        // DECLARE a bool, name it '_imgEventCalled':
        private bool _imgEventCalled;

        // DECLARE a bool, name it '_stringListEventCalled':
        private bool _stringListEventCalled;

        #endregion


        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of MockFishyHome
        /// </summary>
        public MockFishyHome()
        {
            // EMPTY CONSTRUCTOR
        }

        #endregion


        #region IMPLEMENTATION OF IMOCKFISHYHOME

        /// <summary>
        /// Property which allows read access to a boolean to test if ImgChangeEvent was called
        /// </summary>
        public bool ImgChangeEventCalled 
        {
            get 
            {
                // RETURN _imgEventCalled:
                return _imgEventCalled;
            }
        }

        /// <summary>
        /// Property which allows read access to a boolean to test if StringListEvent was called
        /// </summary>
        public bool StringListEventCalled 
        {
            get
            {
                // RETURN _stringListEventCalled:
                return _stringListEventCalled;
            }
        }

        #endregion


        #region IMPLEMENTATION OF IEVENTLISTENER<IMAGEEVENTARGS>

        /// <summary>
        /// Method called when needing to update an Image
        /// </summary>
        /// <param name="pSource"> Object calling this method </param>
        /// <param name="pArgs"> Necessary arguments in order to modify an Image </param>
        public void OnEvent(object pSource, ImageEventArgs pArgs)
        {
            // SET _imgEventCalled to true:
            _imgEventCalled = true;
        }

        #endregion


        #region IMPLEMENTATION OF IEVENTLISTENER<STRINGLISTEVENTARGS>

        /// <summary>
        /// Method called when needing to update an stringList
        /// </summary>
        /// <param name="pSource"> Object calling this method </param>
        /// <param name="pArgs"> Necessary arguments in order to modify an Image </param>
        public void OnEvent(object pSource, StringListEventArgs pArgs)
        {
            // SET _stringListEventCalled to true:
            _stringListEventCalled = true;
        }

        #endregion


    }
}
