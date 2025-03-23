using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    [SerializeField] private float _flapStrength;

    private Rigidbody2D _rb;
    private bool _canJump = true;

    #region Monobehaviour Callbacks

    // Component reference initialization
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // End the game when colliding with a pipe
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool hitPipe = collision.collider.CompareTag("Pipe");
        bool hitGround = collision.collider.CompareTag("Ground");
        if (hitPipe || hitGround)
        {
            Freeze();
            EventManager.EndGame();
        }
    }

    #endregion

    #region Input Callbacks

    // Make the bird jump when pressing the jump button
    // Only on initial press, not hold
    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.started || !_canJump)
            return;

        _rb.linearVelocity = Vector2.up * _flapStrength;
    }

    #endregion

    // Freeze the bird in place
    private void Freeze()
    {
        _rb.gravityScale = 0;
        _rb.linearVelocity = Vector2.zero;
        _rb.angularVelocity = 0;
        _canJump = false;
    }
}