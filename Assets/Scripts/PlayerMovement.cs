using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour {
    private CharacterController _playerController;

    [FormerlySerializedAs("movementSpeed")]
    [SerializeField]
    private float walkingSpeed = 5.0f;

    [SerializeField]
    private float sprintingSpeed = 8.0f;

    private float _speed;

    private bool _isGrounded;
    private bool _isCrouching;
    private bool _isTransitioning;
    private bool _isSprinting;

    private float _standingHeight = 2.0f;
    private float _crouchingHeigth = 1.0f;
    private float _crouchTransitionTime = 1.0f;

    [SerializeField]
    private float gravity = -9.8f;

    private Vector3 _velocity;

    [SerializeField]
    private float jumpHeight = 1.0f;

    void Start() {
        _playerController = GetComponent<CharacterController>();
        _speed = walkingSpeed;
    }

    void Update() {
        _isGrounded = _playerController.isGrounded;

        if (_isTransitioning) {
            _crouchTransitionTime += Time.deltaTime;
            float a = _crouchTransitionTime / 1;
            a *= a;
            if (_isCrouching) {
                _playerController.height = Mathf.Lerp(_playerController.height, _crouchingHeigth, a);
            } else {
                _playerController.height = Mathf.Lerp(_playerController.height, _standingHeight, a);
            }

            if (a > 1) {
                _crouchTransitionTime = 0.0f;
                _isTransitioning = false;
            }
        }
    }

    public void Move(Vector2 input) {
        Vector3 moveDirection = new Vector3(input.x, 0.0f, input.y);
        _playerController.Move(transform.TransformDirection(moveDirection) * (_speed * Time.deltaTime));
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

    public void Crouch() {
        _isCrouching = !_isCrouching;
        _crouchTransitionTime = 0.0f;
        _isTransitioning = true;
    }

    public void Sprint() {
        _isSprinting = !_isSprinting;
        if (_isSprinting) {
            _speed = sprintingSpeed;
        } else {
            _speed = walkingSpeed;
        }
    }
}