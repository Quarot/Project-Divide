using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [Tooltip("Check this box to lock the door")]
    [SerializeField]
    private bool isLocked;

    [Tooltip("Display text for when the player looks at the door, while it's locked")]
    [SerializeField]
    private string lockedDisplayText = "It's locked.";

    [Tooltip("Play this when the player interacts with the door, while it's locked/without a key")]
    [SerializeField]
    private AudioClip lockedAudioClip;

    [Tooltip("Play this when the player interacts with the door, while it's unlocked/with a key")]
    [SerializeField]
    private AudioClip openAudioClip;

    public override string DisplayText => isLocked ? lockedDisplayText : base.DisplayText;

    //Alternative way to express the same as above--altering the text
    //public override string DisplayText
    //{
    //    get
    //    {
    //        if (isLocked)
    //            return lockedDisplayText;
    //        else
    //            return base.DisplayText;
    //    }
    //}

    private Animator animator;
    private bool isOpen = false;
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
    }

    public override void InteractWith()
    {
        if (!isOpen)
        {
            if (!isLocked)
            {
                audioSource.clip = openAudioClip;
                animator.SetBool("shouldOpen", true);
                displayText = string.Empty;
                //displayText = string.ResponseText;
                isOpen = true;

            }
            else
            {
                audioSource.clip = lockedAudioClip;
                //displayText = "I said it's locked.";
            }
            base.InteractWith(); //This plays the sound effect
        }
    }
}
