using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _deadZone;

    private bool _move = true;

    #region Monobehaviour Callbacks

    // Subscribe to events
    private void OnEnable()
    {
        EventManager.GameOver += OnGameOver;
    }

    // Unsubscribe from events
    private void OnDisable()
    {
        EventManager.GameOver -= OnGameOver;
    }

    // Continuously move to the left and destroy when the deadzone is reached
    private void Update()
    {
        if (!_move)
            return;

        transform.position += Vector3.left * _moveSpeed * Time.deltaTime;

        if (transform.position.x < _deadZone)
            Destroy(gameObject);
    }

    #endregion

    #region Event Callbacks

    // Stop moving when the game is over
    private void OnGameOver() => _move = false;

    #endregion
}