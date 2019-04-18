using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [Tooltip("The item required to open the door. Assigning a key here will lock the door.")]
    [SerializeField]
    private InventoryObject key;

    [Tooltip("If this is checked, the associated key will be removed from the player's inventory when the door is unlocked.")]
    [SerializeField]
    private bool consumesKey;

    [Tooltip("Display text for when the player looks at the door, while it's locked")]
    [SerializeField]
    private string lockedDisplayText = "It's locked.";

    [Tooltip("Play this when the player interacts with the door, while it's locked/without a key")]
    [SerializeField]
    private AudioClip lockedAudioClip;

    [Tooltip("Play this when the player interacts with the door, while it's unlocked/with a key")]
    [SerializeField]
    private AudioClip openAudioClip;

    //public override string DisplayText => isLocked ? lockedDisplayText : base.DisplayText;

    //Alternative way to express the same as above--altering the text
    public override string DisplayText
    {
        get
        {
            string toReturn;

            if (isLocked)
                toReturn = HasKey ? $"Use {key.ObjectName}" : lockedDisplayText;
            else
                toReturn = base.DisplayText;

            return toReturn;
        }
    }
    private bool HasKey => PlayerInventory.InventoryObjects.Contains(key);
    private Animator animator;
    private bool isOpen = false;
    private bool isLocked;
    private int shouldOpenAnimParameter = Animator.StringToHash(nameof(shouldOpenAnimParameter));
    /// <summary>
    /// Using a constructor here to initialize display text in the editor
    /// </summary>
    public Door()
    {
        displayText = nameof(Door);
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        InitializeIsLocked();
    }

    private void InitializeIsLocked()
    {
        if (key != null)
            isLocked = true;
    }

    public override void InteractWith()
    {
        if (!isOpen)
        {
            if (isLocked && !HasKey)
            {
                audioSource.clip = lockedAudioClip;
            }
            else //if it's not locked, or if it's locked and we have the key...
            {
                audioSource.clip = openAudioClip;
                animator.SetBool("shouldOpen", true);
                displayText = string.Empty;
                //displayText = string.ResponseText;
                isOpen = true;
                UnlockDoor();
            }
            base.InteractWith(); //This plays the sound effect
        }
    }

    private void UnlockDoor()
    {
        isLocked = false;
        if (key != null && consumesKey)
            PlayerInventory.InventoryObjects.Remove(key);
    }
}
