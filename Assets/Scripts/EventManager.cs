using System;

public static class EventManager
{
    // Point scored event
    public static event Action<int> IncreasingScore;
    public static void IncreaseScore(int amount) => IncreasingScore?.Invoke(amount);

    // Game over event
    public static event Action GameOver;
    public static void EndGame() => GameOver?.Invoke();

}