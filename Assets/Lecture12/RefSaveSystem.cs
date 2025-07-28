using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RefGameData
{
    public int Score;
    public Vector3 PlayerPosition;
    public List<string> InventoryItemIDs;
}

public class RefSaveSystem : Singleton<RefSaveSystem>
{
    private string _savePath;

    private void OnEnable()
    {
        _savePath = Application.persistentDataPath + "/gamedata.json";
    }

    public void SaveGame(RefGameData data)
    {
        string json = JsonUtility.ToJson(data, true); // 'true' for pretty print
        Debug.Log(json);
        System.IO.File.WriteAllText(_savePath, json);
    }

    public RefGameData LoadGame()
    {
        if (System.IO.File.Exists(_savePath))
        {
            string json = System.IO.File.ReadAllText(_savePath);
            return JsonUtility.FromJson<RefGameData>(json);
        }
        return null; // Or a new GameData
    }
}
