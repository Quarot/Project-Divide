using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuItemToggle : MonoBehaviour
{
    [Tooltip("The image component used to show the associated object's icon.")]
    [SerializeField]
    private Image iconImage;

    private InventoryObject associatedInventoryObject;

    private void Start()
    {
        iconImage.sprite = associatedInventoryObject.Icon;
    }
}
