using System;
using System.Collections.Generic;
using System.Windows.Forms;
using App.Services;
using App.Services.Factories;
using App.GeneralInterfaces;
using GUI;
using GUI.Logic;
using GUI.Logic.Interfaces;
using Server;
using Server.Exceptions;
using Server.GeneralInterfaces;
using Server.InitialisingInterfaces;
using Server.Commands;

namespace App
{
    /// <summary>
    /// Main Class of the application, stores reference to all objects required
    /// Author: William Smith, William Eardley & Declan Kerby-Collins
    /// Date: 09/03/22
    /// </summary>
    public class Controller : IController, IInitialiseParam<IDictionary<int, IDisposable>>, IInitialiseParam<IServiceLocator>
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
            // EMPTY CONSTRUCTOR
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


        #region IMPLEMENTATION OF ICONTROLLER

        /// <summary>
        /// Calls Static Application class methods, to create Windows Forms Application
        /// </summary>
        public void RunApplication()
        {
            #region APPLICATION SETUP

            // CALL Application static method 'SetHighDpiMode()', passing HighDpiMode.SystemAware as a parameter:
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            // CALL Application static method EnableVisualStyles():
            Application.EnableVisualStyles();

            // CALL Application static method SetCompatibleTextRenderingDefault(), passing a 'false' boolean value as a parameter:
            Application.SetCompatibleTextRenderingDefault(false);

            #endregion


            #region SERVER CREATION

            // TRY checking if ClassDoesNotExistException OR NullInstanceException are thrown:
            try
            {
                // INSTANTIATE _server as a new ImageServer():
                _server = _serviceLocator.GetService<ImageServer>() as IServer;

                // INITIALISE _server with an IManageImg object:
                (_server as IInitialiseParam<IManageImg>).Initialise(_serviceLocator.GetService<ImageMgr>() as IManageImg);

                // INITIALISE _server with an IEditImg object:
                (_server as IInitialiseParam<IEditImg>).Initialise(_serviceLocator.GetService<ImageEditor>() as IEditImg);
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


            #region FISHYHOME CREATION & INITIALISATION

            // TRY checking if ClassDoesNotExistException OR NullInstanceException are thrown:
            try
            {
                // ADD _formCount as a key and a new FishyHome as a value to _formDict:
                _formDict.Add(_formCount, (_serviceLocator.GetService<Factory<IDisposable>>() as IFactory<IDisposable>).Create<FishyHome>());

                // INITIALISE _formDict[0] (FishyHome) with a new IOpenImage object:
                (_formDict[0] as IInitialiseParam<IOpenImage>).Initialise((_serviceLocator.GetService<Factory<ILogic>>() as IFactory<ILogic>).Create<OpenLogic>() as IOpenImage);
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

            #region FISHYHOME DELEGATES

            // INITIALISE _fishyHome with _server.GetImage as a delegate:
            //(_fishyHome as IInitialiseParam<GetImageDelegate>).Initialise(_server.GetImage);

            // INITIALISE _fishyHome with _server.Load as a delegate:
            //(_fishyHome as IInitialiseParam<LoadDelegate>).Initialise(_server.Load);

            #endregion

            #endregion

            // CALL Application static method 'Run()', passing _formDict[0] (FishyHome) as a parameter:
            Application.Run(_formDict[0] as Form);
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


        #region PRIVATE METHODS

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


            ICommandOneParam<int> _remove = new CommandOneParam<int>();


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

        #endregion
    }
}
