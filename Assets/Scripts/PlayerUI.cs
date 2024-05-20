using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI message;
    
    void Start()
    {
        
    }

    public void UpdateText(string text) {
        message.text = text;
    }
}
