using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSetActive : InteractiveObject
{
    [Tooltip("The Game Object to Toggle")]
    [SerializeField]
    private GameObject objectToToggle;

    /// <summary>
    /// Toggles the activeSelf value for the objectToToggle when the player interacts with this item.
    /// </summary>
    
    public override void InteractWith()
    {
        base.InteractWith();
        objectToToggle.SetActive(!objectToToggle.activeSelf);
    }
}
