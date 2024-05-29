using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Interactable : MonoBehaviour {
    public string interactMessage;

    public Outline _outline;

    public void BaseInteract() {
        Interact();
    }
    protected virtual void Interact() {
        
    }

    public void EnableOutline() {
        _outline.enabled = true;
    }
    
    public void DisableOutline() {
        _outline.enabled = false;
    }
}
