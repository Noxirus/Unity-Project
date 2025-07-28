using UnityEngine.SceneManagement;

public class RefLevelManager : Singleton<RefLevelManager>
{
    private void Start()
    {
        SceneManager.LoadScene("RefMainMenu", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += SetActiveScene;
    }

    public void LoadLevel(string levelName)
    {
        // Unload the current level before loading the new one
        // (Assuming the Main Menu is scene 1 and levels start at 2)
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(levelName, LoadSceneMode.Additive);
        
    }

    private void SetActiveScene(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene);
    }
}
