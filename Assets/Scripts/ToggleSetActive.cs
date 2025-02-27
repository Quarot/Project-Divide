﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSetActive : InteractiveObject
{
    [Tooltip("The Game Object to Toggle")]
    [SerializeField]
    private GameObject objectToToggle;

    [Tooltip("Can the player interact with this more than once?")]
    [SerializeField]
    private bool isReusable;

    private bool hasBeenUsed = false;

    /// <summary>
    /// Toggles the activeSelf value for the objectToToggle when the player interacts with this item.
    /// </summary>

    public override void InteractWith()
    {
        if (isReusable || !hasBeenUsed)
        {
            base.InteractWith();
            objectToToggle.SetActive(!objectToToggle.activeSelf);
            hasBeenUsed = true;
            //Later, this will lead to story progress, in changing the text response
            if (!isReusable)
            {
                displayText = string.Empty;
            }
        }
    }
}
