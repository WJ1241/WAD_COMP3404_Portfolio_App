using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using App.Services;
using App.Services.Factories;
using App.GeneralInterfaces;
using GUI;
using GUI.Forms.Interfaces;
using GUI.Logic;
using GUI.Logic.Interfaces;
using Server;
using Server.Exceptions;
using Server.GeneralInterfaces;
using Server.InitialisingInterfaces;
using Server.Commands;
using Server.CustomEventArgs;


namespace App
{
    /// <summary>
    /// Main Class of the application, stores reference to all objects required
    /// Author: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 12/03/22
    /// </summary>
    public class Controller : IController, ISetupApplication, IInitialiseParam<IDictionary<int, IDisposable>>, IInitialiseParam<IServiceLocator>
    {
        #region FIELD VARIABLES

        // DECLARE a IDictionary<int, IDisposable>, name it '_formDict':
        // IS CONCRETE FORM, HOWEVER IT NEEDS TO BE 'FORM' FOR APPLICATION.RUN() METHOD
        private IDictionary<int, IDisposable> _formDict;

        // DECLARE an IServiceLocator, name it '_serviceLocator':
        private IServiceLocator _serviceLocator;

        // DECLARE an IServer, name it _server:
        private IServer _server;

        // DECLARE an int, name it '_formCount':
        private int _formCount;

        #endregion

        
        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of Controller
        /// </summary>
        public Controller()
        {
            // INITIALISE _formCount with value of '0':
            _formCount = 0;
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<IDICTIONARY<INT, IDISPOSABLE>>

        /// <summary>
        /// Initialises an object with an IDictionary<int, IDisposable> object
        /// </summary>
        /// <param name="pDisposableDict"> IDictionary<int, IDisposable> object </param>
        public void Initialise(IDictionary<int, IDisposable> pDisposableDict)
        {
            // IF pDisposableDict DOES HAVE an active instance:
            if (pDisposableDict != null)
            {
                // INITIALISE _formDict with reference to pDict:
                _formDict = pDisposableDict;
            }
            // IF pDisposableDict DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: pDisposableDict does not have an active instance!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<ISERVICELOCATOR>

        /// <summary>
        /// Initialises an object with a instance of IServiceLocator
        /// </summary>
        /// <param name="pServiceLocator"> Instance of IServ </param>
        public void Initialise(IServiceLocator pServiceLocator)
        {
            // IF pServiceLocator DOES HAVE an active instance:
            if (pServiceLocator != null)
            {
                // INITIALISE _serviceLocator with instance of pServiceLocator:
                _serviceLocator = pServiceLocator;
            }
            // IF pServiceLocator DOES NOT HAVE an active instance:
            else
            {
                // THROW new NullInstance, with corresponding message:
                throw new NullInstanceException("ERROR: pServiceLocator does not have an active instance!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF ISETUPAPPLICATION

        /// <summary>
        /// Setups all necessary dependencies and requirements for an application to start
        /// </summary>
        public void SetupApplication()
        {
            #region FISHYHOME CREATION & INITIALISATION

            // TRY checking if ClassDoesNotExistException OR NullInstanceException are thrown:
            try
            {
                // ADD _formCount as a key and a new FishyHome as a value to _formDict:
                _formDict.Add(_formCount, (_serviceLocator.GetService<Factory<IDisposable>>() as IFactory<IDisposable>).Create<FishyHome>());

                // SET InvokeCommand property value of  _formDict[_formCount] (FishyHome) to reference to CommandInvoker.InvokeCommand:
                (_formDict[_formCount] as ICommandSender).InvokeCommand = (_serviceLocator.GetService<CommandInvoker>() as ICommandInvoker).InvokeCommand;

                // DECLARE & INSTANTIATE an IOpenImage as a new OpenLogic(), name it '_openImage':
                IOpenImage _openImage = (_serviceLocator.GetService<Factory<ILogic>>() as IFactory<ILogic>).Create<OpenLogic>() as IOpenImage;

                // INITIALISE _openImage with a new List<string>():
                (_openImage as IInitialiseParam<IList<string>>).Initialise((_serviceLocator.GetService<Factory<IEnumerable>>() as IFactory<IEnumerable>).Create<List<string>>() as IList<string>);

                // INITIALISE _formDict[_formCount] (FishyHome) with a new IOpenImage object:
                (_formDict[_formCount] as IInitialiseParam<IOpenImage>).Initialise(_openImage);

                // INITIALISE _formDict[_formCount] (FishyHome) with a new IDictionary<int, string> object:
                (_formDict[_formCount] as IInitialiseParam<IDictionary<int, string>>).Initialise(
                    (_serviceLocator.GetService<Factory<IEnumerable>>() as IFactory<IEnumerable>).Create<Dictionary<int, string>>() as IDictionary<int, string>);

                // INITIALISE _formDict[_formCount] (FishyHome) with a new IDictionary<string, ICommand> object: 
                (_formDict[_formCount] as IInitialiseParam<IDictionary<string, ICommand>>).Initialise(
                    (_serviceLocator.GetService<Factory<IEnumerable>>() as IFactory<IEnumerable>).Create<Dictionary<string, ICommand>>() as IDictionary<string, ICommand>);
            }
            // CATCH ClassDoesNotExistException from Create<C>():
            catch (ClassDoesNotExistException e)
            {
                // WRITE error message to debug console:
                Console.WriteLine(e.Message);
            }
            // CATCH NullInstanceException from Initialise():
            catch (NullInstanceException e)
            {
                // WRITE error message to debug console:
                Console.WriteLine(e.Message);
            }


            #region SERVER CREATION & INITIALISATION

            // TRY checking if ClassDoesNotExistException OR NullInstanceException are thrown:
            try
            {
                #region IMAGE SERVER

                // INSTANTIATE _server as a new ImageServer():
                _server = _serviceLocator.GetService<ImageServer>() as IServer;

                // INITIALISE _server with an IManageImg object:
                (_server as IInitialiseParam<IManageImg>).Initialise(_serviceLocator.GetService<ImageMgr>() as IManageImg);

                // INITIALISE _server with an IEditImg object:
                (_server as IInitialiseParam<IEditImg>).Initialise(_serviceLocator.GetService<ImageEditor>() as IEditImg);

                // INITIALISE _server with a new IDictionary<string, EventArgs> object:
                (_server as IInitialiseParam<IDictionary<string, EventArgs>>).Initialise(
                    (_serviceLocator.GetService<Factory<IEnumerable>>() as IFactory<IEnumerable>).Create<Dictionary<string, EventArgs>>() as IDictionary<string, EventArgs>);

                // INITIALISE _server with "Image" and a new EventArgs object:
                (_server as IInitialiseParam<string, EventArgs>).Initialise("Image", (_serviceLocator.GetService<Factory<EventArgs>>() as IFactory<EventArgs>).Create<ImageEventArgs>());

                // INITIALISE _server with "StringList" and a new EventArgs object:
                (_server as IInitialiseParam<string, EventArgs>).Initialise("StringList", (_serviceLocator.GetService<Factory<EventArgs>>() as IFactory<EventArgs>).Create<StringListEventArgs>());

                // SUBSCRIBE _server with _formDict[0].OnEvent (ImageEventArgs):
                (_server as ISubscribe<ImageEventArgs>).Subscribe((_formDict[0] as IEventListener<ImageEventArgs>).OnEvent);

                // SUBSCRIBE _server with _formDict[0].OnEvent (StringListEventArgs):
                (_server as ISubscribe<StringListEventArgs>).Subscribe((_formDict[0] as IEventListener<StringListEventArgs>).OnEvent);

                #endregion


                #region IMAGE MANAGER

                // INITIALISE returned ImageMgr with a new Dictionary<string, Image>():
                (_serviceLocator.GetService<ImageMgr>() as IInitialiseParam<IDictionary<string, Image>>).Initialise(
                    (_serviceLocator.GetService<Factory<IEnumerable>>() as IFactory<IEnumerable>).Create<Dictionary<string, Image>>() as IDictionary<string, Image>);

                #endregion
            }
            // CATCH ClassDoesNotExistException from Create<C>():
            catch (ClassDoesNotExistException e)
            {
                // WRITE error message to debug console:
                Console.WriteLine(e.Message);
            }
            // CATCH NullInstanceException from Initialise():
            catch (NullInstanceException e)
            {
                // WRITE error message to debug console:
                Console.WriteLine(e.Message);
            }

            #endregion


            #region FISHYHOME COMMANDS

            // TRY checking if ClassDoesNotExistException OR NullInstanceException are thrown:
            try
            {
                #region CREATE EDIT SCREEN COMMAND

                // DECLARE & INSTANTIATE an ICommandParam<string> as a new CommandParam<String>(), name it '_commandStringParam':
                ICommandParam<string> _commandStringParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>).Create<CommandParam<string>>() as ICommandParam<string>;

                // SET MethodRef Property of _commandStringParam to reference to CreateEditScrn():
                _commandStringParam.MethodRef = CreateEditScrn;

                // SET Name Property of _commandStringParam to "CreateEditScrn":
                (_commandStringParam as IName).Name = "CreateEditScrn";

                // INITIALISE _formDict[_formCount] (FishyHome) with a reference to _commandStringParam:
                (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(_commandStringParam);

                #endregion


                #region LOAD IMAGE COMMAND

                // DECLARE & INSTANTIATE an ICommandParam<String> as a new CommandParam<IList<string>>(), name it '_commandStringListParam':
                ICommandParam<IList<string>> _commandStringListParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>).Create<CommandParam<IList<string>>>() as ICommandParam<IList<string>>;

                // SET MethodRef Property of _commandStringListParam to reference to _server.Load():
                _commandStringListParam.MethodRef = _server.Load;

                // SET Name Property of _commandStringListParam to "Load":
                (_commandStringListParam as IName).Name = "Load";

                // INITIALISE _formDict[_formCount] (FishyHome) with a reference to _commandStringListParam:
                (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(_commandStringListParam);

                #endregion


                #region GET IMAGE COMMAND

                // DECLARE & INSTANTIATE an ICommandParam<String, int, int> as a new CommandParam<String, int, int>(), name it '_commandStringIntIntParam':
                ICommandParam<string, int, int> _commandStringIntIntParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>).Create<CommandParam<string, int, int>>() as ICommandParam<string, int, int>;

                // SET MethodRef Property of _commandStringIntIntParam to reference to _server.GetImage():
                _commandStringIntIntParam.MethodRef = _server.GetImage;

                // SET Name Property of _commandStringIntIntParam to "GetImage":
                (_commandStringIntIntParam as IName).Name = "GetImage";

                // INITIALISE _formDict[_formCount] (FishyHome) with a reference to _commandStringIntIntParam:
                (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(_commandStringIntIntParam);

                #endregion


                #region DISPOSABLE REMOVAL COMMAND (IDISPOSABLE)

                // DECLARE & INSTANTIATE an ICommandParam<IDisposable> as a new CommandParam<IDisposable>(), name it '_commandIDisposableParam':
                ICommandParam<IDisposable> _commandIDisposableParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>).Create<CommandParam<IDisposable>>() as ICommandParam<IDisposable>;

                // SET MethodRef Property of _commandIDisposableParam to reference to DisposableRemoval(IDisposable):
                _commandIDisposableParam.MethodRef = DisposableRemoval;

                // SET Name Property of _commandIDisposableParam to "DisposableRemoval":
                (_commandIDisposableParam as IName).Name = "DisposableRemoval";

                // INITIALISE _formDict[_formCount] (FishyHome) with a reference to _commandIDisposableParam:
                (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(_commandIDisposableParam);

                #endregion


                #region DISPOSABLE REMOVAL COMMAND (INT)

                // DECLARE & INSTANTIATE an ICommandParam<IDisposable> as a new CommandParam<IDisposable>(), name it '_commandIntParam':
                ICommandParam<int> _commandIntParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>).Create<CommandParam<int>>() as ICommandParam<int>;

                // SET MethodRef Property of _commandIDisposableParam to reference to DisposableRemoval(int):
                _commandIntParam.MethodRef = DisposableRemoval;

                // SET Name Property of _commandIntParam to "RemoveMe":
                (_commandIntParam as IName).Name = "RemoveMe";

                // INITIALISE _formDict[_formCount] (FishyHome) with a reference to _commandIntParam:
                (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(_commandIntParam);

                #endregion

            }
            // CATCH ClassDoesNotExistException from Create<C>():
            catch (ClassDoesNotExistException e)
            {
                // WRITE error message to debug console:
                Console.WriteLine(e.Message);
            }
            // CATCH NullInstanceException from Initialise():
            catch (NullInstanceException e)
            {
                // WRITE error message to debug console:
                Console.WriteLine(e.Message);
            }
            
            #endregion
            
            #endregion
        }

        /// <summary>
        /// Calls Static Application class methods, to create Windows Forms Application
        /// </summary>
        public void RunApplication()
        {
            // CALL Application static method 'SetHighDpiMode()', passing HighDpiMode.SystemAware as a parameter:
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            // CALL Application static method EnableVisualStyles():
            Application.EnableVisualStyles();

            // CALL Application static method SetCompatibleTextRenderingDefault(), passing a 'false' boolean value as a parameter:
            Application.SetCompatibleTextRenderingDefault(false);

            // CALL Application static method 'Run()', passing _formDict[0] (FishyHome) as a parameter:
            Application.Run(_formDict[0] as Form);
        }

        #endregion


        #region IMPLEMENTATION OF ICONTROLLER

        /// <summary>
        /// Creates an edit screen, and initialises with required commands and values
        /// </summary>
        /// <param name="pImageFP"> File path of current image displayed so Edit screen shows the correct image </param>
        public void CreateEditScrn(string pImageFP)
        {
            #region FISHYEDIT CREATION

            // TRY checking if ClassDoesNotExistException OR NullInstanceException are thrown:
            try
            {
                // INCREMENT _formCount by '1':
                _formCount++;

                // INSTANTIATE _fishyHome as a new FishyEdit():
                //_fishyEdit = _disposableFactory.Create<FishyEdit>() as Form;

                // INITIALISE _fishyEdit with an IOpenImage object:
                //(_fishyHome as IInitialiseIOpenImage).Initialise(_markerFactory.Create<OpenSaveLogic>() as IOpenImage);
            }
            // CATCH ClassDoesNotExistException, write message to console:
            catch (ClassDoesNotExistException pException)
            {
                // WRITE error message to debug console:
                Console.WriteLine(pException.Message);
            }
            // CATCH NullInstanceException, write message to console:
            catch (NullInstanceException pException)
            {
                // WRITE error message to debug console:
                Console.WriteLine(pException.Message);
            }

            #region FISHYEDIT DELEGATES

            // INITIALISE _fishyEdit with _server.GetImage as a delegate:
            //(_fishyEdit as IInitialiseParam<GetImageDelegate>).Initialise(_server.GetImage);


            ICommandParam<int> _remove = new CommandParam<int>();


            _remove.MethodRef = DisposableRemoval;


            (_remove as IName).Name = "Remove";



            //(_fishyEdit as IInitialiseParam<ICommand>).Initialise(_remove);



            #endregion

            #endregion

            ///
            // NOTE: THESE ARE FROM CREATING FISHY EDIT - AS HOME NOW CREATED THESE ARENT NEEDED (KEPT INCASE THINGS GO SOUTH)
            ///

            //// INITIALISE _fishyEdit with ObjectDispose as a delegate:
            //(_home as IInitialiseDeleteDel).Initialise(ObjectDispose);

            //// INITIALISE _fishyEdit with _server.RotateImage as a delegate:
            //(_home as IInitialiseRotationDel).Initialise(_server.RotateImage);

            //// INITIALISE _fishyEdit with _server.ACRotateImage as a delegate:
            //(_home as IInitialiseACRotationDel).Initialise((_server as IACRotate).ACRotateImage);

            //// INITIALISE _fishyEdit with _server.HorizontalFlipImage as a delegate:
            //(_home as IInitialiseHFlipImgDel).Initialise(_server.HorizontalFlipImage);

            //// INITIALISE _fishyEdit with _server.VerticalFlipImage as a delegate:
            //(_home as IInitialiseVFlipImgDel).Initialise(_server.VerticalFlipImage);

            /////////////////////////////////////////////////////////////////////////////////////////////
        }

        /// <summary>
        /// Disposes of IDisposable objects, used for IDisposable objects not stored in a collection
        /// </summary>
        /// <param name="pDisposable"> IDisposable object to be removed </param>
        public void DisposableRemoval(IDisposable pDisposable)
        {
            // IF pDisposable DOES HAVE an active instance:
            if (pDisposable != null)
            {
                // DISPOSE of pDisposable instance:
                pDisposable.Dispose();
            }
            // IF pDisposable DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullValueException(), with corresponding message:
                throw new NullValueException("ERROR: IDisposable object cannot be disposed due to not having an active instance!");
            }
        }

        /// <summary>
        /// Disposes of objects from a collection addressed via integer parameter
        /// </summary>
        /// <param name="pUID"> Integer value to address a specific Form to remove </param>
        public void DisposableRemoval(int pUID)
        {
            // IF _formDict DOES contain pUID as a key:
            if (_formDict.ContainsKey(pUID))
            {
                // DISPOSE of object addressed at pUID in _formDict:
                _formDict[pUID].Dispose();

                // REMOVE object stored at pUID in _formDict:
                _formDict.Remove(pUID);
            }
            // IF _formDict DOES NOT contain pUID as a key:
            else
            {
                // THROW a new NullValueException(), with corresponding message:
                throw new NullValueException("ERROR: IDisposable object cannot be disposed due to no active instance stored addressed at pUID in _formDict!");
            }
        }

        #endregion
    }
}
