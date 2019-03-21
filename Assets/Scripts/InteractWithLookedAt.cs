using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects when interact button is pressed 
/// </summary>


public class InteractWithLookedAt : MonoBehaviour
{
    [SerializeField]
    private DetectLookedAtInteractive detectLookedAtInteractive;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && detectLookedAtInteractive.LookedAtInteractive != null)
        {
            Debug.Log("player pressed INTERACT button");
            detectLookedAtInteractive.LookedAtInteractive.InteractWith();
        }

        //if (Input.GetButtonDown("Interact"))
        //{
        //    Debug.Log("player pressed INTERACT button");
        //    //detectLookedAtInteractive.lookedAtInteractive.InteractWith();
        //}
    }
}
