using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    private void Awake()
    {
        // Singleton to ensure only one SceneController exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make it persistent across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates
        }
    }

    // Load a scene by name
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    // Coroutine for async scene loading (for smoother transitions)
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        // Optional: Show loading progress here
        while (!operation.isDone)
        {
            // Loading progress value: operation.progress (0-1)
            yield return null;
        }
    }

    // Reload the current scene
    public void ReloadCurrentScene()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }

    // Quit the game (for testing in editor as well)
    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the editor
#endif
    }
}