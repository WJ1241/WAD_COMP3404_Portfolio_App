using System;
using System.Drawing;
using GUI.Forms.Interfaces;
using Server.Commands;
using Server.CustomEventArgs;
using Server.InitialisingInterfaces;

namespace TestApp.MockClasses
{
    /// <summary>
    /// Mock Class for 'FishyHome' due to errors with testing Windows Forms
    /// Authors: William Smith, William Eardley & Declan Kerby-Collins
    /// Date: 08/03/22
    /// </summary>
    public class MockFishyHome : IDisposable, IEventListener<ImageEventArgs>, IInitialiseParam<Action<ICommand>>, IInitialiseParam<ICommand>
    {
        #region FIELD VARIABLES

        // DECLARE an Action<ICommand>, name it '_invokeCommand':
        private Action<ICommand> _invokeCommand;

        // DECLARE an ICommand, name it '_createEditScrn':
        private ICommand _createEditScrn;

        // DECLARE an Image, name it '_crrntImg':
        private Image _crrntImg;

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


        #region IMPLEMENTATION OF IGETIMAGETEST

        /// <summary>
        /// Property which allows only read access to an Image
        /// </summary>
        public Image Img
        {
            get
            {
                // RETURN value of _crrntImg:
                return _crrntImg;
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
            // SET value of _crrntImg to value of pArgs.Img:
            _crrntImg = pArgs.Img;
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<ACTION<ICOMMAND>>

        /// <summary>
        /// Initialises an object with an Action<ICommand> reference
        /// </summary>
        /// <param name="pAction"> Action<ICommand> reference </param>
        public void Initialise(Action<ICommand> pAction)
        {
            // INITIALISE _invokeCommand with reference to pAction:
            _invokeCommand = pAction;
        }

        #endregion


        #region IMPLEMENTATION OF IEVENTLISTENERIINITIALISEPARAM<ICOMMAND>

        /// <summary>
        /// Initialises an object with an ICommand object
        /// </summary>
        /// <param name="pCommand"> ICommand object </param>
        public void Initialise(ICommand pCommand)
        {
            // INITIALISE _createEditScrn with reference to pCommand:
            _createEditScrn = pCommand;
        }

        #endregion


        #region PUBLIC METHODS

        /// <summary>
        /// Mock Method which is used to simulate when user clicks 'Edit' Button
        /// </summary>
        /// <param name="pSource"> Object calling this method </param>
        /// <param name="pArgs"> Necessary arguments to complete behaviour </param>
        public void EditButtonClick(object pSource, EventArgs pArgs)
        {
            // INVOKE _createEditScrn:
            _invokeCommand(_createEditScrn);
        }

        #endregion
    }
}
