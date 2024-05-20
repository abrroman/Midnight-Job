using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private CharacterController _playerController;

    [SerializeField]
    private float movementSpeed = 5.0f;

    private bool _isGrounded;

    [SerializeField]
    private float gravity = -9.8f;

    private Vector3 _velocity;

    [SerializeField]
    private float jumpHeight = 1.0f;
 
    void Start() {
        _playerController = GetComponent<CharacterController>();
    }
    
    void Update() {
        _isGrounded = _playerController.isGrounded;
    }

    public void Move(Vector2 input) {
        Vector3 moveDirection = new Vector3(input.x, 0.0f, input.y);
        _playerController.Move(transform.TransformDirection(moveDirection) * (movementSpeed * Time.deltaTime));
        _velocity.y += gravity * Time.deltaTime;
        if (_isGrounded && _velocity.y < 0) {
            _velocity.y = -2.0f;
        }
        _playerController.Move(_velocity * Time.deltaTime);

    }

    public void Jump() {
        if (_isGrounded) {
            _velocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
}
