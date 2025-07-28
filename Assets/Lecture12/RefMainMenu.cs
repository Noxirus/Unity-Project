using UnityEngine;

public class RefMainMenu : MonoBehaviour
{
    public void StartGame()
    {
        RefLevelManager.Instance.LoadLevel("KrakenScene");
    }
}
