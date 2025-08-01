
public class GameManager : Singleton<GameManager>
{
    
    private void Start()
    {
    }

    public int Score { get; private set; }
    
    public void AddScore(int amount)
    {
        Score += amount;
    }
}
