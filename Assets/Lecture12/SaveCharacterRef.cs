using System;
using UnityEngine;

public class SaveCharacterRef : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RefGameData gameData = RefSaveSystem.Instance.LoadGame();
        transform.position = gameData.PlayerPosition;
    }

    private void OnDestroy()
    {
        RefGameData gameData = new RefGameData();
        gameData.PlayerPosition = transform.position;
        RefSaveSystem.Instance.SaveGame(gameData);
    }
}
