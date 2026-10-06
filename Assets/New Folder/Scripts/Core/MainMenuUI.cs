using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void StartGame()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.StartNewGame();
        }

        Debug.Log("START clicked.");

        // For now we'll load the opening scene once we create it.
        // SceneManager.LoadScene("Opening");
    }

    public void LoadGame()
    {
        Debug.Log("LOAD clicked.");
    }

    public void OpenSettings()
    {
        Debug.Log("SETTINGS clicked.");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT clicked.");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}