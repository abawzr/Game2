using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody _rigidBody;
    private Vector2 _moveInput;
    private Vector3 _moveDirection;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if (InputManager.Instance != null)
        {
            InputManager.Instance.OnMove += HandleMoveInput;
        }
    }
    private void FixedUpdate()
    {
        _moveDirection = (transform.right * _moveInput.x + transform.forward * _moveInput.y) * moveSpeed;
        _rigidBody.linearVelocity = new Vector3(_moveDirection.x, _rigidBody.linearVelocity.y, _moveDirection.z);
    }

    private void HandleMoveInput(Vector2 input)
    {
        _moveInput = input;
    }
}
