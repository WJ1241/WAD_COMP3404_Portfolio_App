using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using GUI.Forms.Interfaces;
using GUI.Logic.Interfaces;
using Server.Commands;
using Server.CustomEventArgs;
using Server.Exceptions;
using Server.GeneralInterfaces;
using Server.InitialisingInterfaces;

namespace GUI
{
    /// <summary>
    /// Partial Class which creates a 'FishyEdit' for the user to edit Images with.
    /// Author: William Smith, William Eardley, Declan Kerby-Collins & Marc Price
    /// Date: 24/02/22
    /// </summary>
    /// <REFERENCE> Price, M. (2007) 'Moveable Form Code Snippet'. Available at: https://worcesterbb.blackboard.com/. (Accessed: 5 November 2021). </REFERENCE>
    /// <REFERENCE> jay_t55 (2014) Make a borderless form movable? Available at: https://stackoverflow.com/questions/1592876/make-a-borderless-form-movable/24561946#24561946. (Accessed 5 November 2021). </REFERENCE>
    public partial class FishyEdit : Form, IChangeImg, ICommandSender, IEventListener<ImageEventArgs>, IInitialiseParam<IDictionary<string, ICommand>>, IInitialiseParam<ICommand>,
        IInitialiseParam<ISaveImage>, IInitialiseParam<string>
    {
        #region FIELD VARIABLES

        // DECLARE an IDictionary<string, ICommand>, name it '_commandDict':
        private IDictionary<string, ICommand> _commandDict;

        // DECLARE an ISaveImage, name it '_imgSave':
        private ISaveImage _imgSave;

        // DECLARE an Action<ICommand>, name it '_invokeCommand':
        private Action<ICommand> _invokeCommand;

        // DECLARE a string, name it '_crrntImgFP':
        private string _crrntImgFP;

        // DECLARE an Vector2, name it '_originalSize':
        private Vector2 _originalSize;

        #endregion


        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of FishyEdit
        /// </summary>
        public FishyEdit()
        {
            // CALL InitializeComponent():
            InitializeComponent();
        }

        #endregion
        
        
        #region IMPLEMENTATION OF ICHANGEIMG

        /// <summary>
        /// Changes currently displayed image to a desired image
        /// </summary>
        public void ChangeImg()
        {
            // TRY checking if invoking _commandDict["GetImage"] throws an exception
            try
            {
                // SET value of _commandDict["GetImage"]'s FirstParam property to value of _crrntImgFP:
                (_commandDict["GetImage"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).FirstParam = _crrntImgFP;

                // IF ImgDisplay.Image DOES HAVE an active instance:
                if (ImgDisplay.Image != null)
                {
                    // SET value of _commandDict["GetImage"]'s SecondParam property to value of original image width multiplied by value in ScaleNumBox:
                    (_commandDict["GetImage"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).SecondParam = (int)((int)_originalSize.X * ScaleNumBox.Value);

                    // SET value of _commandDict["GetImage"]'s ThirdParam property to value of original image height multiplied by value in ScaleNumBox:
                    (_commandDict["GetImage"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).ThirdParam = (int)((int)_originalSize.Y * ScaleNumBox.Value);
                }
                // IF ImgDisplay.Image DOES NOT HAVE an active instance:
                else
                {
                    // SET value of _commandDict["GetImage"]'s SecondParam property to value of '0':
                    (_commandDict["GetImage"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).SecondParam = 0;

                    // SET value of _commandDict["GetImage"]'s ThirdParam property to value of '0':
                    (_commandDict["GetImage"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).ThirdParam = 0;
                }

                // SET value of _commandDict["GetImage"]'s FourthParam property to reference to OnEvent() (ImageEventArgs):
                (_commandDict["GetImage"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).FourthParam = OnEvent;

                // INVOKE _commandDict["GetImage"]'s ExecuteMethod():
                _invokeCommand(_commandDict["GetImage"]);
            }
            // CATCH InvalidStringException from invoking _commandDict["GetImage"]:
            catch (InvalidStringException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
            // CATCH InvalidStringException addressing Dictionary keys:
            catch (NullReferenceException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
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


        #region IMPLEMENTATION OF IEVENTLISTENER<IMAGEEVENTARGS>

        /// <summary>
        /// Event Handler to update currently displayed image
        /// </summary>
        /// <param name="pSource"> Object calling this method </param>
        /// <param name="pArgs"> Necessary arguments to complete behaviour </param>
        public void OnEvent(object pSource, ImageEventArgs pArgs)
        {
            // IF pArgs.Img DOES HAVE an active instance:
            if (pArgs.Img != null)
            {
                // IF ImgDisplay.Image DOES NOT HAVE an active instance:
                if (ImgDisplay.Image == null)
                {
                    // INSTANTIATE _originalSize as a new Vector2(), passing pArgs.Img's dimensions as parameters:
                    _originalSize = new Vector2(pArgs.Img.Width, pArgs.Img.Height);
                }

                // SET value of ImgDisplay.Image Property to value of pArgs.Img:
                ImgDisplay.Image = pArgs.Img;
            }
            // IF pArgs.Img DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: pArgs.Img does not have an active instance!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<ICOMMAND>

        /// <summary>
        /// Initialises an object with an ICommand object
        /// </summary>
        /// <param name="pCommand"> ICommand object with an executable method and possible parameter(s) </param>
        public void Initialise(ICommand pCommand)
        {
            // IF pCommand DOES HAVE an active instance:
            if (pCommand != null)
            {
                // ADD pCommand.Name as a key, and pCommand as a value to _commandDict:
                _commandDict.Add((pCommand as IName).Name, pCommand);
            }
            // IF pCommand DOES NOT HAVE an active instance:
            else
            {
                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException("ERROR: pCommand does not have an active instance, requires instantiation!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<IDICTIONARY<STRING, ICOMMAND>>

        /// <summary>
        /// Initialises an object with an IDictionary<string, ICommand> object
        /// </summary>
        /// <param name="pCommandDict"> IDictionary<string, ICommand> object </param>
        public void Initialise(IDictionary<string, ICommand> pCommandDict)
        {
            // IF pCommandDict DOES HAVE an active instance:
            if (pCommandDict != null)
            {
                // INITIALISE _commandDict with reference to pCommandDict:
                _commandDict = pCommandDict;
            }
            // IF pCommandDict DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: pCommandDict does not have an active instance, requires instantiation!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<ISAVEIMAGE>

        /// <summary>
        /// Initialises an object with an ISaveImage instance
        /// </summary>
        /// <param name="pSaveImage"> Instance of ISaveImage </param>
        public void Initialise(ISaveImage pSaveImage)
        {
            // IF pSaveImage DOES HAVE an active instance:
            if (pSaveImage != null)
            {
                // INITIALISE _imgSave with instance of pSaveImage:
                _imgSave = pSaveImage;
            }
            // IF pSaveImage DOES NOT HAVE an active instance:
            else
            {
                // THROW NullInstanceException, with corresponding message:
                throw new NullInstanceException("ERROR: FishyEdit Initialised with a null instance of ISaveImage!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<STRING>

        /// <summary>
        /// Initialises an object with a string value
        /// </summary>
        /// <param name="pImgFP"> Image File Path </param>
        public void Initialise(string pImgFP)
        {
            // IF pImgFP DOES NOT HAVE a null/blank string value:
            if (pImgFP != null || pImgFP != "")
            {
                // INITIALISE _crrntImgFP with value of pImgFP:
                _crrntImgFP = pImgFP;

                // CALL ChangeImg():
                ChangeImg();
            }
            // IF pImgFP DOES HAVE a null/blank string value:
            else
            {
                // THROW NullInstanceException, with corresponding message:
                throw new NullInstanceException("ERROR: FishyEdit Initialised with a null/blank string value!");
            }
        }

        #endregion


        #region BUTTON METHODS

        #region ORIENTATION METHODS

        /// <summary>
        /// Method which rotates currently displayed image clockwise
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void Rot90Bttn_Click(object sender, EventArgs e)
        {
            // TRY checking if invoking _commandDict["Rot90"] throws a NullInstanceException:
            try
            {
                // SET FirstParam Property value of _commandDict["Rot90"] to value of _crrntImgFP:
                (_commandDict["Rot90"] as ICommandParam<string>).FirstParam = _crrntImgFP;

                // INVOKE _commandDict["Rot90"]'s ExecuteMethod():
                _invokeCommand(_commandDict["Rot90"]);

                // CALL ChangeImg():
                ChangeImg();
            }
            // CATCH InvalidStringException from invoking _commandDict["Rot90"]():
            catch (InvalidStringException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
            // CATCH NullInstanceException from invoking _commandDict["Rot90"]():
            catch (NullInstanceException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
        }

        /// <summary>
        /// Method which rotates currently displayed image anticlockwise
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void ACRot90Bttn_Click(object sender, EventArgs e)
        {
            // TRY checking if invoking _commandDict["ACRot90"] throws a NullInstanceException:
            try
            {
                // SET FirstParam Property value of _commandDict["ACRot90"] to value of _crrntImgFP:
                (_commandDict["ACRot90"] as ICommandParam<string>).FirstParam = _crrntImgFP;

                // INVOKE _commandDict["ACRot90"]'s ExecuteMethod():
                _invokeCommand(_commandDict["ACRot90"]);

                // CALL ChangeImg():
                ChangeImg();
            }
            // CATCH InvalidStringException from invoking _commandDict["ACRot90"]():
            catch (InvalidStringException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
            // CATCH NullInstanceException from invoking _commandDict["ACRot90"]():
            catch (NullInstanceException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
        }

        /// <summary>
        /// Method which flips an image horizontally
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void HFlipBttn_Click(object sender, EventArgs e)
        {
            // TRY checking if invoking _commandDict["HFlip"] throws a NullInstanceException:
            try
            {
                // SET FirstParam Property value of _commandDict["HFlip"] to value of _crrntImgFP:
                (_commandDict["HFlip"] as ICommandParam<string>).FirstParam = _crrntImgFP;

                // INVOKE _commandDict["HFlip"]'s ExecuteMethod():
                _invokeCommand(_commandDict["HFlip"]);

                // CALL ChangeImg():
                ChangeImg();
            }
            // CATCH InvalidStringException from invoking _commandDict["HFlip"]():
            catch (InvalidStringException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
            // CATCH NullInstanceException from invoking _commandDict["HFlip"]():
            catch (NullInstanceException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
        }

        /// <summary>
        /// Method which flips an image vertically
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void VFlipBttn_Click(object sender, EventArgs e)
        {
            // TRY checking if invoking _commandDict["VFlip"] throws a NullInstanceException:
            try
            {
                // SET FirstParam Property value of _commandDict["VFlip"] to value of _crrntImgFP:
                (_commandDict["VFlip"] as ICommandParam<string>).FirstParam = _crrntImgFP;

                // INVOKE _commandDict["VFlip"]'s ExecuteMethod():
                _invokeCommand(_commandDict["VFlip"]);

                // CALL ChangeImg():
                ChangeImg();
            }
            // CATCH InvalidStringException from invoking _commandDict["VFlip"]():
            catch (InvalidStringException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
            // CATCH NullInstanceException from invoking _commandDict["VFlip"]():
            catch (NullInstanceException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
        }

        #endregion


        #region RESIZE METHODS

        /// <summary>
        /// Changes the size of the image displayed, depending on the current scale value
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void ScaleNumBox_ValueChanged(object sender, EventArgs e)
        {
            // CALL ChangeImg():
            ChangeImg();
        }

        /// <summary>
        /// Crop control Button - for cropping the image
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Required Argument Value(s)</param>
        private void CropBttn_Click(object sender, EventArgs e)
        {
            // TRY checking if _crop() OR ChangeImg() throw a NullInstanceException:
            try
            {
                // CALL _crop passing current index in _imgFPDict as a parameter:
                //_crop(_imgFPDict[_dictIndex]);
            }
            // CATCH NullInstanceException from ChangeImg():
            catch (NullInstanceException pException)
            {
                // WRITE exception message to debug console:
                Console.WriteLine(pException.Message);
            }
        }

        #endregion


        #region SAVE METHODS

        /// <summary>
        /// Method which saves currently displayed image in FishyEdit
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void SaveBttn_Click(object sender, EventArgs e)
        {
            // TRY checking if SaveImage() throws an exception
            try
            {
                // CALL SaveImage() on _imgOpenSave, passing ImgDisplay.Image as a parameter:
                _imgSave.SaveImage(ImgDisplay.Image);
            }
            // CATCH FileNotSavedException from SaveImage method:
            catch (FileNotSavedException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
        }

        #endregion


        #region COLOUR CHANGE METHODS

        /// <summary>
        /// Brightness control button - for controlling brightness
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Required Argument Value(s)</param>
        private void BrightnessControl_ValueChanged(object sender, EventArgs e)
        {
            // TRY checking if _brightness() OR ChangeImg() throw a NullInstanceException:
            try
            {
                // IF BrightnessControl.Value is MORE than '0':
                if (BrightnessControl.Value > 0)
                {
                    // SET BrightnessVal label to display positive Brightness value:
                    BrightnessVal.Text = "+" + BrightnessControl.Value.ToString() + "%";
                }
                // IF BrightnessControl.Value is EQUAL to or LESS than '0':
                else
                {
                    // SET BrightnessVal label to display Brightness value:
                    BrightnessVal.Text = BrightnessControl.Value.ToString() + "%";
                }

                // SET value of _commandDict["Brightness"]'s FirstParam property to value of _crrntImgFP:
                (_commandDict["Brightness"] as ICommandParam<string, int, EventHandler<ImageEventArgs>>).FirstParam = _crrntImgFP;

                // SET value of _commandDict["Brightness"]'s SecondParam property to value of original image width multiplied by value in ScaleNumBox:
                //(_commandDict["Brightness"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).SecondParam = (int)((int)_originalSize.X * ScaleNumBox.Value);

                // SET value of _commandDict["Brightness"]'s ThirdParam property to value of original image height multiplied by value in ScaleNumBox:
                //(_commandDict["Brightness"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).ThirdParam = (int)((int)_originalSize.Y * ScaleNumBox.Value);

                // SET value of _commandDict["Brightness"]'s SecondParam property to value of BrightnessControl.Value:
                (_commandDict["Brightness"] as ICommandParam<string, int, EventHandler<ImageEventArgs>>).SecondParam = BrightnessControl.Value;

                // SET value of _commandDict["Brightness"]'s FourthParam property to reference to OnEvent() (ImageEventArgs):
                (_commandDict["Brightness"] as ICommandParam<string, int, EventHandler<ImageEventArgs>>).ThirdParam = OnEvent;

                // INVOKE _commandDict["Brightness"]'s ExecuteMethod():
                _invokeCommand(_commandDict["Brightness"]);
                
            }
            // CATCH InvalidStringException from invoking _commandDict["Brightness"]():
            catch (InvalidStringException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
            // CATCH NullInstanceException from ChangeImg():
            catch (NullInstanceException pException)
            {
                // WRITE exception message to debug console:
                Console.WriteLine(pException.Message);
            }
            // CATCH NullReferenceException from accessing dictionaries:
            catch (NullReferenceException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
        }

        /// <summary>
        /// Contrast control button - for controlling contrast
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Required Argument Value(s)</param>
        private void ContrastControl_ValueChanged(object sender, EventArgs e)
        {
            // TRY checking if _contrast() OR ChangeImg() throw a NullInstanceException:
            try
            {
                // IF ContrastControl.Value is MORE than '0':
                if (ContrastControl.Value > 0)
                {
                    // SET ContrastVal label to display positive Contrast value:
                    ContrastVal.Text = "+" + ContrastControl.Value.ToString() + "%";
                }
                // IF ContrastControl.Value is EQUAL to or LESS than '0':
                else
                {
                    // SET ContrastVal label to display Contrast value:
                    ContrastVal.Text = ContrastControl.Value.ToString() + "%";
                }

                // SET value of _commandDict["Contrast"]'s FirstParam property to value of _crrntImgFP:
                (_commandDict["Contrast"] as ICommandParam<string, int, EventHandler<ImageEventArgs>>).FirstParam = _crrntImgFP;

                // SET value of _commandDict["Contrast"]'s SecondParam property to value of original image width multiplied by value in ScaleNumBox:
                //(_commandDict["Contrast"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).SecondParam = (int)((int)_originalSize.X * ScaleNumBox.Value);

                // SET value of _commandDict["Contrast"]'s ThirdParam property to value of original image height multiplied by value in ScaleNumBox:
                //(_commandDict["Contrast"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).ThirdParam = (int)((int)_originalSize.Y * ScaleNumBox.Value);

                // SET value of _commandDict["Contrast"]'s SecondParam property to value of ContrastControl.Value:
                (_commandDict["Contrast"] as ICommandParam<string, int, EventHandler<ImageEventArgs>>).SecondParam = ContrastControl.Value;

                // SET value of _commandDict["Contrast"]'s FourthParam property to reference to OnEvent() (ImageEventArgs):
                (_commandDict["Contrast"] as ICommandParam<string, int, EventHandler<ImageEventArgs>>).ThirdParam = OnEvent;

                // INVOKE _commandDict["Contrast"]'s ExecuteMethod():
                _invokeCommand(_commandDict["Contrast"]);
            }
            // CATCH NullInstanceException from ChangeImg():
            catch (NullInstanceException pException)
            {
                // WRITE exception message to debug console:
                Console.WriteLine(pException.Message);
            }
        }

        /// <summary>
        /// Saturation control button - for controlling saturation
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Required Argument Value(s)</param>
        private void SaturationControl_ValueChanged(object sender, EventArgs e)
        {
            // TRY checking if _saturation() OR ChangeImg() throw a NullInstanceException:
            try
            {
                // IF SaturationControl.Value is MORE than '0':
                if (SaturationControl.Value > 0)
                {
                    // SET SaturationVal label to display positive Saturation value:
                    SaturationVal.Text = "+" + SaturationControl.Value.ToString() + "%";
                }
                // IF SaturationControl.Value is EQUAL to or LESS than '0':
                else
                {
                    // SET SaturationVal label to display Saturation value:
                    SaturationVal.Text = SaturationControl.Value.ToString() + "%";
                }

                // SET value of _commandDict["Saturation"]'s FirstParam property to value of _crrntImgFP:
                (_commandDict["Saturation"] as ICommandParam<string, int, EventHandler<ImageEventArgs>>).FirstParam = _crrntImgFP;

                // SET value of _commandDict["Saturation"]'s SecondParam property to value of original image width multiplied by value in ScaleNumBox:
                //(_commandDict["Saturation"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).SecondParam = (int)((int)_originalSize.X * ScaleNumBox.Value);

                // SET value of _commandDict["Saturation"]'s ThirdParam property to value of original image height multiplied by value in ScaleNumBox:
                //(_commandDict["Saturation"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).ThirdParam = (int)((int)_originalSize.Y * ScaleNumBox.Value);

                // SET value of _commandDict["Saturation"]'s SecondParam property to value of SaturationControl.Value:
                (_commandDict["Saturation"] as ICommandParam<string, int, EventHandler<ImageEventArgs>>).SecondParam = SaturationControl.Value;

                // SET value of _commandDict["Saturation"]'s FourthParam property to reference to OnEvent() (ImageEventArgs):
                (_commandDict["Saturation"] as ICommandParam<string, int, EventHandler<ImageEventArgs>>).ThirdParam = OnEvent;

                // INVOKE _commandDict["Saturation"]'s ExecuteMethod():
                _invokeCommand(_commandDict["Saturation"]);
            }
            // CATCH NullInstanceException from ChangeImg():
            catch (NullInstanceException pException)
            {
                // WRITE exception message to debug console:
                Console.WriteLine(pException.Message);
            }
        }

        #endregion


        #region FILTER METHODS

        /// <summary>
        /// Filter 1 radio button - for first filter 
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Required Argument Value(s)</param>
        private void RadioFilter1_CheckedChanged(object sender, EventArgs e)
        {
            // TRY checking if invoking _commandDict["FilterOne"]() throw a NullInstanceException:
            try
            {
                // SET value of _commandDict["FilterOne"]'s FirstParam property to value of _crrntImgFP:
                (_commandDict["FilterOne"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).FirstParam = _crrntImgFP;

                // SET value of _commandDict["FilterOne"]'s SecondParam property to value of original image width multiplied by value in ScaleNumBox:
                (_commandDict["FilterOne"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).SecondParam = (int)((int)_originalSize.X * ScaleNumBox.Value);

                // SET value of _commandDict["FilterOne"]'s ThirdParam property to value of original image height multiplied by value in ScaleNumBox:
                (_commandDict["FilterOne"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).ThirdParam = (int)((int)_originalSize.Y * ScaleNumBox.Value);

                // SET value of _commandDict["FilterOne"]'s FourthParam property to reference to OnEvent() (ImageEventArgs):
                (_commandDict["FilterOne"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).FourthParam = OnEvent;

                // INVOKE _commandDict["FilterOne"]'s ExecuteMethod():
                _invokeCommand(_commandDict["FilterOne"]);
            }
            // CATCH InvalidStringException from invoking _commandDict["FilterOne"]():
            catch (InvalidStringException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
            // CATCH NullInstanceException from invoking _commandDict["FilterOne"]():
            catch (NullInstanceException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
        }

        /// <summary>
        /// Filter 2 radio button - for second filter
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Required Argument Value(s)</param>
        private void RadioFilter2_CheckedChanged(object sender, EventArgs e)
        {
            // TRY checking if invoking _commandDict["FilterTwo"]() throw a NullInstanceException:
            try
            {
                // SET value of _commandDict["FilterTwo"]'s FirstParam property to value of _crrntImgFP:
                (_commandDict["FilterTwo"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).FirstParam = _crrntImgFP;

                // SET value of _commandDict["FilterTwo"]'s SecondParam property to value of original image width multiplied by value in ScaleNumBox:
                (_commandDict["FilterTwo"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).SecondParam = (int)((int)_originalSize.X * ScaleNumBox.Value);

                // SET value of _commandDict["FilterTwo"]'s ThirdParam property to value of original image height multiplied by value in ScaleNumBox:
                (_commandDict["FilterTwo"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).ThirdParam = (int)((int)_originalSize.Y * ScaleNumBox.Value);

                // SET value of _commandDict["FilterTwo"]'s FourthParam property to reference to OnEvent() (ImageEventArgs):
                (_commandDict["FilterTwo"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).FourthParam = OnEvent;

                // INVOKE _commandDict["FilterTwo"]'s ExecuteMethod():
                _invokeCommand(_commandDict["FilterTwo"]);
            }
            // CATCH InvalidStringException from invoking _commandDict["FilterTwo"]():
            catch (InvalidStringException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
            // CATCH NullInstanceException from invoking _commandDict["FilterTwo"]():
            catch (NullInstanceException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
        }

        /// <summary>
        /// Filter 3 radio button - for third button
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Required Argument Value(s)</param>
        private void RadioFilter3_CheckedChanged(object sender, EventArgs e)
        {
            // TRY checking if invoking _commandDict["FilterThree"]() throw a NullInstanceException:
            try
            {
                // SET value of _commandDict["FilterThree"]'s FirstParam property to value of _crrntImgFP:
                (_commandDict["FilterThree"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).FirstParam = _crrntImgFP;

                // SET value of _commandDict["FilterThree"]'s SecondParam property to value of original image width multiplied by value in ScaleNumBox:
                (_commandDict["FilterThree"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).SecondParam = (int)((int)_originalSize.X * ScaleNumBox.Value);

                // SET value of _commandDict["FilterThree"]'s ThirdParam property to value of original image height multiplied by value in ScaleNumBox:
                (_commandDict["FilterThree"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).ThirdParam = (int)((int)_originalSize.Y * ScaleNumBox.Value);

                // SET value of _commandDict["FilterThree"]'s FourthParam property to reference to OnEvent() (ImageEventArgs):
                (_commandDict["FilterThree"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).FourthParam = OnEvent;

                // INVOKE _commandDict["FilterThree"]'s ExecuteMethod():
                _invokeCommand(_commandDict["FilterThree"]);
            }
            // CATCH InvalidStringException from invoking _commandDict["FilterThree"]():
            catch (InvalidStringException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
            // CATCH NullInstanceException from invoking _commandDict["FilterThree"]():
            catch (NullInstanceException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
        }

        /// <summary>
        /// Filter 4 radio button - for fourth filter
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Required Argument Value(s)</param>
        private void RadioFilter4_CheckedChanged(object sender, EventArgs e)
        {
            // TRY checking if invoking _commandDict["FilterFour"]() throw a NullInstanceException:
            try
            {
                // SET value of _commandDict["FilterFour"]'s FirstParam property to value of _crrntImgFP:
                (_commandDict["FilterFour"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).FirstParam = _crrntImgFP;

                // SET value of _commandDict["FilterFour"]'s SecondParam property to value of original image width multiplied by value in ScaleNumBox:
                (_commandDict["FilterFour"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).SecondParam = (int)((int)_originalSize.X * ScaleNumBox.Value);

                // SET value of _commandDict["FilterFour"]'s ThirdParam property to value of original image height multiplied by value in ScaleNumBox:
                (_commandDict["FilterFour"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).ThirdParam = (int)((int)_originalSize.Y * ScaleNumBox.Value);

                // SET value of _commandDict["FilterFour"]'s FourthParam property to reference to OnEvent() (ImageEventArgs):
                (_commandDict["FilterFour"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).FourthParam = OnEvent;

                // INVOKE _commandDict["FilterFour"]'s ExecuteMethod():
                _invokeCommand(_commandDict["FilterFour"]);
            }
            // CATCH InvalidStringException from invoking _commandDict["FilterFour"]():
            catch (InvalidStringException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
            // CATCH NullInstanceException from invoking _commandDict["FilterFour"]():
            catch (NullInstanceException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
        }

        #endregion


        


        #region NON IMAGE METHODS

        /// <summary>
        /// Resets all Image changes and reverts back to original image state
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Required Argument Value(s)</param>
        private void ResetBttn_Click(object sender, EventArgs e)
        {
            // CALL ChangeImg(), so it resets back to standard image:
            ChangeImg();
        }

        /// <summary>
        /// Displays a MessageBox to show the user how to use the app
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Required Argument Value(s)</param>
        private void HelpBttn_Click(object sender, EventArgs e)
        {
            // Display Information screen to user:
            MessageBox.Show("When changing any colour related properties\n" +
                "such as Brightness, Contrast, Saturation and Filters,\n" +
                "as well as resizing the image,\n\n" +
                "Apply AFTER rotation/flip to prevent having to redo image changes!" 
                ,"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Method which closes an instance of this class and removes any other disposable objects
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void CloseBttn_Click(object sender, EventArgs e)
        {
            // TRY checking if NullInstanceException or NullValueException are thrown:
            try
            {
                // IF ImgDisplay.Image DOES HAVE an active image:
                if (ImgDisplay.Image != null)
                {
                    // SET FirstParam Property value of _commandDict["DisposableRemoval"] to reference to ImgDisplay.Image:
                    (_commandDict["DisposableRemoval"] as ICommandParam<IDisposable>).FirstParam = ImgDisplay.Image;

                    // INVOKE _commandDict["RemoveMe"]'s ExecuteMethod():
                    _invokeCommand(_commandDict["DisposableRemoval"]);
                }

                // INVOKE _commandDict["RemoveMe"]'s ExecuteMethod():
                _invokeCommand(_commandDict["RemoveMe"]);
            }
            // CATCH NullInstanceException from invoking _commandDict["RemoveMe"] or _commandDict["DisposableRemoval"]:
            catch (NullInstanceException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
            // CATCH InvalidStringException addressing Dictionary keys:
            catch (NullReferenceException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
            // CATCH NullInstanceException from invoking _commandDict["RemoveMe"]:
            catch (NullValueException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
        }

        #endregion

        #endregion


        #region MOVEABLE BORDERLESS WINDOW (Price, 2007)

        // Modified from https://stackoverflow.com/a/24561946 and attributed to user jay_t55

        // DECLARE a boolean that is set to true when a mouse down event is detected, name it _mouseDown:
        private bool _mouseDown = false;

        // DECLARE a Point object to store the last location of the window origin (ie memory), name it _lastLocation:
        private Point _lastLocation;

        /// <summary>
        /// Mouse down event handler
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void FishyEdit_MouseDown(object sender, MouseEventArgs e)
        {
            // SET _mouseDown to true:
            _mouseDown = true;

            // STORE current location to _lastLocation:
            _lastLocation = e.Location;
        }


        /// <summary>
        /// Mouse move event handler
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void FishyEdit_MouseMove(object sender, MouseEventArgs e)
        {
            // Only act if mouse button is down...
            if (_mouseDown)
            {
                // SET new location according to mouse movement from _lastLocation:
                this.Location = new Point(
                    (this.Location.X - _lastLocation.X) + e.X, (this.Location.Y - _lastLocation.Y) + e.Y);

                // UPDATE this window:
                this.Update();
            }
        }

        /// <summary>
        /// Mouse up event handler
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void FishyEdit_MouseUp(object sender, MouseEventArgs e)
        {
            // RESET _mouseDown to false:
            _mouseDown = false;
        }


        #endregion


        // DECLARE Pen name it '_crpPen':
        public Pen _crpPen;

        //DECLARE int's for the crop x&y and the x&y of the rectangle drawn:
        private int _crpX, _crpY, _rectW, _rectH;


        private void CropBttn_Click_1(object sender, EventArgs e)
        {
            // size of picturebox this will be needed so that the croped img knows where to be placed 
            int _w = ImgDisplay.Width;
            int _H = ImgDisplay.Height;

            ImgDisplay.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);

            ImgDisplay.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);

            ImgDisplay.MouseEnter += new EventHandler(pictureBox1_MouseEnter);

            Controls.Add(ImgDisplay);

            _crpPen = new Pen(Color.White);

        }
        

        private void Confirm_Click(object sender, EventArgs e)
        {
            // pass the picture box dimensions to imgEditor

            // pass picture box client rectangle

            // pass _rectW, _rectH, _crpX & _crpY

            Cursor = Cursors.Default;

            ImgDisplay.MouseEnter -= new EventHandler(pictureBox1_MouseEnter);
            ImgDisplay.MouseMove -= new MouseEventHandler(pictureBox1_MouseMove);
            ImgDisplay.MouseDown -= new MouseEventHandler(pictureBox1_MouseDown);

            //ImgDisplay.Image = _crpImg;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                Cursor = Cursors.Cross;

                _crpPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

                //Set initial x,y 
                _crpX = e.X;
                _crpY = e.Y;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                ImgDisplay.Refresh();
                //set width and height for crop rect
                _rectW = e.X - _crpX;

                _rectH = e.Y - _crpY;


                Graphics _graphics = ImgDisplay.CreateGraphics();

                _graphics.DrawRectangle(_crpPen, _crpX, _crpY, _rectW, _rectH);
                _graphics.Dispose();
            }


        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            base.OnMouseEnter(e);
            Cursor = Cursors.Cross;

        }

    }
}
