public class GameManager : Singleton<GameManager>
{
    public int Score { get; private set; }
    
    public void AddScore(int amount)
    {
        Score += amount;
    }
}
