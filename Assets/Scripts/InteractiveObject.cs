using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InteractiveObject : MonoBehaviour, IInteractive
{
    [SerializeField]
    protected string displayText = nameof(InteractiveObject);

    [SerializeField]
    private string responseText;

    public string DisplayText => displayText;
    private AudioSource audioSource;

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void InteractWith()
    {
        try
        {
            audioSource.Play(); 

        }
        catch (System.Exception)
        {

            throw new System.Exception("Missing audiosource component or audio clip: InteractiveObject requires an audioSource component with an audio clip assigned.");
        }
        Debug.Log($"Player just interacted with {gameObject.name}.");
    }
}
