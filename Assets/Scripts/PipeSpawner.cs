using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _pipe;
    [SerializeField] private float _spawnRate;
    [SerializeField] private float _hieghtOffset;

    private float _timer;
    private bool _spawning;

    #region Monobehaviour Callbacks

    // Initial pipe spawn
    private void Start()
    {
        _spawning = true;
        SpawnPipe();
    }

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

    // Continuously spawn pipes (if spawning) at intervals of spawnRate
    private void Update()
    {
        if (!_spawning)
            return;

        if (_timer < _spawnRate)
            _timer += Time.deltaTime;
        else
            SpawnPipe();
    }

    #endregion

    #region Event Callbacks

    // Stops spawning pipes when the game is over
    private void OnGameOver() => _spawning = false;

    #endregion

    /// <summary>
    /// Spawns a pipe pair at this object's x position with a 
    /// random y offset from -heightOffset to +heightOffset
    /// </summary>
    private void SpawnPipe()
    {
        if (!_spawning)
            return;

        _timer = 0;
        float lowest = transform.position.y - _hieghtOffset;
        float highest = transform.position.y + _hieghtOffset;
        Vector3 position = new Vector3(transform.position.x, Random.Range(lowest, highest), 0);
        Instantiate(_pipe, position, transform.rotation);
    }
}