using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int startSceneLoadDelay = 3;
    int currentSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitAndLoadStartScene(startSceneLoadDelay));
        }
    }

    IEnumerator WaitAndLoadStartScene(int loadDelay)
    {
        yield return new WaitForSeconds(loadDelay);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("Options Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
