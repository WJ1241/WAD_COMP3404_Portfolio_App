using System;
using System.Windows.Forms;
using App.Factories;
using App.GeneralInterfaces;
using GUI;
using GUI.InitialisingInterfaces;
using GUI.Logic;
using Server;
using Server.Exceptions;
using Server.GeneralInterfaces;
using Server.InitialisingInterfaces;

namespace App
{
    /// <summary>
    /// Main Class of the application, stores reference to all objects required
    /// Author: William Smith
    /// Date: 02/12/21
    /// </summary>
    public class Controller : IApplicationStart
    {
        #region FIELD VARIABLES

        // DECLARE an IMarkerFactory, name it '_markerFactory':
        private IMarkerFactory _markerFactory;

        // DECLARE an IDisposableFactory, name it '_disposableFactory':
        private IDisposableFactory _disposableFactory;

        // DECLARE an IServer, name it _server:
        private IServer _server;

        // DECLARE a Form, name it '_fishyEdit':
        // IS CONCRETE FORM, HOWEVER IT NEEDS TO BE 'FORM' FOR APPLICATION.RUN() METHOD
        private Form _fishyEdit;

        // DECLARE a form called '_home':
        private Form _home;

        #endregion

        
        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of Controller
        /// </summary>
        public Controller()
        {
            // INSTANTIATE _markerFactory as a new MarkerFactory():
            _markerFactory = new MarkerFactory();

            // INSTANTIATE _disposableFactory as a new DisposableFactory():
            _disposableFactory = new DisposableFactory();
        }

        #endregion


        #region PRIVATE METHODS

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
                _server = _markerFactory.Create<ImageServer>() as IServer;

                // INITIALISE _server with an IManageImg object:
                (_server as IInitialiseIManageImg).Initialise(_markerFactory.Create<ImageMgr>() as IManageImg);

                // INITIALISE _server with an IEditImg object:
                (_server as IInitialiseIEditImg).Initialise(_markerFactory.Create<ImageEditor>() as IEditImg);
            }
            // CATCH ClassDoesNotExistException, write message to console:
            catch (ClassDoesNotExistException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);
            }
            // CATCH NullInstanceException, write message to console:
            catch (NullInstanceException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);
            }

            #endregion


            #region FISHYEDIT CREATION

            // TRY checking if ClassDoesNotExistException OR NullInstanceException are thrown:
            try
            {
                // INSTANTIATE _fishyEdit as a new FishyEdit():
                _home = _disposableFactory.Create<Home>() as Form;

                // INITIALISE _fishyEdit with an IOpenImage object:
                (_home as IInitialiseIOpenImage).Initialise(_markerFactory.Create<OpenSaveLogic>() as IOpenImage);
            }
            // CATCH ClassDoesNotExistException, write message to console:
            catch (ClassDoesNotExistException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);
            }
            // CATCH NullInstanceException, write message to console:
            catch (NullInstanceException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);
            }

            #region HOME DELEGATES

            // INITIALISE _fishyEdit with _server.GetImage as a delegate:
            (_home as IInitialiseGetImageDel).Initialise(_server.GetImage);

            // INITIALISE _fishyEdit with _server.Load as a delegate:
            (_home as IInitialiseLoadDel).Initialise(_server.Load);

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

            #endregion

            #endregion

            // CALL Application static method 'Run()', passing _fishyEdit as a parameter:
            Application.Run(_home);
        }


        /// <summary>
        /// Disposes of objects implementing the IDisposable interface
        /// </summary>
        /// <param name="pDisposable"> Disposable object to be removed from memory </param>
        private void ObjectDispose(IDisposable pDisposable)
        {
            // IF pDisposable DOES HAVE an active instance:
            if (pDisposable != null)
            {
                // DISPOSE of pDisposable instance:
                pDisposable.Dispose();
            }
            // IF pDisposable DOES HAVE an active instance:
            else
            {
                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException("ERROR: IDisposable object cannot be disposed due to having no current instance!");
            }
        }

        #endregion

    }
}
