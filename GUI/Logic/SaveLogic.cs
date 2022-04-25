using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Server.Exceptions;
using GUI.Logic.Interfaces;
using System;

namespace GUI.Logic
{
    /// <summary>
    /// Class which can Save files on a client's device
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 02/02/22
    /// </summary>
    public class SaveLogic : ISaveImage
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of SaveLogic
        /// </summary>
        public SaveLogic()
        {
            // EMPTY CONSTRUCTOR
        }

        #endregion


        #region IMPLEMENTATION OF ISAVEIMAGE

        /// <summary>
        /// Saves Image, Gives user choice of where to store
        /// </summary>
        /// <param name="pImage"> Image currently displayed on screen </param>
        public void SaveImage(Image pImage)
        {
            // TRY catching exceptions from saving images:
            try
            {
                // IF pImage DOES HAVE an active instance:
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
                                // DECLARE & ASSIGN a FileStream, name it 'fs', and give result value of pSFD.OpenFile():
                                FileStream fs = (FileStream)pSFD.OpenFile();

                                // SAVE pImage to the User's device at chosen directory:
                                pImage.Save(fs, System.Drawing.Imaging.ImageFormat.Png);

                                // CLOSE FileStream:
                                fs.Close();
                            }
                        }
                    }
                }
                // IF pImage DOES NOT HAVE an active instance:
                else
                {
                    // THROW new FileNotSavedException, with corresponding message:
                    throw new FileNotSavedException("ERROR: Requested Image to be saved does not exist in Program!");
                }
            }
            // CATCH IOException from SaveFileDialog.OpenFile():
            // THIS IS CAUGHT BECAUSE AN IMAGE BEING USED WILL BECOME NULL AND THEREFORE STORAGE WILL THEN CONTAIN A NULL IMAGE
            catch (IOException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);

                // SHOW Error message to detail that user cannot overwrite an image that is in use:
                MessageBox.Show("Images currently being stored in the app cannot be overwritten!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
