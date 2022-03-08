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
using Server.Delegates;
using Server.Commands;

namespace App
{
    /// <summary>
    /// Main Class of the application, stores reference to all objects required
    /// Author: William Smith, William Eardley & Declan Kerby-Collins
    /// Date: 02/02/22
    /// </summary>
    public class Controller : IApplicationStart, IInitialiseParam<IDictionary<int, IDisposable>>, IInitialiseParam<IServiceLocator>
    {
        #region FIELD VARIABLES

        // DECLARE a IDictionary<int,Form>, name it '_fishyEditDict':
        // IS CONCRETE FORM, HOWEVER IT NEEDS TO BE 'FORM' FOR APPLICATION.RUN() METHOD
        private IDictionary<int, Form> _fishyEditDict;

        // DECLARE an IServiceLocator, name it '_serviceLocator':
        private IServiceLocator _serviceLocator;

        // DECLARE an IServer, name it _server:
        private IServer _server;

        // DECLARE a Form, name it '_fishyHome':
        // IS CONCRETE FORM, HOWEVER IT NEEDS TO BE 'FORM' FOR APPLICATION.RUN() METHOD
        private Form _fishyHome;

        // DECLARE an int, name it '_fishyEditID':
        private int _fishyEditID;

        #endregion

        
        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of Controller
        /// </summary>
        public Controller()
        {
            // INSTANTIATE _fishyEditDict as a new Dictionary<int, Form>():
            _fishyEditDict = new Dictionary<int, Form>();
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


        #region IMPLEMENTATION OF IAPPLICATIONSTART

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
            // CATCH NullInstanceException, write message to console:
            catch (NullReferenceException pException)
            {
                // WRITE error message to debug console:
                Console.WriteLine(pException.Message);
            }

            #endregion


            #region FISHYHOME CREATION

            // TRY checking if ClassDoesNotExistException OR NullInstanceException are thrown:
            try
            {
                // INSTANTIATE _fishyHome as a new FishyHome():
                _fishyHome = (_serviceLocator.GetService<Factory<Form>>() as IFactory<Form>).Create<FishyHome>();

                // INITIALISE _fishyHome with an IOpenImage object:
                (_fishyHome as IInitialiseParam<IOpenImage>).Initialise((_serviceLocator.GetService<Factory<ILogic>>() as IFactory<ILogic>).Create<OpenLogic>() as IOpenImage);
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
            // CATCH NullInstanceException, write message to console:
            catch (NullReferenceException pException)
            {
                // WRITE error message to debug console:
                Console.WriteLine(pException.Message);
            }

            #region FISHYHOME DELEGATES

            // INITIALISE _fishyHome with _server.GetImage as a delegate:
            (_fishyHome as IInitialiseParam<GetImageDelegate>).Initialise(_server.GetImage);

            // INITIALISE _fishyHome with _server.Load as a delegate:
            (_fishyHome as IInitialiseParam<LoadDelegate>).Initialise(_server.Load);

            #endregion

            #endregion

            // CALL Application static method 'Run()', passing _fishyHome as a parameter:
            Application.Run(_fishyHome);
        }


        /// <summary>
        /// Creates an instance of FishyEdit, and initialises with required commands and values
        /// </summary>
        private void CreateFishyEdit(string pImageFP)
        {
            #region FISHYEDIT CREATION

            // TRY checking if ClassDoesNotExistException OR NullInstanceException are thrown:
            try
            {
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

        /// <summary>
        /// Disposes of objects from _fishyEditDict addressed via integer parameter
        /// </summary>
        /// <param name="pUID"> Integer value to address a specific Form to remove </param>
        private void DisposableRemoval(int pUID)
        {
            // IF _fishyEditDict DOES contain pUID as a key:
            if (_fishyEditDict.ContainsKey(pUID))
            {
                // DISPOSE of object addressed at pUID in _fishyEditDict
                _fishyEditDict[pUID].Dispose();

                // DISPOSE of pDisposable instance:
                //pDisposable.Dispose();
            }
            // IF _fishyEditDict DOES NOT contain pUID as a key:
            else
            {
                // THROW a new NullValueException(), with corresponding message:
                throw new NullValueException("ERROR: Form object cannot be disposed due to no current instance stored addressed at pUID in _fishyEditDict!");
            }
        }

        #endregion
    }
}
