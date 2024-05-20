using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    [SerializeField]
    private Camera playerCamera;

    private float _xRotation = 0.0f;

    [SerializeField]
    private float xSens = 30.0f;
    [SerializeField]
    private float ySens = 30.0f;

    public void Look(Vector2 input) {
        _xRotation -= (input.y * Time.deltaTime) * ySens;
        _xRotation = Mathf.Clamp(_xRotation, -90.0f, 90.0f);
        
        playerCamera.transform.localRotation = Quaternion.Euler(_xRotation, 0.0f, 0.0f);
        transform.Rotate(Vector3.up * (Time.deltaTime * xSens * input.x));
    }
}
