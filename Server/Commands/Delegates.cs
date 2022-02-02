﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace Server.Delegates
{
    //----------------------------------------//

    /// <summary>
    /// C# File to store Delegate Methods
    /// Author: William Eardley, William Smith
    /// Date: 21/01/22
    /// </summary>

    //----------------------------------------//

    #region SYSTEM
    
    /// <summary>
    /// Delegate used for Loading an object with a List of Strings
    /// </summary>
    /// <param name="pStringList"> List of Strings </param>
    /// <returns> Edited or New List of Strings </returns>
    public delegate IList<String> LoadDelegate(IList<String> pStringList);

    /// <summary>
    /// Delegate used to delete an IDisposable object
    /// </summary>
    /// <param> IDisposable object </param>
    public delegate void DeleteDelegate(IDisposable pDisposable);

    #endregion


    #region SYSTEM.DRAWING

    /// <summary>
    /// Delegate used to return an image with a scaled size
    /// </summary>
    /// <param name="pUid"> Unique ID </param>
    /// <param name="pWidth"> Width to scale Image to </param>
    /// <param name="pHeight"> Height to scale Image to </param>
    /// <returns> Scaled Image created from pUid </returns>
    public delegate Image GetImageDelegate(String pUid, int pWidth, int pHeight);

    /// <summary>
    /// Delegate used for Rotation with a String parameter
    /// </summary>
    /// <param name="pObject"> Reference to Object to be rotated </param>
    public delegate void RotationDelegate(String pObject);

    /// <summary>
    /// Delegate used for Anticlockwise Rotation with a String parameter
    /// </summary>
    /// <param name="pObject"> Reference to Object to be rotated </param>
    public delegate void ACRotationDelegate(String pObject);

    /// <summary>
    /// Delegate used for horizontally flipping an image with a String parameter
    /// </summary>
    /// <param name="pObject"> Reference to Object to be H Flipped </param>
    public delegate void HFlipImageDelegate(String pObject);

    /// <summary>
    /// Delegate used for vertically flipping an image with a String parameter
    /// </summary>
    /// <param name="pObject"> Reference to Object to be V Flipped </param>
    public delegate void VFlipImageDelegate(String pObject);

    /// <summary>
    /// Delegate used for cropping an image with a string parameter
    /// </summary>
    /// <param name="pObject"> Reference to object to be cropped</param>
    public delegate void CropDelegate(String pObject);

    /// <summary>
    /// Delegate used for scaling an image with a string parameter
    /// </summary>
    /// <param name="pObject">Reference to object to be scaled</param>
    public delegate void ScaleDelegate(String pObject);

    /// <summary>
    /// Delegate used for changing brightness on an image with a String parameter
    /// </summary>
    /// <param name="pObject">Reference to object to have brightness changed</param>
    public delegate void BrightnessDelegate(String pObject);

    /// <summary>
    /// Delegate used for changing contrast on an image with a String parameter
    /// </summary>
    /// <param name="pObject">Reference to object to have contrast changed</param>
    public delegate void ContrastDelegate(String pObject);

    /// <summary>
    /// Delegate used for changing saturation on an image with a String parameter
    /// </summary>
    /// <param name="pObject">Reference to object to have saturation changed</param>
    public delegate void SaturationDelegate(String pObject);

    /// <summary>
    /// Delegate used for first filter on an image with a String parameter
    /// </summary>
    /// <param name="pObject">Reference to object to apply first filter</param>
    public delegate void FilterOneDelegate(String pObject);

    /// <summary>
    /// Delegate used for second filter on an image with a String parameter
    /// </summary>
    /// <param name="pObject">Reference to object to apply second filter</param>
    public delegate void FilterTwoDelegate(String pObject);

    /// <summary>
    /// Delegate used for third filter on an image with a String parameter
    /// </summary>
    /// <param name="pObject">Reference to object to apply third filter</param>
    public delegate void FilterThreeDelegate(String pObject);

    /// <summary>
    /// Delegate used for fourth filter on an iamge with a String parameter
    /// </summary>
    /// <param name="pObject">Reference to object to apply fourth filter</param>
    public delegate void FilterFourDelegate(String pObject);

    /// <summary>
    /// Delegate used for removing filters applied on an image with a String parameter
    /// </summary>
    /// <param name="pObject">Reference to object to apply no filter</param>
    public delegate void FilterRemoveDelegate(String pObject);

    #endregion
}