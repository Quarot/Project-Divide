using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    [Tooltip("The name of the object, as it will appear in the inventory menu UI")]
    [SerializeField]
    private string objectName = nameof(InventoryObject);

    [Tooltip("The text that will display when the player selects this object in the inventory menu.")]
    [TextArea(3,8)]
    [SerializeField]
    private string description;

    [Tooltip("Icon to display for this item in the inventory menu.")]
    [SerializeField]
    private Sprite icon;


    public string ObjectName => objectName;

    private new Renderer renderer;
    private new Collider collider;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }

    public InventoryObject()
    {
        displayText = $"Take {objectName}";
    }

        /// <summary>
        /// When the player interacts with the inventory object, we need to do 2 things:
        /// 1. Add the inventory object to the PlayerInventory list
        /// 2. Remove the object from the game world / scene
        ///     Can't use Destroy, because we need to keep the GameObject in the inventory list
        ///     So we just disable the Collider and Renderer
        /// </summary>
        
    public override void InteractWith()
    {
        base.InteractWith();
        PlayerInventory.InventoryObjects.Add(this);
        GetComponent<Renderer>().enabled = false;
        renderer.enabled = false;
        collider.enabled = false;

        Debug.Log($"Inventory menu game object name {InventoryMenu.Instance.name}");
    }
}
