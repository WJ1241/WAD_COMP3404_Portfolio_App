using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Server.Exceptions;

namespace GUI.Logic
{
    /// <summary>
    /// Class which can Open and Save files on a client's device
    /// Author: William Smith & 'Hassan'
    /// Date: 02/12/21
    /// </summary>
    /// <REFERENCE> Hassan (2014) How to get file path from OpenFileDialog and FolderBrowserDialog? Available at: https://stackoverflow.com/questions/24449988/how-to-get-file-path-from-openfiledialog-and-folderbrowserdialog. (Accessed: 26 November 2021) </REFERENCE>
    public class OpenSaveLogic : IOpenImage, ISaveImage
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of OpenSaveLogic
        /// </summary>
        public OpenSaveLogic()
        {
            // EMPTY CONSTRUCTOR
        }

        #endregion


        #region IMPLEMENTATION OF IOPENIMAGE

        /// <summary>
        /// Open Image, User is directed to App's Displayable folder
        /// </summary>
        /// <returns> List of File Names </returns>
        /// <CITATION> (Hassan, 2014) </CITATION>
        public IList<String> OpenImage()
        {
            // DECLARE & INSTANTIATE a temporary IList<String>, name it '_tempList', holds file paths collected from OpenFileDialog:
            IList<String> _tempList = new List<String>();

            // DECLARE & INSTANTIATE a new OpenFileDialog, name it 'pOFD':
            using (OpenFileDialog pOFD = new OpenFileDialog())
            {
                // SET InitialDirectory to FishAssets folder:
                pOFD.InitialDirectory = Path.GetFullPath("..\\..\\..\\..\\Server\\Displayables\\FishAssets");

                // SET title of Dialog to 'Load Your Image!'
                pOFD.Title = "Load Your Image!";

                // SET Multiselect Property to true:
                pOFD.Multiselect = true;

                // FILTER File Extensions to .PNG:
                pOFD.Filter = "PNG Files (*.png)|*.png";

                // IF User has clicked 'OK' on OpenFileDialog:
                if (pOFD.ShowDialog() == DialogResult.OK)
                {
                    // FOREACH String in selected FileNames array:
                    foreach (String pString in pOFD.FileNames)
                    {
                        // ADD pString to _tempList:
                        _tempList.Add(Path.GetFullPath(pString));
                    }
                }
            }

            // RETURN _tempList:
            return _tempList;
        }

        #endregion


        #region IMPLEMENTATION OF ISAVEIMAGE

        /// <summary>
        /// Saves Image, Gives user choice of where to store
        /// </summary>
        /// <param name="pImage"> Image currently displayed on screen </param>
        public void SaveImage(Image pImage)
        {
            // IF pImage IS NOT null:
            if (pImage != null)
            {
                // DECLARE & INSTANTIATE a new SaveFileDialog, name it 'pSFD':
                using (SaveFileDialog pSFD = new SaveFileDialog())
                {
                    // SET InitialDirectory to FishAssets folder:
                    pSFD.InitialDirectory = Path.GetFullPath("..\\..\\..\\..\\Server\\Displayables\\FishAssets");

                    // SET title of Dialog to 'Save Your Image!'
                    pSFD.Title = "Save Your Image!";

                    // FILTER File Extensions to .PNG:
                    pSFD.Filter = "PNG Files (*.png)|*.png";

                    // IF User has clicked 'OK' on OpenFileDialog:
                    if (pSFD.ShowDialog() == DialogResult.OK)
                    {
                        // IF FileName IS NOT empty:
                        if (pSFD.FileName != "")
                        {
                            // DECLARE & ASSIGN a FileStream, name it '_fs', and give result value of pSFD.OpenFile():
                            FileStream _fs = (FileStream)pSFD.OpenFile();

                            // SAVE pImage to the User's device at chosen directory:
                            pImage.Save(_fs, System.Drawing.Imaging.ImageFormat.Png);

                            // CLOSE FileStream:
                            _fs.Close();
                        }
                    }
                }
            }
            // IF pImage DOES NOT save:
            else
            {
                // THROW new FileNotSavedException, with corresponding message:
                throw new FileNotSavedException("ERROR: Requested Image to be saved does not exist in Program!");
            }
        }

        #endregion
    }
}
