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

    public virtual string DisplayText => displayText;
    protected AudioSource audioSource;

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void InteractWith()
    {
        try
        {
            audioSource.Play();

            //This is a way for the text to change, which is a core feature of the intended project. May likely be reworked to be put somewhere else. As of 4-11-19, it replaces the Display Text

            //displayText = responseText;
        }
        catch (System.Exception)
        {

            throw new System.Exception("Missing audiosource component or audio clip: InteractiveObject requires an audioSource component with an audio clip assigned.");
        }
        Debug.Log($"Player just interacted with {gameObject.name}.");
    }
}
