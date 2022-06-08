using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    #region Scene Management
    public void GoToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
    public void GoToSceneAsynch(int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutineAsynch(sceneIndex));
    }
    IEnumerator GoToSceneRoutineAsynch(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
        //operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            yield return null;
        }
        //operation.allowSceneActivation = true;
    }
    #endregion
}
