using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ImageProcessor;
using App.GeneralInterfaces;
using App.Services.Factories;
using App.Services.Factories.Interfaces;
using App.Services.Interfaces;
using GUI;
using GUI.Logic;
using GUI.Logic.Interfaces;
using Server;
using Server.Commands;
using Server.Commands.Interfaces;
using Server.CustomEventArgs;
using Server.Exceptions;
using Server.GeneralInterfaces;
using Server.InitialisingInterfaces;

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

                // DECLARE & INSTANTIATE an IOpenImage as a new OpenLogic(), name it 'openImage':
                IOpenImage openImage = (_serviceLocator.GetService<Factory<ILogic>>() as IFactory<ILogic>).Create<OpenLogic>() as IOpenImage;

                // INITIALISE openImage with a new List<string>():
                (openImage as IInitialiseParam<IList<string>>).Initialise((_serviceLocator.GetService<Factory<IEnumerable>>() as IFactory<IEnumerable>).Create<List<string>>() as IList<string>);

                #endregion

                // ADD _formCount as a key and a new FishyHome() as a value to _formDict:
                _formDict.Add(_formCount, (_serviceLocator.GetService<Factory<IDisposable>>() as IFactory<IDisposable>).Create<FishyHome>());

                // SET InvokeCommand property value of  _formDict[_formCount] (FishyHome) to reference to CommandInvoker.InvokeCommand:
                (_formDict[_formCount] as ICommandSender).InvokeCommand = (_serviceLocator.GetService<CommandInvoker>() as ICommandInvoker).InvokeCommand;

                // INITIALISE _formDict[_formCount] (FishyHome) with a new IOpenImage object:
                (_formDict[_formCount] as IInitialiseParam<IOpenImage>).Initialise(openImage);

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

                // DECLARE & INSTANTIATE an ICommandParam<string> as a new CommandParam<String>(), name it 'commandStringParam':
                ICommandParam<string> commandStringParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>).Create<CommandParam<string>>() as ICommandParam<string>;

                // SET MethodRef Property of commandStringParam to reference to CreateEditScrn():
                commandStringParam.MethodRef = CreateEditScrn;

                // SET Name Property of commandStringParam to "CreateEditScrn":
                (commandStringParam as IName).Name = "CreateEditScrn";

                // INITIALISE _formDict[_formCount] (FishyHome) with a reference to commandStringParam:
                (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(commandStringParam);

                #endregion


                #region LOAD IMAGE COMMAND

                // DECLARE & INSTANTIATE an ICommandParam<IList<string>, EventHandler<StringListEventArgs>> as a new CommandParam<IList<string>, EventHandler<StringListEventArgs>>(), name it 'commandStringListEHSLParam':
                ICommandParam<IList<string>, EventHandler<StringListEventArgs>> commandStringListEHSLParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>)
                    .Create<CommandParam<IList<string>, EventHandler<StringListEventArgs>>>() as ICommandParam<IList<string>, EventHandler<StringListEventArgs>>;

                // SET MethodRef Property of _commandStringListParam to reference to IServer.Load():
                commandStringListEHSLParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IServer).Load;

                // SET Name Property of _commandStringListParam to "Load":
                (commandStringListEHSLParam as IName).Name = "Load";

                // INITIALISE _formDict[_formCount] (FishyHome) with a reference to commandStringListEHSLParam:
                (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(commandStringListEHSLParam);

                #endregion


                #region GET IMAGE COMMAND

                // DECLARE & INSTANTIATE an ICommandParam<string, int, int, EventHandler<ImageEventArgs> as a new CommandParam<string, int, int, EventHandler<ImageEventArgs>(), name it 'commandStringIntIntEHIParam':
                ICommandParam<string, int, int, EventHandler<ImageEventArgs>> commandStringIntIntEHIParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>)
                    .Create<CommandParam<string, int, int, EventHandler<ImageEventArgs>>>() as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>;

                // SET MethodRef Property of commandStringIntIntEHIParam to reference to IServer.GetImage():
                commandStringIntIntEHIParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IServer).GetImage;

                // SET Name Property of commandStringIntIntEHIParam to "GetImage":
                (commandStringIntIntEHIParam as IName).Name = "GetImage";

                // INITIALISE _formDict[_formCount] (FishyHome) with a reference to commandStringIntIntEHIParam:
                (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(commandStringIntIntEHIParam);

                #endregion


                #region DISPOSABLE REMOVAL COMMAND (IDISPOSABLE)

                // DECLARE & INSTANTIATE an ICommandParam<IDisposable> as a new CommandParam<IDisposable>(), name it 'commandIDisposableParam':
                ICommandParam<IDisposable> commandIDisposableParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>).Create<CommandParam<IDisposable>>() as ICommandParam<IDisposable>;

                // SET MethodRef Property of commandIDisposableParam to reference to DisposableRemoval(IDisposable):
                commandIDisposableParam.MethodRef = DisposableRemoval;

                // SET Name Property of commandIDisposableParam to "DisposableRemoval":
                (commandIDisposableParam as IName).Name = "DisposableRemoval";

                // INITIALISE _formDict[_formCount] (FishyHome) with a reference to commandIDisposableParam:
                (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(commandIDisposableParam);

                #endregion


                #region DISPOSABLE REMOVAL COMMAND (INT)

                // DECLARE & INSTANTIATE an ICommandParam<IDisposable> as a new CommandParam<IDisposable>(), name it 'commandIntParam':
                ICommandParam<int> commandIntParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>).Create<CommandParam<int>>() as ICommandParam<int>;

                // SET MethodRef Property of commandIDisposableParam to reference to DisposableRemoval(int):
                commandIntParam.MethodRef = DisposableRemoval;

                // SET FirstParam Property value of commandIntParam to _formCount:
                commandIntParam.FirstParam = _formCount;

                // SET Name Property of commandIntParam to "RemoveMe":
                (commandIntParam as IName).Name = "RemoveMe";

                // INITIALISE _formDict[_formCount] (FishyHome) with a reference to commandIntParam:
                (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(commandIntParam);

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

            // DECLARE & INSTANTIATE an ICommandParam<string, int, int, EventHandler<ImageEventArgs> as a new CommandParam<string, int, int, EventHandler<ImageEventArgs>(), name it 'commandStringIntIntEHIParam':
            ICommandParam<string, int, int, EventHandler<ImageEventArgs>> commandStringIntIntEHIParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>)
                .Create<CommandParam<string, int, int, EventHandler<ImageEventArgs>>>() as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>;

            // SET MethodRef Property of commandStringIntIntEHIParam to reference to IServer.GetImage():
            commandStringIntIntEHIParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IServer).GetImage;

            // SET Name Property of commandStringIntIntEHIParam to "GetImage":
            (commandStringIntIntEHIParam as IName).Name = "GetImage";

            // INITIALISE _formDict[_formCount] (FishyEdit) with a reference to commandStringIntIntEHIParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(commandStringIntIntEHIParam);

            #endregion


            #region ROTATE CLOCKWISE 90 DEGREES COMMAND

            // DECLARE & INSTANTIATE an ICommandParam<string> as a new CommandParam<string>(), name it 'commandStringParam':
            ICommandParam<string> commandStringParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>).Create<CommandParam<string>>() as ICommandParam<string>;

            // SET MethodRef Property of commandStringParam to reference to IServer.RotateImage:
            commandStringParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IServer).RotateImage;

            // SET Name Property of commandStringParam to "Rot90":
            (commandStringParam as IName).Name = "Rot90";

            // INITIALISE _formDict[_formCount] (FishyHome) with a reference to commandStringParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(commandStringParam);

            #endregion


            #region ROTATE ANTI-CLOCKWISE 90 DEGREES COMMAND

            // INSTANTIATE commandStringParam as a new CommandParam<string>():
            commandStringParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>).Create<CommandParam<string>>() as ICommandParam<string>;

            // SET MethodRef Property of commandStringParam to reference to IServer.ACRotateImage:
            commandStringParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IServer).ACRotateImage;

            // SET Name Property of commandStringParam to "ACRot90":
            (commandStringParam as IName).Name = "ACRot90";

            // INITIALISE _formDict[_formCount] (FishyHome) with a reference to commandStringParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(commandStringParam);

            #endregion


            #region HORIZONTAL FLIP COMMAND

            // INSTANTIATE commandStringParam as a new CommandParam<string>():
            commandStringParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>).Create<CommandParam<string>>() as ICommandParam<string>;

            // SET MethodRef Property of commandStringParam to reference to IServer.HorizontalFlipImage:
            commandStringParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IServer).HorizontalFlipImage;

            // SET Name Property of commandStringParam to "HFlip":
            (commandStringParam as IName).Name = "HFlip";

            // INITIALISE _formDict[_formCount] (FishyHome) with a reference to commandStringParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(commandStringParam);

            #endregion


            #region VERTICAL FLIP COMMAND

            // INSTANTIATE commandStringParam as a new CommandParam<string>():
            commandStringParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>).Create<CommandParam<string>>() as ICommandParam<string>;

            // SET MethodRef Property of commandStringParam to reference to IServer.VerticalFlipImage:
            commandStringParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IServer).VerticalFlipImage;

            // SET Name Property of commandStringParam to "VFlip":
            (commandStringParam as IName).Name = "VFlip";

            // INITIALISE _formDict[_formCount] (FishyHome) with a reference to commandStringParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(commandStringParam);

            #endregion


            #region CROP COMMAND

            // DECLARE & INSTANTIATE an ICommandParam<Bitmap, Rectangle, EventHandler<ImageEventArgs> as a new CommandParam<Bitmap, Rectangle, EventHandler<ImageEventArgs>(), name it '_commandBitmapRectParamEHI':
            ICommandParam<Bitmap, Rectangle, EventHandler<ImageEventArgs>> commandBitmapRectEHIParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>)
                .Create<CommandParam<Bitmap, Rectangle, EventHandler<ImageEventArgs>>>() as ICommandParam<Bitmap, Rectangle, EventHandler<ImageEventArgs>>;

            // SET MethodRef Property of _commandBitmapRectEHIParam to reference to IReplaceColourImg.ReplaceCropImg():
            commandBitmapRectEHIParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IReplaceCropImg).ReplaceCropImg;

            // SET Name Property of _commandBitmapRectEHIParam to "Crop":
            (commandBitmapRectEHIParam as IName).Name = "Crop";

            // INITIALISE _formDict[_formCount] (FishyEdit) with a reference to _commandBitmapRectEHIParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(commandBitmapRectEHIParam);

            #endregion


            #region BRIGHTNESS COMMAND

            // DECLARE & INSTANTIATE an ICommandParam<string, int, int, int, EventHandler<ImageEventArgs> as a new CommandParam<string, int, int, int EventHandler<ImageEventArgs>(), name it '_commandStringIntEHIParam':
            ICommandParam<string, int, int, int, EventHandler<ImageEventArgs>> commandStringIntIntIntEHIParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>)
                .Create<CommandParam<string, int, int, int, EventHandler<ImageEventArgs>>>() as ICommandParam<string, int, int, int, EventHandler<ImageEventArgs>>;

            // SET MethodRef Property of commandStringIntIntIntEHIParam to reference to IReplaceColourImg.ReplaceBrightnessImg():
            commandStringIntIntIntEHIParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IReplaceColourImg).ReplaceBrightnessImg;

            // SET Name Property of commandStringIntIntIntEHIParam to "Brightness":
            (commandStringIntIntIntEHIParam as IName).Name = "Brightness";

            // INITIALISE _formDict[_formCount] (FishyEdit) with a reference to commandStringIntIntIntEHIParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(commandStringIntIntIntEHIParam);

            #endregion


            #region CONTRAST COMMAND

            // INSTANTIATE commandStringIntIntIntEHIParam as a new CommandParam<string, int, int, int, EventHandler<ImageEventArgs>():
            commandStringIntIntIntEHIParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>)
                .Create<CommandParam<string, int, int, int, EventHandler<ImageEventArgs>>>() as ICommandParam<string, int, int, int, EventHandler<ImageEventArgs>>;

            // SET MethodRef Property of commandStringIntIntIntEHIParam to reference to IReplaceColourImg.ReplaceContrastImg():
            commandStringIntIntIntEHIParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IReplaceColourImg).ReplaceContrastImg;

            // SET Name Property of commandStringIntIntIntEHIParam to "Contrast":
            (commandStringIntIntIntEHIParam as IName).Name = "Contrast";

            // INITIALISE _formDict[_formCount] (FishyEdit) with a reference to commandStringIntIntIntEHIParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(commandStringIntIntIntEHIParam);

            #endregion


            #region SATURATION COMMAND

            // INSTANTIATE commandStringIntIntIntEHIParam as a new CommandParam<string, int, int, int, EventHandler<ImageEventArgs>():
            commandStringIntIntIntEHIParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>)
                .Create<CommandParam<string, int, int, int, EventHandler<ImageEventArgs>>>() as ICommandParam<string, int, int, int, EventHandler<ImageEventArgs>>;

            // SET MethodRef Property of commandStringIntIntIntEHIParam to reference to IReplaceColourImg.ReplaceSaturationImg():
            commandStringIntIntIntEHIParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IReplaceColourImg).ReplaceSaturationImg;

            // SET Name Property of commandStringIntIntIntEHIParam to "Saturation":
            (commandStringIntIntIntEHIParam as IName).Name = "Saturation";

            // INITIALISE _formDict[_formCount] (FishyEdit) with a reference to commandStringIntIntIntEHIParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(commandStringIntIntIntEHIParam);

            #endregion


            #region FILTER ONE COMMAND

            // INSTANTIATE commandStringIntIntEHIParam as a new CommandParam<string, int, int, EventHandler<ImageEventArgs>():
            commandStringIntIntEHIParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>)
                .Create<CommandParam<string, int, int, EventHandler<ImageEventArgs>>>() as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>;

            // SET MethodRef Property of commandStringIntIntEHIParam to reference to IApplyFilterImg.ApplyFilterOne():
            commandStringIntIntEHIParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IApplyFilterImg).ApplyFilterOne;

            // SET Name Property of commandStringIntIntEHIParam to "FilterOne":
            (commandStringIntIntEHIParam as IName).Name = "FilterOne";

            // INITIALISE _formDict[_formCount] (FishyEdit) with a reference to _commandStringEHIParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(commandStringIntIntEHIParam);

            #endregion


            #region FILTER TWO COMMAND

            // INSTANTIATE commandStringIntIntEHIParam as a new CommandParam<string, int, int, EventHandler<ImageEventArgs>():
            commandStringIntIntEHIParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>)
                .Create<CommandParam<string, int, int, EventHandler<ImageEventArgs>>>() as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>;

            // SET MethodRef Property of commandStringIntIntEHIParam to reference to IApplyFilterImg.ApplyFilterTwo():
            commandStringIntIntEHIParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IApplyFilterImg).ApplyFilterTwo;

            // SET Name Property of commandStringIntIntEHIParam to "FilterTwo":
            (commandStringIntIntEHIParam as IName).Name = "FilterTwo";

            // INITIALISE _formDict[_formCount] (FishyEdit) with a reference to _commandStringEHIParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(commandStringIntIntEHIParam);

            #endregion


            #region FILTER THREE COMMAND

            // INSTANTIATE commandStringIntIntEHIParam as a new CommandParam<string, int, int, EventHandler<ImageEventArgs>():
            commandStringIntIntEHIParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>)
                .Create<CommandParam<string, int, int, EventHandler<ImageEventArgs>>>() as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>;

            // SET MethodRef Property of commandStringIntIntEHIParam to reference to IApplyFilterImg.ApplyFilterThree():
            commandStringIntIntEHIParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IApplyFilterImg).ApplyFilterThree;

            // SET Name Property of commandStringIntIntEHIParam to "FilterThree":
            (commandStringIntIntEHIParam as IName).Name = "FilterThree";

            // INITIALISE _formDict[_formCount] (FishyEdit) with a reference to _commandStringEHIParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(commandStringIntIntEHIParam);

            #endregion


            #region FILTER FOUR COMMAND

            // INSTANTIATE commandStringIntIntEHIParam as a new CommandParam<string, int, int, EventHandler<ImageEventArgs>():
            commandStringIntIntEHIParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>)
                .Create<CommandParam<string, int, int, EventHandler<ImageEventArgs>>>() as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>;

            // SET MethodRef Property of commandStringIntIntEHIParam to reference to IApplyFilterImg.ApplyFilterFour():
            commandStringIntIntEHIParam.MethodRef = (_serviceLocator.GetService<ImageServer>() as IApplyFilterImg).ApplyFilterFour;

            // SET Name Property of commandStringIntIntEHIParam to "FilterFour":
            (commandStringIntIntEHIParam as IName).Name = "FilterFour";

            // INITIALISE _formDict[_formCount] (FishyEdit) with a reference to _commandStringEHIParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(commandStringIntIntEHIParam);

            #endregion


            #region DISPOSABLE REMOVAL COMMAND (IDISPOSABLE)

            // DECLARE & INSTANTIATE an ICommandParam<IDisposable> as a new CommandParam<IDisposable>(), name it 'commandIDisposableParam':
            ICommandParam<IDisposable> commandIDisposableParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>).Create<CommandParam<IDisposable>>() as ICommandParam<IDisposable>;

            // SET MethodRef Property of commandIDisposableParam to reference to DisposableRemoval(IDisposable):
            commandIDisposableParam.MethodRef = DisposableRemoval;

            // SET Name Property of commandIDisposableParam to "DisposableRemoval":
            (commandIDisposableParam as IName).Name = "DisposableRemoval";

            // INITIALISE _formDict[_formCount] (FishyHome) with a reference to commandIDisposableParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(commandIDisposableParam);

            #endregion


            #region DISPOSABLE REMOVAL COMMAND (INT)

            // DECLARE & INSTANTIATE an ICommandParam<IDisposable> as a new CommandParam<IDisposable>(), name it 'commandIntParam':
            ICommandParam<int> commandIntParam = (_serviceLocator.GetService<Factory<ICommand>>() as IFactory<ICommand>).Create<CommandParam<int>>() as ICommandParam<int>;

            // SET MethodRef Property of commandIDisposableParam to reference to DisposableRemoval(int):
            commandIntParam.MethodRef = DisposableRemoval;

            // SET FirstParam Property value of commandIntParam to _formCount:
            commandIntParam.FirstParam = _formCount;

            // SET Name Property of commandIntParam to "RemoveMe":
            (commandIntParam as IName).Name = "RemoveMe";

            // INITIALISE _formDict[_formCount] (FishyHome) with a reference to commandIntParam:
            (_formDict[_formCount] as IInitialiseParam<ICommand>).Initialise(commandIntParam);

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
                    DisposableRemoval(_formDict[pUID]);

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
