using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {
    private PlayerInput _playerInput;

    public PlayerInput.OnFootActions onFoot;

    private PlayerMovement _playerMovement;

    private PlayerCamera _playerCamera;

    private void OnEnable() {
        onFoot.Enable();
    }

    private void OnDisable() {
        onFoot.Disable();
    }

    private void Awake() {
        _playerInput = new PlayerInput();
        onFoot = _playerInput.OnFoot;
        _playerMovement = GetComponent<PlayerMovement>();
        _playerCamera = GetComponent<PlayerCamera>();
        
        onFoot.Jump.performed += ctx => _playerMovement.Jump();
        onFoot.Crouch.performed += ctx => _playerMovement.Crouch();
        onFoot.Sprint.performed += ctx => _playerMovement.Sprint();
    }

    private void Update() {
        _playerMovement.Move(onFoot.Movement.ReadValue<Vector2>());
        _playerCamera.Look(onFoot.Look.ReadValue<Vector2>());
    }
}