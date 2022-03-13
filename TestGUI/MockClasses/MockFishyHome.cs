using System;
using System.Collections.Generic;
using GUI.Forms.Interfaces;
using GUI.Logic.Interfaces;
using Server.Commands;
using Server.CustomEventArgs;
using Server.GeneralInterfaces;
using Server.InitialisingInterfaces;
using TestGUI.Interfaces;

namespace TestApp.MockClasses
{
    /// <summary>
    /// Mock Class for 'FishyHome' due to errors with testing Windows Forms
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 13/03/22
    /// </summary>
    public class MockFishyHome : IMockFishyHome, IChangeImg, ICommandSender, IDisposable, IEventListener<ImageEventArgs>, IEventListener<StringListEventArgs>, IInitialiseParam<ICommand>,
        IInitialiseParam<IDictionary<int, string>>, IInitialiseParam<IDictionary<string, ICommand>>, IInitialiseParam<IOpenImage>
    {
        #region FIELD VARIABLES

        // DECLARE an IDictionary<int, string>, name it '_imgFPDict':
        private IDictionary<int, string> _imgFPDict;

        // DECLARE an IDictionary<string, ICommand>, name it '_commandDict':
        private IDictionary<string, ICommand> _commandDict;

        // DECLARE an IOpenImage, name it '_imgOpen':
        private IOpenImage _imgOpen;

        // DECLARE an Action<ICommand>, name it '_invokeCommand':
        private Action<ICommand> _invokeCommand;

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
        /// Event Method which is invoked when a user clicks on the 'Load' button
        /// THIS IS FOR TESTING PURPOSES ONLY, IN PRODUCTION CODE, THIS WILL BE BUILT INTO WINDOWS FORMS
        /// </summary>
        /// <param name="pSource"> Object calling this method </param>
        /// <param name="pArgs"> Necessary arguments in order complete behaviour </param>
        public void LoadBttn_Click(object pSource, EventArgs pArgs)
        {
            // SET value of _commandDict["Load"]'s FirstParam property to return value of _imgOpen.OpenImage():
            (_commandDict["Load"] as ICommandParam<IList<string>>).FirstParam = _imgOpen.OpenImage();

            // INVOKE _commandDict["Load"]'s ExecuteMethod():
            _invokeCommand(_commandDict["Load"]);
        }

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


        #region IMPLEMENTATION OF ICHANGEIMG

        /// <summary>
        /// Changes currently displayed image to a desired image
        /// </summary>
        public void ChangeImg()
        {
            // SET value of _commandDict["GetImage"]'s FirstParam property to "Example"):
            (_commandDict["GetImage"] as ICommandParam<string, int, int>).FirstParam = "Example";

            // SET value of _commandDict["GetImage"]'s SecondParam property to '1':
            (_commandDict["GetImage"] as ICommandParam<string, int, int>).SecondParam = 1;

            // SET value of _commandDict["GetImage"]'s ThirdParam property to '1':
            (_commandDict["GetImage"] as ICommandParam<string, int, int>).ThirdParam = 1;

            // INVOKE _commandDict["GetImage"]'s ExecuteMethod():
            _invokeCommand(_commandDict["GetImage"]);
        }

        #endregion


        #region IMPLEMENTATION OF ICOMMANDSENDER

        /// <summary>
        /// Property which allows write access to a command invoking Action
        /// </summary>
        public Action<ICommand> InvokeCommand
        {
            set
            {
                // SET value of _invokeCommand to incoming value:
                _invokeCommand = value;
            }
        }

        #endregion


        #region IMPLEMENTATION OF IDISPOSABLE

        /// <summary>
        /// Disposes of this instance to release unnecessary resource allocation
        /// </summary>
        public void Dispose()
        {
            // ONLY USED AS 'FORM' ALREADY IMPLEMENTS IDISPOSABLE
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

            // CALL ChangeImg():
            ChangeImg();
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<ICOMMAND>

        /// <summary>
        /// Initialises an object with an ICommand object
        /// </summary>
        /// <param name="pCommand"> ICommand object with an executable method and possible parameter(s) </param>
        public void Initialise(ICommand pCommand)
        {
            // ADD pCommand.Name as a key, and pCommand as a value to _commandDict:
            _commandDict.Add((pCommand as IName).Name, pCommand);
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<IDICTIONARY<STRING, ICOMMAND>>

        /// <summary>
        /// Initialises an object with an IDictionary<string, ICommand> object
        /// </summary>
        /// <param name="pCommand"> IDictionary<string, ICommand> object </param>
        public void Initialise(IDictionary<string, ICommand> pCommandDict)
        {
            // INITIALISE _commandDict with reference to pCommandDict:
            _commandDict = pCommandDict;
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<IDICTIONARY<STRING, ICOMMAND>>

        /// <summary>
        /// Initialises an object with an IDictionary<string, ICommand> object
        /// </summary>
        /// <param name="pCommand"> IDictionary<string, ICommand> object </param>
        public void Initialise(IDictionary<int, string> pStringDict)
        {
            // INITIALISE _imgFPDict with reference to pStringDict:
            _imgFPDict = pStringDict;
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<IOPENIMAGE>

        /// <summary>
        /// Initialises an object with an 'IOpenImage' instance
        /// </summary>
        /// <param name="pOpenImage"> Instance of IOpenImage </param>
        public void Initialise(IOpenImage pOpenImage)
        {
            // INITIALISE _imgOpen with reference to pOpenImage:
            _imgOpen = pOpenImage;
        }

        #endregion
    }
}
