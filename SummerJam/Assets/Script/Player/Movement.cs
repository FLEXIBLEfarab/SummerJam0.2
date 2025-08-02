using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerWalk : MonoBehaviour
{
    private InputSystem_Actions _inputActions;
    private Rigidbody _rigidbody;

    public float speed = 5f;
    public float jumpForce = 5f;

    private bool _isGrounded;

    private void Awake()
    {
        _inputActions = new InputSystem_Actions();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        _inputActions.Player.Jump.performed += ctx => Jump();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 input = _inputActions.Player.Move.ReadValue<Vector2>();

        // Движение относительно направления, куда смотрит игрок
        Vector3 move = (transform.forward * input.y + transform.right * input.x) * speed;

        // Используем velocity вместо linearVelocity (если linearVelocity у тебя не поддерживается)
        _rigidbody.linearVelocity = new Vector3(move.x, _rigidbody.linearVelocity.y, move.z);
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }
}
