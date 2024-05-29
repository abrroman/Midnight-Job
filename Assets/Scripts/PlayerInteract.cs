using TMPro;
using UnityEditor;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {
    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    private LayerMask mask;

    private PlayerUI _playerUI;

    private float _interactDistance = 2.0f;

    private InputManager _inputManager;

    private Interactable _currentInteractable;

    private void Start() {
        _playerUI = GetComponent<PlayerUI>();
        _inputManager = GetComponent<InputManager>();
    }

    private void Update() {
        _playerUI.UpdateText(string.Empty);
        
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out var hit, _interactDistance)) {
            if (hit.collider.GetComponent<Interactable>()) {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (_currentInteractable && interactable != _currentInteractable) {
                    _currentInteractable.DisableOutline();
                }
                SetInteractable(interactable);
                if (_inputManager.onFoot.Interact.triggered) {
                    _currentInteractable.BaseInteract();
                }
            } else {
                DisableInteractable();
            }
        } else {
            DisableInteractable();
        }
    }
    
    private void SetInteractable(Interactable newInteractable) {
        _currentInteractable = newInteractable;
        _playerUI.UpdateText(_currentInteractable.interactMessage);
        _currentInteractable.EnableOutline();
    }
    
    private void DisableInteractable() {
        if (_currentInteractable) {
            _currentInteractable.DisableOutline();
            _currentInteractable = null;
        }
    }
}
