﻿/// <summary>
/// Interface for elements the player can interact with by playing the interact button. 
/// </summary>

public interface IInteractive
{
    string DisplayText { get; }
    void InteractWith();
}
