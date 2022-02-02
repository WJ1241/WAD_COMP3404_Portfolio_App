using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Server.Exceptions;
using Server.GeneralInterfaces;

namespace Server
{
    /// <summary>
    /// Class which stores Dictionary of Images with File Path acting as a UID accessor
    /// Author: William Smith & 'Matt'
    /// Date: 02/12/21
    /// </summary>
    /// <REFERENCE> Matt (2013) How to resize an Image C#. Available at: https://stackoverflow.com/questions/1922040/how-to-resize-an-image-c-sharp. (Accessed: 30 November 2021).
    public class ImageMgr : IManageImg
    {
        #region FIELD VARIABLES

        // DECLARE an IDictionary<String, Image>, name it '_imgDict':
        private IDictionary<String, Image> _imgDict;

        // DECLARE an Image, name it '_tempImage':
        // FIXED ISSUE OF SAVING BITMAP TO DICTIONARY REPEATEDLY, LED TO COMPRESSION AND BLUR
        private Image _tempImage;

        #endregion


        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of ImageMgr
        /// </summary>
        public ImageMgr()
        {
            // INSTANTIATE _imgDict as new Dictionary<String, Image>():
            _imgDict = new Dictionary<String, Image>();
        }

        #endregion


        #region IMPLEMENTATION OF IMANAGEIMG

        /// <summary>
        /// Filters a passed in list, to prevent duplication of strings
        /// </summary>
        /// <param name="pList"> Unfiltered IList<String> object </param>
        /// <returns> Filtered IList<String> object </returns>
        public IList<String> ReturnFilteredList(IList<String> pList)
        {
            // DECLARE & INSTANTIATE temporary IList<String>, name it '_tempList', holds new file paths that HAVE NOT been stored:
            IList<String> _tempList = new List<String>();

            // TRY Checking AddToDictionary() to see if any FileAlreadyStoredExceptions are thrown:
            try
            {
                // FOREACH String value in pList:
                foreach (String pString in pList)
                {
                    // ADD result from AddToDictionary to temporary list:
                    _tempList.Add(AddToDictionary(pString));
                }
            }
            // CATCH FileAlreadyStoredException from AddToDictionary method:
            catch (FileAlreadyStoredException pException)
            {
                // WRITE Exception message to Debug Console:
                System.Diagnostics.Debug.WriteLine(pException.Message);

                // THROW new FileAlreadyStoredException, with corresponding message:
                throw new FileAlreadyStoredException(pException.Message);
            }

            // RETURN _tempList back to caller:
            return _tempList;
        }

        /// <summary>
        /// Returns Image using File Name as a key to the Dictionary
        /// </summary>
        /// <param name="pFileName"> UID to access Specific Image </param>
        /// <returns> Image stored via pFileName in Dictionary </returns>
        public Image ReturnImg(String pFileName)
        {
            // IF _imgDict DOES contain pFileName's value as a key:
            if (_imgDict.ContainsKey(pFileName))
            {
                // RETURN modified _imgDict[pFileName]:
                return _imgDict[pFileName];
            }
            // IF _imgDict DOES NOT contain pFileName's value as a key:
            else
            {
                // THROW new InvalidStringException, with corresponding message:
                throw new InvalidStringException("ERROR: Requested Image from File Path is not stored in the Program!");
            }
        }

        /// <summary>
        /// Returns Image using File Name as a key to the Dictionary
        /// </summary>
        /// <param name="pFileName"> UID to access Specific Image </param>
        /// <param name="pFrameWidth"> Width to change Image to </param>
        /// <param name="pFrameHeight"> Height to change Image to </param>
        /// <returns> Image stored via pFileName in Dictionary </returns>
        /// <CITATION> (Matt, 2013) </CITATION>
        public Image ReturnImg(String pFileName, int pFrameWidth, int pFrameHeight)
        {
            // IF _imgDict DOES contain pFileName's value as a key:
            if (_imgDict.ContainsKey(pFileName))
            {
                // IF _tempImage has an active instance:
                if (_tempImage != null)
                {
                    // DISPOSE old image to prevent memory leak:
                    _tempImage.Dispose();
                }

                // INITIALISE _tempImage, give value of _imgDict[pFileName] with new Size:
                _tempImage = new Bitmap(_imgDict[pFileName], new Size(pFrameWidth, pFrameHeight));

                // RETURN _tempImage:
                return _tempImage;
            }
            // IF _imgDict DOES NOT contain pFileName's value as a key:
            else
            {
                // THROW new InvalidStringException, with corresponding message:
                throw new InvalidStringException("ERROR: Requested Image from File Path is not stored in the Program!");
            }
        }

        #endregion


        #region PRIVATE METHODS

        /// <summary>
        /// Adds new image to dictionary using File Name
        /// </summary>
        /// <param name="pFileName"> File Name to be added to Dictionary </param>
        /// <returns> File Path that has not been stored </returns>
        private String AddToDictionary(String pFileName)
        {
            // IF _imgDict DOES NOT Contain pFileName's value as a key:
            if (!_imgDict.ContainsKey(pFileName))
            {
                // ADD pFileName as a key, and converted image as a value to _imgDict:
                _imgDict.Add(pFileName, Image.FromFile(Path.GetFullPath(pFileName)));

                // RETURN value of pFileName to caller:
                return pFileName;
            }
            // IF _imgDict DOES contain pFileName's value as a key:
            else
            {
                // THROW new FileAlreadyStoredException, with corresponding message:
                throw new FileAlreadyStoredException("ERROR: Image File has already been loaded in Program!");
            }
        }

        #endregion
    }
}
