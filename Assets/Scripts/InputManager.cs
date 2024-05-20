using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {
    private PlayerInput _playerInput;

    private PlayerInput.OnFootActions _onFoot;

    private PlayerMovement _playerMovement;

    private PlayerCamera _playerCamera;

    private void OnEnable() {
        _onFoot.Enable();
    }

    private void OnDisable() {
        _onFoot.Disable();
    }

    private void Awake() {
        _playerInput = new PlayerInput();
        _onFoot = _playerInput.OnFoot;
        _playerMovement = GetComponent<PlayerMovement>();
        _playerCamera = GetComponent<PlayerCamera>();
        
        _onFoot.Jump.performed += ctx => _playerMovement.Jump();
        _onFoot.Crouch.performed += ctx => _playerMovement.Crouch();
        _onFoot.Sprint.performed += ctx => _playerMovement.Sprint();
    }

    private void FixedUpdate() {
        _playerMovement.Move(_onFoot.Movement.ReadValue<Vector2>());
        _playerCamera.Look(_onFoot.Look.ReadValue<Vector2>());
    }
}