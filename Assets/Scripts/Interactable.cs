using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Interactable : MonoBehaviour {
    [FormerlySerializedAs("msg")]
    public string interactMessage;

    public void BaseInteract() {
        Interact();
    }
    protected virtual void Interact() {
        
    }
}
