using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    private int currentSceneIndex;

    // 1 load a particular scene by build index
    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    // 2 load a particular scene by scene name (uses STRING, use quotes)
    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void loadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    // updates the 'currentSceneIndes' variable with the index of the current loaded scene
    private void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
}
