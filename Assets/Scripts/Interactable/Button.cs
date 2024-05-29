using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{

    private void Start() {
        _outline = GetComponent<Outline>();
        DisableOutline();
    }
    
    void Update()
    {
        
    }

    protected override void Interact() {
        Debug.Log("Interacted with " + gameObject.name);
    }
}
