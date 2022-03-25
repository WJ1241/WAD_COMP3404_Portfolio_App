using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ImageProcessor;
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
using Server.CustomEventArgs;

namespace App
{
    /// <summary>
    /// Main Class of the application, stores reference to all objects required
    /// Author: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 25/03/22
    /// </summary>
    public class Controller : IController, ISetupApplication, IInitialiseParam<IDictionary<int, IDisposable>>, IInitialiseParam<IServiceLocator>
    {
        #region FIELD VARIABLES

        // DECLARE a IDictionary<int, IDisposable>, name it '_formDict':
        // IS CONCRETE FORM, HOWEVER IT NEEDS TO BE 'FORM' FOR APPLICATION.RUN() METHOD
        private IDictionary<int, IDisposable> _formDict;

        // DECLARE an IServiceLocator, name it '_serviceLocator':
        private IServiceLocator _serviceLocator;

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

            // CALL Application static method SetCompatibleTextRenderingDefault(), passing a 'false' boolean value as a parameter:
            Application.SetCompatibleTextRenderingDefault(false);

            // CALL Application static method 'SetHighDpiMode()', passing HighDpiMode.SystemAware as a parameter:
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            // CALL Application static method EnableVisualStyles():
            Application.EnableVisualStyles();

            // TRY checking if ClassDoesNotExistException OR NullInstanceException are thrown:
            try
            {
                #region IOPENIMAGE SETUP

                // DECLARE & INSTANTIATE an IOpenImage as a new OpenLogic(), name it '_openImage':
                IOpenImage _openImage = (_serviceLocator.GetService<Factory<ILogic>>() as IFactory<ILogic>).Create<OpenLogic>() as IOpenImage;

                // INITIALISE _openImage with a new List<string>():
                (_openImage as IInitialiseParam<IList<string>>).Initialise((_serviceLocator.GetService<Factory<IEnumerable>>() as IFactory<IEnumerable>).Create<List<string>>() as IList<string>);

                #endregion

                // ADD _formCount as a key and a new FishyHome() as a value to _formDict:
                _formDict.Add(_formCount, (_serviceLocator.GetService<Factory<IDisposable>>() as IFactory<IDisposable>).Create<FishyHome>());

                // SET InvokeCommand property value of  _formDict[_formCount] (FishyHome) to reference to CommandInvoker.InvokeCommand:
                (_formDict[_formCount] as ICommandSender).InvokeCommand = (_serviceLocator.GetService<CommandInvoker>() as ICommandInvoker).InvokeCommand;

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

                // INITIALISE ImageServer with an IManageImg object:
                (_serviceLocator.GetService<ImageServer>() as IInitialiseParam<IManageImg>).Initialise(_serviceLocator.GetService<ImageMgr>() as IManageImg);

                // INITIALISE ImageServer with an IEditImg object:
                (_serviceLocator.GetService<ImageServer>() as IInitialiseParam<IEditImg>).Initialise(_serviceLocator.GetService<ImageEditor>() as IEditImg);

                // INITIALISE ImageServer with a new IDictionary<string, EventArgs> object:
                (_serviceLocator.GetService<ImageServer>() as IInitialiseParam<IDictionary<string, EventArgs>>).Initialise(
                    (_serviceLocator.GetService<Factory<IEnumerable>>() as IFactory<IEnumerable>).Create<Dictionary<string, EventArgs>>() as IDictionary<string, EventArgs>);

                // INITIALISE ImageServer with "Image" and a new EventArgs object:
                (_serviceLocator.GetService<ImageServer>() as IInitialiseParam<string, EventArgs>).Initialise("Image", (_serviceLocator.GetService<Factory<EventArgs>>() as IFactory<EventArgs>).Create<ImageEventArgs>());

                // INITIALISE ImageServer with "StringList" and a new EventArgs object:
                (_serviceLocator.GetService<ImageServer>() as IInitialiseParam<string, EventArgs>).Initialise("StringList", (_serviceLocator.GetService<Factory<EventArgs>>() as IFactory<EventArgs>).Create<StringListEventArgs>());

                #endregion


                #region IMAGE MANAGER

                // INITIALISE returned ImageMgr with a new Dictionary<string, Image>():
                (_serviceLocator.GetService<ImageMgr>() as IInitialiseParam<IDictionary<string, Image>>).Initialise(
                    (_serviceLocator.GetService<Factory<IEnumerable>>() as IFactory<IEnumerable>).Create<Dictionary<string, Image>>() as IDictionary<string, Image>);

                #endregion


                #region IMAGE EDITOR

                // INITIALISE returned ImageEditor with a new ImageFactory():
                // CANNOT USE FACTORY AS IMAGEPROCESSOR.IMAGEFACTORY API CLASS DOES NOT HAVE PARAMETERLESS CONSTRUCTOR:
                (_serviceLocator.GetService<ImageEditor>() as IInitialiseParam<ImageFactory>).Initialise(new ImageFactory(false));

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

                // DECLARE & INSTANTIATE an ICommandParam<IList<string>, EventHandler<StringListEventArgs>> as a new CommandParam<IList<string>, EventHandler<StringListEventArgs>>(), name it '_commandStringListEHSLParam':
                ICommandParam<IList<string>, EventHandler<StringListEventArgs>> _commandStringListEHSLParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>)
                    .Create<CommandParam<IList<string>, EventHandler<StringListEventArgs>>>() as ICommandParam<IList<string>, EventHandler<StringListEventArgs>>;

                // SET MethodRef Property of _commandStringListParam to reference to IServer.Load():
                _commandStringListEHSLParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IServer).Load;

                // SET Name Property of _commandStringListParam to "Load":
                (_commandStringListEHSLParam as IName).Name = "Load";

                // INITIALISE _formDict[_formCount] (FishyHome) with a reference to _commandStringListEHSLParam:
                (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(_commandStringListEHSLParam);

                #endregion


                #region GET IMAGE COMMAND

                // DECLARE & INSTANTIATE an ICommandParam<string, int, int, EventHandler<ImageEventArgs> as a new CommandParam<string, int, int, EventHandler<ImageEventArgs>(), name it '_commandStringIntIntEHIParam':
                ICommandParam<string, int, int, EventHandler<ImageEventArgs>> _commandStringIntIntEHIParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>)
                    .Create<CommandParam<string, int, int, EventHandler<ImageEventArgs>>>() as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>;

                // SET MethodRef Property of _commandStringIntIntEHIParam to reference to IServer.GetImage():
                _commandStringIntIntEHIParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IServer).GetImage;

                // SET Name Property of _commandStringIntIntEHIParam to "GetImage":
                (_commandStringIntIntEHIParam as IName).Name = "GetImage";

                // INITIALISE _formDict[_formCount] (FishyHome) with a reference to _commandStringIntIntEHIParam:
                (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(_commandStringIntIntEHIParam);

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

                // SET FirstParam Property value of _commandIntParam to _formCount:
                _commandIntParam.FirstParam = _formCount;

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

                // ADD _formCount as a key and a new FishyEdit() as a value to _formDict:
                _formDict.Add(_formCount, (_serviceLocator.GetService<Factory<IDisposable>>() as IFactory<IDisposable>).Create<FishyEdit>());

                // SET InvokeCommand property value of  _formDict[_formCount] (FishyHome) to reference to CommandInvoker.InvokeCommand:
                (_formDict[_formCount] as ICommandSender).InvokeCommand = (_serviceLocator.GetService<CommandInvoker>() as ICommandInvoker).InvokeCommand;

                // INITIALISE _formDict[_formCount] (FishyEdit) with a new SaveLogic() object:
                (_formDict[_formCount] as IInitialiseParam<ISaveImage>).Initialise((_serviceLocator.GetService<Factory<ILogic>>() as IFactory<ILogic>).Create<SaveLogic>() as ISaveImage);

                // INITIALISE _formDict[_formCount] (FishyEdit) with a new Dictionary<string, ICommand>() object:
                (_formDict[_formCount] as IInitialiseParam<IDictionary<string, ICommand>>).Initialise(
                    (_serviceLocator.GetService<Factory<IEnumerable>>() as IFactory<IEnumerable>).Create<Dictionary<string, ICommand>>() as IDictionary<string, ICommand>);
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

            #endregion


            #region FISHYEDIT COMMANDS

            #region GET IMAGE COMMAND

            // DECLARE & INSTANTIATE an ICommandParam<string, int, int, EventHandler<ImageEventArgs> as a new CommandParam<string, int, int, EventHandler<ImageEventArgs>(), name it '_commandStringIntIntEHIParam':
            ICommandParam<string, int, int, EventHandler<ImageEventArgs>> _commandStringIntIntEHIParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>)
                .Create<CommandParam<string, int, int, EventHandler<ImageEventArgs>>>() as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>;

            // SET MethodRef Property of _commandStringIntIntEHIParam to reference to IServer.GetImage():
            _commandStringIntIntEHIParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IServer).GetImage;

            // SET Name Property of _commandStringIntIntEHIParam to "GetImage":
            (_commandStringIntIntEHIParam as IName).Name = "GetImage";

            // INITIALISE _formDict[_formCount] (FishyEdit) with a reference to _commandStringIntIntEHIParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(_commandStringIntIntEHIParam);

            #endregion


            #region ROTATE CLOCKWISE 90 DEGREES COMMAND

            // DECLARE & INSTANTIATE an ICommandParam<string> as a new CommandParam<string>(), name it '_commandStringParam':
            ICommandParam<string> _commandStringParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>).Create<CommandParam<string>>() as ICommandParam<string>;

            // SET MethodRef Property of _commandStringParam to reference to IServer.RotateImage:
            _commandStringParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IServer).RotateImage;

            // SET Name Property of _commandStringParam to "Rot90":
            (_commandStringParam as IName).Name = "Rot90";

            // INITIALISE _formDict[_formCount] (FishyHome) with a reference to _commandStringParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(_commandStringParam);

            #endregion


            #region ROTATE ANTI-CLOCKWISE 90 DEGREES COMMAND

            // INSTANTIATE _commandStringParam as a new CommandParam<string>():
            _commandStringParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>).Create<CommandParam<string>>() as ICommandParam<string>;

            // SET MethodRef Property of _commandStringParam to reference to IServer.ACRotateImage:
            _commandStringParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IServer).ACRotateImage;

            // SET Name Property of _commandStringParam to "ACRot90":
            (_commandStringParam as IName).Name = "ACRot90";

            // INITIALISE _formDict[_formCount] (FishyHome) with a reference to _commandStringParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(_commandStringParam);

            #endregion


            #region HORIZONTAL FLIP COMMAND

            // INSTANTIATE _commandStringParam as a new CommandParam<string>():
            _commandStringParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>).Create<CommandParam<string>>() as ICommandParam<string>;

            // SET MethodRef Property of _commandStringParam to reference to IServer.HorizontalFlipImage:
            _commandStringParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IServer).HorizontalFlipImage;

            // SET Name Property of _commandStringParam to "HFlip":
            (_commandStringParam as IName).Name = "HFlip";

            // INITIALISE _formDict[_formCount] (FishyHome) with a reference to _commandStringParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(_commandStringParam);

            #endregion


            #region VERTICAL FLIP COMMAND

            // INSTANTIATE _commandStringParam as a new CommandParam<string>():
            _commandStringParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>).Create<CommandParam<string>>() as ICommandParam<string>;

            // SET MethodRef Property of _commandStringParam to reference to IServer.VerticalFlipImage:
            _commandStringParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IServer).VerticalFlipImage;

            // SET Name Property of _commandStringParam to "VFlip":
            (_commandStringParam as IName).Name = "VFlip";

            // INITIALISE _formDict[_formCount] (FishyHome) with a reference to _commandStringParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(_commandStringParam);

            #endregion


            #region BRIGHTNESS COMMAND

            // DECLARE & INSTANTIATE an ICommandParam<string, int, int, int, EventHandler<ImageEventArgs> as a new CommandParam<string, int, int, int EventHandler<ImageEventArgs>(), name it '_commandStringIntEHIParam':
            ICommandParam<string, int, int, int, EventHandler<ImageEventArgs>> _commandStringIntIntIntEHIParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>)
                .Create<CommandParam<string, int, int, int, EventHandler<ImageEventArgs>>>() as ICommandParam<string, int, int, int, EventHandler<ImageEventArgs>>;

            // SET MethodRef Property of _commandStringIntIntIntEHIParam to reference to IReplaceColourImg.ReplaceBrightnessImg():
            _commandStringIntIntIntEHIParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IReplaceColourImg).ReplaceBrightnessImg;

            // SET Name Property of _commandStringIntIntIntEHIParam to "Brightness":
            (_commandStringIntIntIntEHIParam as IName).Name = "Brightness";

            // INITIALISE _formDict[_formCount] (FishyEdit) with a reference to _commandStringIntIntIntEHIParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(_commandStringIntIntIntEHIParam);

            #endregion


            #region CONTRAST COMMAND

            // INSTANTIATE _commandStringIntIntIntEHIParam as a new CommandParam<string, int, int, int, EventHandler<ImageEventArgs>():
            _commandStringIntIntIntEHIParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>)
                .Create<CommandParam<string, int, int, int, EventHandler<ImageEventArgs>>>() as ICommandParam<string, int, int, int, EventHandler<ImageEventArgs>>;

            // SET MethodRef Property of _commandStringIntIntIntEHIParam to reference to IReplaceColourImg.ReplaceContrastImg():
            _commandStringIntIntIntEHIParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IReplaceColourImg).ReplaceContrastImg;

            // SET Name Property of _commandStringIntIntIntEHIParam to "Contrast":
            (_commandStringIntIntIntEHIParam as IName).Name = "Contrast";

            // INITIALISE _formDict[_formCount] (FishyEdit) with a reference to _commandStringIntIntIntEHIParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(_commandStringIntIntIntEHIParam);

            #endregion


            #region SATURATION COMMAND

            // INSTANTIATE _commandStringIntIntIntEHIParam as a new CommandParam<string, int, int, int, EventHandler<ImageEventArgs>():
            _commandStringIntIntIntEHIParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>)
                .Create<CommandParam<string, int, int, int, EventHandler<ImageEventArgs>>>() as ICommandParam<string, int, int, int, EventHandler<ImageEventArgs>>;

            // SET MethodRef Property of _commandStringIntIntIntEHIParam to reference to IReplaceColourImg.ReplaceSaturationImg():
            _commandStringIntIntIntEHIParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IReplaceColourImg).ReplaceSaturationImg;

            // SET Name Property of _commandStringIntIntIntEHIParam to "Saturation":
            (_commandStringIntIntIntEHIParam as IName).Name = "Saturation";

            // INITIALISE _formDict[_formCount] (FishyEdit) with a reference to _commandStringIntIntIntEHIParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(_commandStringIntIntIntEHIParam);

            #endregion


            #region FILTER ONE COMMAND

            // INSTANTIATE _commandStringIntIntEHIParam as a new CommandParam<string, int, int, EventHandler<ImageEventArgs>():
            _commandStringIntIntEHIParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>)
                .Create<CommandParam<string, int, int, EventHandler<ImageEventArgs>>>() as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>;

            // SET MethodRef Property of _commandStringIntIntEHIParam to reference to IApplyFilterImg.ApplyFilterOne():
            _commandStringIntIntEHIParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IApplyFilterImg).ApplyFilterOne;

            // SET Name Property of _commandStringIntIntEHIParam to "FilterOne":
            (_commandStringIntIntEHIParam as IName).Name = "FilterOne";

            // INITIALISE _formDict[_formCount] (FishyEdit) with a reference to _commandStringEHIParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(_commandStringIntIntEHIParam);

            #endregion


            #region FILTER TWO COMMAND

            // INSTANTIATE _commandStringIntIntEHIParam as a new CommandParam<string, int, int, EventHandler<ImageEventArgs>():
            _commandStringIntIntEHIParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>)
                .Create<CommandParam<string, int, int, EventHandler<ImageEventArgs>>>() as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>;

            // SET MethodRef Property of _commandStringIntIntEHIParam to reference to IApplyFilterImg.ApplyFilterTwo():
            _commandStringIntIntEHIParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IApplyFilterImg).ApplyFilterTwo;

            // SET Name Property of _commandStringIntIntEHIParam to "FilterTwo":
            (_commandStringIntIntEHIParam as IName).Name = "FilterTwo";

            // INITIALISE _formDict[_formCount] (FishyEdit) with a reference to _commandStringEHIParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(_commandStringIntIntEHIParam);

            #endregion


            #region FILTER THREE COMMAND

            // INSTANTIATE _commandStringIntIntEHIParam as a new CommandParam<string, int, int, EventHandler<ImageEventArgs>():
            _commandStringIntIntEHIParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>)
                .Create<CommandParam<string, int, int, EventHandler<ImageEventArgs>>>() as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>;

            // SET MethodRef Property of _commandStringIntIntEHIParam to reference to IApplyFilterImg.ApplyFilterThree():
            _commandStringIntIntEHIParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IApplyFilterImg).ApplyFilterThree;

            // SET Name Property of _commandStringIntIntEHIParam to "FilterThree":
            (_commandStringIntIntEHIParam as IName).Name = "FilterThree";

            // INITIALISE _formDict[_formCount] (FishyEdit) with a reference to _commandStringEHIParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(_commandStringIntIntEHIParam);

            #endregion


            #region FILTER FOUR COMMAND

            // INSTANTIATE _commandStringIntIntEHIParam as a new CommandParam<string, int, int, EventHandler<ImageEventArgs>():
            _commandStringIntIntEHIParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>)
                .Create<CommandParam<string, int, int, EventHandler<ImageEventArgs>>>() as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>;

            // SET MethodRef Property of _commandStringIntIntEHIParam to reference to IApplyFilterImg.ApplyFilterFour():
            _commandStringIntIntEHIParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IApplyFilterImg).ApplyFilterFour;

            // SET Name Property of _commandStringIntIntEHIParam to "FilterFour":
            (_commandStringIntIntEHIParam as IName).Name = "FilterFour";

            // INITIALISE _formDict[_formCount] (FishyEdit) with a reference to _commandStringEHIParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(_commandStringIntIntEHIParam);

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

            // SET FirstParam Property value of _commandIntParam to _formCount:
            _commandIntParam.FirstParam = _formCount;

            // SET Name Property of _commandIntParam to "RemoveMe":
            (_commandIntParam as IName).Name = "RemoveMe";

            // INITIALISE _formDict[_formCount] (FishyHome) with a reference to _commandIntParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(_commandIntParam);

            #endregion

            #endregion


            #region SHOWING FISHYEDIT

            // INITIALISE _formDict[_formCount] (FishyEdit) with pImageFP:
            (_formDict[_formCount] as IInitialiseParam<string>).Initialise(pImageFP);

            // SHOW _formDict[_formCount] (FishyEdit) to user:
            (_formDict[_formCount] as Control).Show();

            #endregion
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
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: IDisposable object cannot be disposed due to not having an active instance!");
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
                // IF _formDict[pUID] DOES HAVE an active instance:
                if (_formDict[pUID] != null)
                {
                    // DISPOSE of object addressed at pUID in _formDict:
                    _formDict[pUID].Dispose();

                    // REMOVE object stored at pUID in _formDict:
                    _formDict.Remove(pUID);
                }
                // IF _formDict[pUID] DOES NOT HAVE an active instance:
                else
                {
                    // THROW a new NullInstanceException(), with corresponding message:
                    throw new NullInstanceException("ERROR: _formDict[pUID] cannot be disposed due to not having an active instance!");
                }
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
