using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    protected override void Interact() {
        Debug.Log("Interacted with " + gameObject.name);
    }
}
