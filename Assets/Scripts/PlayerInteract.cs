using UnityEngine;

public class PlayerInteract : MonoBehaviour {
    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    private LayerMask mask;

    private PlayerUI _playerUI;

    private float _interactDistance = 2.0f;

    private InputManager _inputManager;

    private void Start() {
        _playerUI = GetComponent<PlayerUI>();
        _inputManager = GetComponent<InputManager>();
    }

    private void Update() {
        _playerUI.UpdateText(string.Empty);
        
        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * _interactDistance);
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out var hit, _interactDistance)) {
            if (hit.collider.GetComponent<Interactable>()) {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                _playerUI.UpdateText(interactable.interactMessage);
                if (_inputManager.onFoot.Interact.triggered) {
                    interactable.BaseInteract();
                }
            }
        }

    }
}
