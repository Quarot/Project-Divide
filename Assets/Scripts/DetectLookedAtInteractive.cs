﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLookedAtInteractive : MonoBehaviour
{
    [Tooltip("Starting point of raycast used to detect interactives.")]
    [SerializeField]
    private Transform raycastOrigin;

    [Tooltip("How far from the raycastOrigin will we search for interactive elements.")]
    [SerializeField]
    private float maxRange = 5.0f;

    private Vector3 raycastDirection;

    /// <summary>
    /// Event raised when the player looks at a different IInteractive.
    /// </summary>
    public static event Action<IInteractive> LookedAtInteractiveChanged;

    public IInteractive LookedAtInteractive
    {
        get { return lookedAtInteractive; }
        private set
        {
            bool isInteractiveChanged = value != lookedAtInteractive;
            if (isInteractiveChanged)
            {
                lookedAtInteractive = value;
                
                LookedAtInteractiveChanged?.Invoke(lookedAtInteractive);
            }
        }
    }

    private IInteractive lookedAtInteractive;



    private void FixedUpdate()
    {
        LookedAtInteractive = GetLookedAtInteractive();

    }

    /// <summary>
    /// Raycasts forward from the camera to look for IInteraction
    /// </summary>
    /// <returns>The first IInteractive detected, or null if none are found.</returns>

    private IInteractive GetLookedAtInteractive()
    {
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxRange, Color.red);
        RaycastHit hitInfo;
        bool objectWasDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxRange);

        IInteractive interactive = null;

        LookedAtInteractive = interactive;

        if (objectWasDetected)
        {
            //Debug.Log($"Player is looking at: { hitInfo.collider.gameObject.name}");
            interactive = hitInfo.collider.gameObject.GetComponent<IInteractive>();
        }

        

        return interactive;
    }
}
